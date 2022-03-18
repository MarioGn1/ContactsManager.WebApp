using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsManager.Application.Interfaces.Queries
{
    public interface IQueryDispatcher
    {
        Task<IList<IResult>> Send<T>(T query) where T : IQuery;
        Task<IResult> SendSingle<T>(T query) where T : IQuery;
    }
}
