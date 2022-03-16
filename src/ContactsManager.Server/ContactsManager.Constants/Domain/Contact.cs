namespace ContactsManager.Constants.Domain
{
    public static class Contact
    {
        public const string PHONE_NUMBER_PATERN = @"^(\+\d{1,3}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-](\d{4}|\d{3})$|^\d{6,10}$|^\+\d{6,12}$";
        public const string IBAN_PATERN = @"^DE\d{20}$";
    }

    public static class ExeptionMessages
    {
        public const string FIRST_NAME_REQUIRED = "First name is required and must be at least 3 simbols long.";
        public const string LAST_NAME_REQUIRED = "Last name is required and must be at least 3 simbols long.";
        public const string INVALID_DATE_OF_BIRTH = "Invalid Date of birth.";
        public const string ADDRESS_REQUIRED = "Address is required.";
        public const string INVALID_PROPERTY = "Invalid {0} format.";
    }
}
