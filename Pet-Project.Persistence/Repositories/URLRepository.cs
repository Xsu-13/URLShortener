using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pet_Project.Logic.Interfaces;
using Pet_Project.Logic.Models;
using Pet_Project.Persistence.Entities;

namespace Pet_Project.Persistence.Repositories
{
    public class URLRepository : IURLService
    {
        private readonly URLGeneratingDBContext _dbContext;
        private readonly IMapper _mapper;
        public URLRepository(URLGeneratingDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> CreateURL(GeneratingURL url)
        {
            var urlEntity = new URLEntity()
            {
                Id = url.Id,
                LongUrl = url.LongUrl,
                ShortUrl = url.ShortUrl
            };

            await _dbContext.AddAsync(urlEntity);
            await _dbContext.SaveChangesAsync();

            return url.Id;
        }

        public async Task<GeneratingURL> GetURLById(int id)
        {
            var urlEntity = await _dbContext.Urls
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();

            return _mapper.Map<GeneratingURL>(urlEntity);
        }
    }
}
