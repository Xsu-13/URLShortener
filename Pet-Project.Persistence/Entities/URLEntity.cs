using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Persistence.Entities
{
    public class URLEntity
    {
        public Guid Id { get; set; }
        public string LongUrl { get; set; } = null!;
        public string ShortUrl { get; set; } = null!;
    }
}
