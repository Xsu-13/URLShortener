using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pet_Project.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Persistence.Configurations
{
    internal class URLConfiguration : IEntityTypeConfiguration<URLEntity>
    {
        public void Configure(EntityTypeBuilder<URLEntity> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
