using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Domain.Entities;

namespace Ticketz.Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(a => a.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.AirlineId).HasColumnName("AirlineId").IsRequired();
        builder.Property(o => o.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(o => o.FlightId).HasColumnName("FlightId").IsRequired();
        builder.Property(o => o.DepartureDate).HasColumnName("DepartureDate").IsRequired();
        builder.Property(o => o.ArrivalDate).HasColumnName("ArrivalDate").IsRequired();
        builder.Property(o => o.UserId).HasColumnName("UserId");
        builder.Property(o => o.OrderState).HasColumnName("OrderState").IsRequired();
        builder.Property(o => o.Price).HasColumnName("Price").IsRequired();

        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasOne(o => o.Flight);        
        builder.HasOne(o => o.Airline);
        builder.HasOne(o => o.User);
        builder.HasOne(o => o.Customer);

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}
