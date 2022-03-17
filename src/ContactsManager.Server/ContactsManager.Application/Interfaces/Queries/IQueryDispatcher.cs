using System.Collections.Generic;

namespace ContactsManager.Application.Interfaces.Queries
{
    public interface IQueryDispatcher
    {
        IList<IResult> Send<T>(T query) where T : IQuery;
        IResult SendSingle<T>(T query) where T : IQuery;
    }
}
