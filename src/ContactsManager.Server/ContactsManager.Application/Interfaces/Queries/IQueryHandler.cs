using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsManager.Application.Interfaces.Queries
{
    public interface IQueryHandler
    {
    }

    public interface IQueryHandler<T> : IQueryHandler where T : IQuery
    {
        Task<IList<IResult>> Handle(T query);        
    }

    public interface ISingleResultQueryHandler<T> : IQueryHandler where T : IQuery
    {
        Task<IResult> Handle(T query);
    }
}
