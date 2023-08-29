using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LaNacion.Model.Entities;
using System.Reflection.Emit;

namespace LaNacion.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> entity)
        {
            entity.ToTable("Contacts");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.CompanyId).IsRequired();
            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(x => x.Birthdate)
                .IsRequired();
            entity.Property(x => x.Image)
            .HasMaxLength(1000);
            entity.HasMany(x => x.PhoneNumbers)
                .WithOne(y => y.Contact)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
