using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Pet_Project.Logic.Interfaces;
using Pet_Project.Logic.Models;
using Pet_Project.Persistence.Entities;

namespace Pet_Project.Persistence.Repositories
{
    public class URLRepository : IURLService
    {
        private readonly URLGeneratingDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public URLRepository(URLGeneratingDBContext dbContext, IMapper mapper, IDistributedCache distributedCache)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<Guid> CreateURL(GeneratingURL url, CancellationToken cancellationToken=default)
        {
            try
            {
                var urlEntity = new URLEntity()
                {
                    Id = url.Id,
                    LongUrl = url.LongUrl,
                    ShortUrl = url.ShortUrl
                };

                await _dbContext.AddAsync(urlEntity);
                await _dbContext.SaveChangesAsync();

                var key = "url-" + urlEntity.ShortUrl;
                /*var options = new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = new DateTimeOffset(DateTime.UtcNow + new TimeSpan(0, 0, 10))
                };*/
                await _distributedCache.SetStringAsync(key, urlEntity.LongUrl, cancellationToken);
                

                return url.Id;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Creating url error: " + ex.Message);
                return Guid.Empty;
            }
            
        }

        public async Task<GeneratingURL> GetURLById(Guid id)
        {
            try
            {
                var urlEntity = await _dbContext.Urls
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();

                return _mapper.Map<GeneratingURL>(urlEntity);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Searching url error: " + ex.Message);
                return null;
            }
            
        }

        public async Task<GeneratingURL> GetURLByShortURL(string shortUrl, CancellationToken cancellationToken = default)
        {
            try
            {
                var key = "url-" + shortUrl;
                string? url = await _distributedCache.GetStringAsync(key, cancellationToken);

                if (string.IsNullOrEmpty(url))
                {
                    var urlEntity = await _dbContext.Urls
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ShortUrl == shortUrl) ?? throw new Exception();

                    await _distributedCache.SetStringAsync(key, urlEntity.LongUrl, cancellationToken);

                    return _mapper.Map<GeneratingURL>(urlEntity);
                }

                return GeneratingURL.Create(Guid.Empty, url, shortUrl);
                
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Searching url error: " + ex.Message);
                return null; 
            }
            
        }
    }
}
