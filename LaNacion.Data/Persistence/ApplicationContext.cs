using LaNacion.Data.Configurations;
using LaNacion.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LaNacion.Data.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            var contactAddress = modelBuilder.Entity<ContactAddress>();
            contactAddress.ToTable("ContactAddress").HasKey(x => x.ContactId);
            contactAddress.Property(x => x.Street).HasMaxLength(60);
            contactAddress.Property(x => x.Number).HasMaxLength(10);
            contactAddress.Property(x => x.City).HasMaxLength(50);
            contactAddress.Property(x => x.State).HasMaxLength(50);
            contactAddress.Property(x => x.PostalCode).HasMaxLength(10);
        }
    }
}
