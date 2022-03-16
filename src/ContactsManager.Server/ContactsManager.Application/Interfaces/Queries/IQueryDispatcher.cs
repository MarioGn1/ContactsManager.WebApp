using System.Collections.Generic;

namespace ContactsManager.Application.Interfaces.Queries
{
    public interface IQueryDispatcher
    {
        IList<IResult> Send<T>(T query) where T : IQuery;
    }
}
