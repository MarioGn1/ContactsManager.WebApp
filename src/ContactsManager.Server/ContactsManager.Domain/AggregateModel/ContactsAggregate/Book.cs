using ContactsManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManager.Domain.AggregateModel.ContactsAggregate
{
    public class Book : Entity, IAggregateRoot
    {
        public string OwnerId { get; private set; }
        private readonly List<Contact> contacts;
        public IReadOnlyCollection<Contact> Contacts => contacts;

        public Book(string ownerId)
        {
            OwnerId = ownerId;
            contacts = new List<Contact>();
        }

        public Contact GetById(int contactId)
        {
            return this.contacts.Find(x => x.Id == contactId);
        }

        public IReadOnlyCollection<Contact> GetByName(string name)
        {
            var contacts = this.contacts
                .Where(x => x.FirstName == name || x.LastName == name)
                .ToList()
                .AsReadOnly();

            return Contacts;
        }

        public Contact Add(string firstName, 
            string lastName, 
            DateTime dateOfBirth,
            string street, string city, string state, string country, string zipcode, 
            string phoneNumber, 
            string IBAN)
        {
            Address address = new Address(street, city, state, country, zipcode);

            Contact contact = new Contact(firstName, lastName, dateOfBirth, address, phoneNumber, IBAN);
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

            var contact = contacts.Find(x => x.Id == contactId);
            contact.Update(firstName, lastName, dateOfBirth, address, phoneNumber, IBAN);
        }

        public void Delete(int contactId)
        {
            var contact = contacts.Find(x => x.Id == contactId);
            this.contacts.Remove(contact);
        }
    }
}
