using ContactsManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManager.Domain.AggregateModel.ContactsAggregate
{
    public class Book : Entity, IAggregateRoot
    {
        private readonly HashSet<Contact> contacts;

        public IReadOnlyCollection<Contact> Contacts 
            => contacts
                .OrderBy(x => x.FirstName)
                .ToList();

        public Book()
        {
            contacts = new HashSet<Contact>();
        }


        public Contact GetById(int contactId)
        {
            return this.contacts.FirstOrDefault(x => x.Id == contactId);
        }

        public IReadOnlyCollection<Contact> GetByName(string name)
        {
            var contacts = this.contacts
                .Where(x => x.FirstName == name || x.LastName == name)
                .OrderBy(x => x.FirstName)
                .ToList()
                .AsReadOnly();

            return Contacts;
        }

        public Contact Create(int bookId, string firstName,
            string lastName,
            DateTime dateOfBirth,
            string street, string city, string state, string country, string zipcode,
            string phoneNumber,
            string IBAN)
        {
            Address address = new Address(street, city, state, country, zipcode);

            Contact contact = new Contact(bookId, firstName, lastName, dateOfBirth, address, phoneNumber, IBAN);
            this.contacts.Add(contact);

            return contact;
        }

        public void Update(int contactId,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string street, string city, string state, string country, string zipcode,
            string phoneNumber,
            string IBAN)
        {
            Address address = new Address(street, city, state, country, zipcode);

            var contact = this.contacts.FirstOrDefault(x => x.Id == contactId);
            contact.Update(firstName, lastName, dateOfBirth, address, phoneNumber, IBAN);
        }

        public void Delete(int contactId)
        {
            var contact = this.contacts.FirstOrDefault(x => x.Id == contactId);
            this.contacts.Remove(contact);
        }
    }
}
