using Pet_Project.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Logic.Interfaces
{
    public  interface IURLService
    {
        public Task<Guid> CreateURL(GeneratingURL url, CancellationToken cancellationToken);

        public Task<GeneratingURL> GetURLById(Guid id);

        public Task<GeneratingURL> GetURLByShortURL(string shortUrl, CancellationToken cancellationToken);
    }
}
