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
        public Task<int> CreateURL(GeneratingURL url);

        public Task<GeneratingURL> GetURLById(int id);
    }
}
