using ContactsManager.Application.Interfaces.Queries;

namespace ContactsManager.Application.Queries.GetAll
{
    public class GetAllQuery : IQuery
    {
        public string OwnerId { get; set; }
    }
}
