namespace BS2.Foundation.Operations.Sync
{
    public abstract class SyncOperation : Operation, ISyncOperation
    {
        public abstract void Execute();
    }

    public abstract class InSyncOperation<TInput> : Operation, IInSyncOperation<TInput>
        where TInput : IOperationInput
    {
        public abstract void Execute(TInput input);
    }

    public abstract class OutSyncOperation<TOutput> : Operation<TOutput>, IOutSyncOperation<TOutput>
        where TOutput : IOperationOutput
    {
        public abstract void Execute();
    }

    public abstract class InOutSyncOperation<TInput, TOutput> : Operation<TOutput>, IInOutSyncOperation<TInput, TOutput>
        where TInput : IOperationInput
        where TOutput : IOperationOutput
    {
        public abstract void Execute(TInput input);
    }
}