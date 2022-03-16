using ContactsManager.Application.Interfaces.Queries;

namespace ContactsManager.Application.Common
{
    public class ContactDisplay : IResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
