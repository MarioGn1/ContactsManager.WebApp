using ContactsManager.Application.Interfaces.Queries;

namespace ContactsManager.Application.Queries.GetById
{
    public class GetByIdQuery : IQuery
    {
        public string OwnerId { get; set; }
        public int ContactId { get; set; }
    }
}
