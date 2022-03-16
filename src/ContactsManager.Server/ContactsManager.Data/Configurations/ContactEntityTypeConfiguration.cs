using ContactsManager.Domain.AggregateModel.ContactsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ContactsManager.Data.Configurations
{
    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("contacts");

            builder.HasKey(x => x.Id);

            builder.Property(b => b.Id)
                .UseHiLo("contactseq");

            builder.OwnsOne(b => b.Address, a =>
            {
                a.Property<int>("ContactId")
                .UseHiLo("contactseq");

                a.Property(a => a.Street)
                .HasMaxLength(50)
                .IsRequired();

                a.Property(a => a.City)
                .HasMaxLength(50)
                .IsRequired();

                a.Property(a => a.Country)
                .HasMaxLength(50)
                .IsRequired();

                a.Property(a => a.State)
                .HasMaxLength(50)
                .IsRequired(false);

                a.Property(a => a.ZipCode)
                .HasMaxLength(10)
                .IsRequired();

                a.WithOwner();
            });

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(30)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("FirstName")
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasMaxLength(30)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("LastName")
                .IsRequired();

            builder
                .Property(c => c.DateOfBirth)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DateOfBirth")
                .IsRequired();

            builder
                .Property(c => c.PhoneNumber)
                .HasMaxLength(15)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PhoneNumber")
                .IsRequired();

            builder
                .Property(c => c.Iban)
                .HasMaxLength(30)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IBAN")
                .IsRequired();

            builder.HasOne<Book>()
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.BookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
