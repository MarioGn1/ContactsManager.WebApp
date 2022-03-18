namespace ContactsManager.Application.Queries.Utils
{
    public static class SqlQueries
    {
        public const string getAllContactsQuery = "SELECT  c.Id, c.FirstName, c.LastName FROM AspNetUsers u LEFT JOIN contacts c ON u.BookId = c.BookId WHERE u.Id = @userId ORDER BY c.FirstName";
    }
}
