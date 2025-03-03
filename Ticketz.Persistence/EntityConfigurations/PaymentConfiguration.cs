using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Domain.Entities;

namespace Ticketz.Persistence.EntityConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments").HasKey(a => a.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.OrderId).HasColumnName("OrderId").IsRequired();
            builder.Property(p => p.CardHolderName).HasColumnName("CardHolderName").IsRequired();
            builder.Property(p => p.CardNumber).HasColumnName("CardNumber").IsRequired();
            builder.Property(p => p.ExpirationDate).HasColumnName("ExpirationDate").IsRequired();
            builder.Property(p => p.Cvv).HasColumnName("Cvv").IsRequired();
            builder.Property(p => p.Price).HasColumnName("Price").IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Order>(o => o.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        }
    }
}
