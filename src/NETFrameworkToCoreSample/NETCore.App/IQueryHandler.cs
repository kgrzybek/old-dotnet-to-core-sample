using MediatR;
using NETCore.App.Contracts;

namespace NETCore.App
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}