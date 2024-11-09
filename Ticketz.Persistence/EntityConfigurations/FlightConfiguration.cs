using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Domain.Entities;

namespace Ticketz.Persistence.EntityConfigurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{

    

    public void Configure(EntityTypeBuilder<Flight> builder)
    {

        builder.ToTable("Flights").HasKey(f => f.Id);

        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.AirlineId).HasColumnName("AirlineId").IsRequired();
        builder.Property(f => f.DepartureAirportId).HasColumnName("DepartureAirportId").IsRequired();
        builder.Property(f => f.ArrivalAirportId).HasColumnName("ArrivalAirportId").IsRequired();
        builder.Property(f => f.DepartureTime).HasColumnName("DepartureTime").IsRequired();
        builder.Property(f => f.ArrivalTime).HasColumnName("ArrivalTime").IsRequired();
        builder.Property(f => f.Price).HasColumnName("Price").IsRequired();
        builder.Property(f => f.AdultPassengers).HasColumnName("AdultPassengers");
        builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(f => f.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasMany(f => f.Orders);
        builder.HasOne(f => f.Airline);
        builder.HasOne(f => f.ArrivalAirport).WithMany(a => a.ArrivingFlights).HasForeignKey(f => f.ArrivalAirportId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(f => f.DepartureAirport).WithMany(a => a.DepartingFlights).HasForeignKey(f => f.DepartureAirportId).OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(f => !f.DeletedDate.HasValue);        
    }
}
