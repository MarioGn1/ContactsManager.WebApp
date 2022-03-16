using ContactsManager.Domain.Common;
using System;
using System.Text.RegularExpressions;

using static ContactsManager.Constants.Domain.Contact;
using static ContactsManager.Constants.Domain.ExeptionMessages;

namespace ContactsManager.Domain.AggregateModel.ContactsAggregate
{
    public class Contact : Entity
    {
        private int bookId;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private Address address;
        private string phoneNumber;
        private string iban;

        public Contact()
        { }

        public Contact(int bookId,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            Address address,
            string phoneNumber,
            string IBAN)
        {
            BookId = bookId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            this.Iban = IBAN;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ContactsException(FIRST_NAME_REQUIRED);
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ContactsException(LAST_NAME_REQUIRED);
                }
                lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            private set
            {
                if (value > DateTime.Now || value < DateTime.Now.AddYears(-120))
                {
                    throw new ContactsException(INVALID_DATE_OF_BIRTH);
                }
                dateOfBirth = value;
            }
        }

        public Address Address
        {
            get { return address; }
            private set
            {
                if (value == null)
                {
                    throw new ContactsException(ADDRESS_REQUIRED);
                }
                address = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            private set
            {
                var patern = PHONE_NUMBER_PATERN;
                IsValid(value, patern, nameof(PhoneNumber));
                phoneNumber = value;
            }
        }

        public string Iban
        {
            get { return iban; }
            private set
            {
                //Regex match for Germany, could be extracted to resourse file or config file
                var patern = IBAN_PATERN;
                IsValid(value, patern, nameof(Iban));
                iban = value;
            }
        }

        public int BookId
        {
            get => bookId;
            private set => bookId = value;
        }

        public void Update(string firstName,
            string lastName,
            DateTime dateOfBirth,
            Address address,
            string phoneNumber,
            string IBAN)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            this.Iban = IBAN;
        }

        private static void IsValid(string value, string patern, string propertyName)
        {
            Regex regex = new Regex(patern);
            MatchCollection matches = regex.Matches(value);

            if (matches.Count == 0)
            {
                throw new ContactsException(String.Format(INVALID_PROPERTY, propertyName));
            }
        }
    }
}
