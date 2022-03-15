using ContactsManager.Domain.Common;
using System;
using System.Text.RegularExpressions;

namespace ContactsManager.Domain.AggregateModel.ContactsAggregate
{
    public class Contact : Entity
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private Address address;
        private string phoneNumber;
        private string iban;

        public Contact(string firstName, string lastName, DateTime dateOfBirth, Address address, string phoneNumber, string IBAN)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            this.IBAN = IBAN;
        }

        public string FirstName
        {
            get { return firstName; }
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ContactsException("First name could not be null or empty string and must be at least 3 simbols long.");
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
                    throw new ContactsException("Last name could not be null or empty string and must be at least 3 simbols long.");
                }
                lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            private set 
            { 
                if(value > DateTime.Now || value < DateTime.Now.AddYears(120))
                {
                    throw new ContactsException("Invalid date.");
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
                    throw new ContactsException("Address could not be null.");
                }
                address = value; 
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            private set
            {
                var patern = @"^(\+\d{1,3}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-](\d{4}|\d{3})$|^\d{6,10}$|^\+\d{6,12}$";
                IsValid(value, patern, nameof(PhoneNumber));
                phoneNumber = value;
            }
        }

        public string IBAN
        {
            get { return iban; }
            private set 
            {
                //Regex match for Germany, could be extracted to resourse file or config file
                var patern = @"^DE\d{20}$";
                IsValid(value, patern, nameof(IBAN));
                iban = value; 
            }
        }

        public void Update(string firstName, string lastName, DateTime dateOfBirth, Address address, string phoneNumber, string IBAN)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            this.IBAN = IBAN;
        }

        private static void IsValid(string value, string patern, string propertyName)
        {
            Regex regex = new Regex(patern);
            MatchCollection matches = regex.Matches(value);

            if (matches.Count == 0)
            {
                throw new ContactsException($"Invalid {propertyName}.");
            }
        }
    }
}
