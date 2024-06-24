using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Logic.Models
{
    public class GeneratingURL
    {
        public Guid Id { get; private set; }

        public string ShortUrl { get; set; } = null!;

        public string LongUrl { get; set; } = null!;

        public GeneratingURL(Guid id, string shortUrl, string longUrl)
        {
            Id = id;
            ShortUrl = shortUrl;
            LongUrl = longUrl;
        }

        public static GeneratingURL Create(Guid id, string LongUrl, string ShortUrl)
        {
            if (string.IsNullOrEmpty(ShortUrl)) throw new ArgumentException("ShortUrl cannot be null!");

            if (string.IsNullOrEmpty(LongUrl)) throw new ArgumentException("LongUrl cannot be null!");

            return new GeneratingURL(id, ShortUrl, LongUrl);
        }

    }
}
