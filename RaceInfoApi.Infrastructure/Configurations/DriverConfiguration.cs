using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaceInfoApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceInfoApi.Infrastructure.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("drivers");
            builder.HasKey(d => d.id);

            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Nationality).IsRequired();
            builder.Property(d => d.Team).IsRequired();
        }
    }
}
