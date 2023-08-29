using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LaNacion.Model.Entities;

namespace LaNacion.Data.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> entity)
        {
            entity.ToTable("PhoneNumbers");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(x => x.Type)
                .IsRequired();
;
        }
    }
}
