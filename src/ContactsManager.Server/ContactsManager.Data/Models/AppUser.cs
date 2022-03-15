using ContactsManager.Domain.AggregateModel.OwnerAggregate;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ContactsManager.Data.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}
