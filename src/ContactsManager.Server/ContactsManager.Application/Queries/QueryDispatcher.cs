using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsManager.Application.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider services;

        public QueryDispatcher(IServiceProvider services)
        {
            this.services = services;
        }

        public async Task<IList<IResult>> Send<T>(T query) where T : IQuery
        {
            var handler = services.GetService(typeof(IQueryHandler<T>));
            if (handler != null)
                return await ((IQueryHandler<T>)handler).Handle(query);
            else
                throw new QueryException($"Query handler {query.GetType().Name} does not exist");
        }

        public IResult SendSingle<T>(T query) where T : IQuery
        {
            var handler = services.GetService(typeof(ISingleResultQueryHandler<T>));
            if (handler != null)
                return ((ISingleResultQueryHandler<T>)handler).Handle(query);
            else
                throw new QueryException($"Query handler {query.GetType().Name} does not exist");
        }
    }
}
