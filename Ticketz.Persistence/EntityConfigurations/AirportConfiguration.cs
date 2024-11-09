using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Domain.Entities;

namespace Ticketz.Persistence.EntityConfigurations;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.ToTable("Airports").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
        builder.Property(a => a.AirportCode).HasColumnName("AirportCode").IsRequired();

        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasIndex(indexExpression: a => a.Name, name: "UK_Airport_Name").IsUnique();

        builder.HasMany(a=> a.DepartingFlights);
        builder.HasMany(a => a.ArrivingFlights);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
