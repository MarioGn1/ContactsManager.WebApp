using System.Collections.Generic;

namespace ContactsManager.Application.Interfaces.Queries
{
    public interface IResult
    {
    }
    public interface IListResult : ICollection<IResult>
    {
    }
}
