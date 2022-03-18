namespace ContactsManager.Application.Queries.Utils
{
    public static class SqlQueries
    {
        public const string getAllContactsQuery =
            "SELECT  c.Id, c.FirstName, c.LastName " +
            "FROM AspNetUsers u " +
            "LEFT JOIN books b ON u.BookId = b.Id " +
            "LEFT JOIN contacts c ON b.Id = c.BookId " +
            "WHERE u.Id = @userId " +
            "ORDER BY c.FirstName";
        public const string getByNameQuery =
            "SELECT  c.Id, c.FirstName, c.LastName " +
            "FROM AspNetUsers u " +
            "LEFT JOIN books b ON u.BookId = b.Id " +
            "LEFT JOIN contacts c ON u.BookId = c.BookId " +
            "WHERE u.Id = @userId AND c.FirstName LIKE @name OR c.LastName LIKE @name " +
            "ORDER BY c.FirstName";
        public static string getByIdQuery =
            "SELECT  c.Id, c.FirstName, c.LastName, c.DateOfBirth, c.PhoneNumber, c.IBAN, " +
            "c.Address_Street as Street, " +
            "c.Address_City as City, " +
            "c.Address_State as State, " +
            "c.Address_Country as Country, " +
            "c.Address_ZipCode as ZipCode " +
            "FROM AspNetUsers u " +
            "LEFT JOIN books b ON u.BookId = b.Id " +
            "LEFT JOIN contacts c ON b.Id = c.BookId " +
            "WHERE u.Id = @userId AND c.Id = @contactId";
    }
}
