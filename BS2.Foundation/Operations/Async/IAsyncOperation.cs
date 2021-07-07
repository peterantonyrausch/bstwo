using System.Threading.Tasks;

namespace BS2.Foundation.Operations.Async
{
    public interface IAsyncOperation
    {
        Task ExecuteAsync();
    }

    public interface IInAsyncOperation<in TInput>
        where TInput : IOperationInput
    {
        Task ExecuteAsync(TInput input);
    }

    public interface IOutAsyncOperation<out TOutput>
        where TOutput : IOperationOutput
    {
        TOutput Output { get; }

        Task ExecuteAsync();
    }

    public interface IInOutAsyncOperation<in TInput, out TOutput>
        where TInput : IOperationInput
        where TOutput : IOperationOutput
    {
        TOutput Output { get; }

        Task ExecuteAsync(TInput input);
    }
}