using MediatR;

namespace NETCore.App.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}