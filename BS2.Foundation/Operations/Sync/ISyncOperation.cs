namespace BS2.Foundation.Operations.Sync
{
    public interface ISyncOperation
    {
        void Execute();
    }

    public interface IInSyncOperation<in TInput>
        where TInput : IOperationInput
    {
        void Execute(TInput input);
    }

    public interface IOutSyncOperation<out TOutput>
        where TOutput : IOperationOutput
    {
        TOutput Output { get; }

        void Execute();
    }

    public interface IInOutSyncOperation<in TInput, out TOutput>
        where TInput : IOperationInput
        where TOutput : IOperationOutput
    {
        TOutput Output { get; }

        void Execute(TInput input);
    }
}