using ContactsManager.Data.Models;
using ContactsManager.Domain.AggregateModel.ContactsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsManager.Data.Configurations
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .UseHiLo("bookseq");

            var navigation = builder.Metadata.FindNavigation(nameof(Book.Contacts));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne<AppUser>()
                .WithOne(x => x.Book)
                .HasForeignKey<AppUser>(x => x.BookId)
                .IsRequired();
        }
    }
}
