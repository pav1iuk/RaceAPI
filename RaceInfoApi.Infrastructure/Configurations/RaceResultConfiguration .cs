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
    public class RaceResultConfiguration : IEntityTypeConfiguration<RaceResult>
    {
        public void Configure(EntityTypeBuilder<RaceResult> builder)
        {
            builder.ToTable("raceresults");
            builder.HasKey(rr => rr.id);

            builder.HasOne(rr => rr.Race)
                .WithMany(r => r.Results)
                .HasForeignKey(rr => rr.RaceId);

            builder.HasOne(rr => rr.Driver)
                .WithMany(d => d.Results)
                .HasForeignKey(rr => rr.DriverId);
        }
    }
}
