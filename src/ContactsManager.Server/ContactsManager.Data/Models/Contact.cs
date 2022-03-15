using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsManager.Data.Models
{
    [Table("Contacts")]
    public class Contact
    {
        public int Id { get; init; }
        [Required]
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string IBAN { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
