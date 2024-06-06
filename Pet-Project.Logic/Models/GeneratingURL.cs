using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Logic.Models
{
    public class GeneratingURL
    {
        public int Id { get; set; }
        public string ShortUrl { get; set; } = null!;

        public string LongUrl { get; set; } = null!;

    }
}
