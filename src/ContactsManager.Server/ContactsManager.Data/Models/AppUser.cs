using ContactsManager.Domain.AggregateModel.ContactsAggregate;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ContactsManager.Data.Models
{
    public class AppUser : IdentityUser
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
