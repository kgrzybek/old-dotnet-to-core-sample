using NETCore.App;
using NETCore.App.Contracts;

namespace NETFramework.App
{
    public interface INewAppGateway
    {
        void ExecuteCommand(ICommand command);

        T ExecuteCommand<T>(ICommand<T> command) where T : class, new();

        T ExecuteQuery<T>(IQuery<T> query) where T : class, new();
    }
}