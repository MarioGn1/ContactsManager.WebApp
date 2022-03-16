using ContactsManager.Application.Interfaces.Queries;

namespace ContactsManager.Application.Queries.GetByName
{
    public class GetByNameQuery : IQuery
    {
        public string OwnerId { get; set; }
        public string Name { get; set; }
    }
}
