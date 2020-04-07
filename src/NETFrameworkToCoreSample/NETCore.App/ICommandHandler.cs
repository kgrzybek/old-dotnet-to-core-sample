using System.Windows.Input;
using MediatR;
using NETCore.App.Contracts;
using ICommand = NETCore.App.Contracts.ICommand;

namespace NETCore.App
{
    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand> where TCommand : ICommand
    {

    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {

    }
}