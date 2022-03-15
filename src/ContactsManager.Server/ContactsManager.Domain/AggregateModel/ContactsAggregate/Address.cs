using ContactsManager.Domain.Common;
using System;
using System.Collections.Generic;

namespace ContactsManager.Domain.AggregateModel.ContactsAggregate
{
    public class Address : ValueObject
    {
        private string street;
        private string city;
        private string state;
        private string country;
        private string zipCode;

        public Address() { }

        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        public string Street { get => street; private set => street = value; }
        public string City { get => city; private set => city = value ; }
        public string State { get => state; private set => state = value; }
        public string Country { get => country; private set => country = value; }
        public string ZipCode { get => zipCode; private set => zipCode = value; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
