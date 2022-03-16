using System.Collections.Generic;

namespace ContactsManager.Application.Interfaces.Queries
{
    public interface IQueryHandler
    {
    }

    public interface IQueryHandler<T> : IQueryHandler where T : IQuery
    {
        IList<IResult> Handle(T query);        
    }

    public interface ISingleResultQueryHandler<T> : IQueryHandler where T : IQuery
    {
        IResult Handle(T query);
    }
}
