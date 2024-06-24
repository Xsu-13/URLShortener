using Pet_Project.Logic.Interfaces;
using Pet_Project.Logic.Models;
using Pet_Project.Persistence.Repositories;
using System;

namespace Pet_Project.Application.Services
{
    public class UrlService
    {
        private readonly IURLService _urlRepository;

        public UrlService(IURLService urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<Guid> CreateURL(GeneratingURL url, CancellationToken cancellationToken = default)
        {
            var id = await _urlRepository.CreateURL(url, cancellationToken);
            return id;
        }

        public async Task<GeneratingURL> GetURLById(Guid id)
        {
            var resultURL = await _urlRepository.GetURLById(id);
            return resultURL;
        }

        public async Task<GeneratingURL> GetURLByShortURL(string shortUrl, CancellationToken cancellationToken = default)
        {
            var resultURL = await _urlRepository.GetURLByShortURL(shortUrl, cancellationToken);

            return resultURL;
        }
    }
}
