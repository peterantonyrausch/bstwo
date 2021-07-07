using System.Threading.Tasks;

namespace BS2.Foundation.Operations.Async
{
    public abstract class AsyncOperation : Operation, IAsyncOperation
    {
        public abstract Task ExecuteAsync();
    }

    public abstract class InAsyncOperation<TInput> : Operation, IInAsyncOperation<TInput>
        where TInput : IOperationInput
    {
        public abstract Task ExecuteAsync(TInput input);
    }

    public abstract class OutAsyncOperation<TOutput> : Operation<TOutput>, IOutAsyncOperation<TOutput>
        where TOutput : IOperationOutput
    {
        public abstract Task ExecuteAsync();
    }

    public abstract class InOutAsyncOperation<TInput, TOutput> : Operation<TOutput>, IInOutAsyncOperation<TInput, TOutput>
        where TInput : IOperationInput
        where TOutput : IOperationOutput
    {
        public abstract Task ExecuteAsync(TInput input);
    }
}