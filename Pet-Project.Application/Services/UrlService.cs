using Pet_Project.Logic.Models;
using Pet_Project.Persistence.Repositories;
using System;

namespace Pet_Project.Application.Services
{
    internal class UrlService
    {
        private readonly URLRepository _urlRepository;
        public UrlService(URLRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }
        public async Task<int> CreateURL(GeneratingURL url)
        {
            var id = await _urlRepository.CreateURL(url);
            return id;
        }

        public async Task<GeneratingURL> GetURLById(int id)
        {
            var resultURL = await _urlRepository.GetURLById(id);
            return resultURL;
        }
    }
}
