using PagamentoContext.Shared.Commands;

namespace PagamentoContext.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
