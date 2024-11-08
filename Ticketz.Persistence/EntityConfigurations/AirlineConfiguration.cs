using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Domain.Entities;

namespace Ticketz.Persistence.EntityConfigurations;

public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
{
    public void Configure(EntityTypeBuilder<Airline> builder)
    {
        builder.ToTable("Airlines").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
        builder.Property(a => a.IATACode).HasColumnName("IATACode").IsRequired();

        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasIndex(indexExpression: a => a.Name, name: "UK_Airline_Name").IsUnique();

        builder.HasMany(a => a.Orders);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
