using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaceInfoApi.Core.Entities;

namespace RaceInfoApi.Infrastructure.Configurations
{

    public class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.ToTable("races");
            builder.HasKey(r => r.id);

            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Location).IsRequired();
        }
    }
}
