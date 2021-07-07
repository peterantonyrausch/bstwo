using BS2.Foundation.Operations.Notifications;
using System;

namespace BS2.Foundation.Operations
{
    public abstract class Operation : Notifiable
    {
        public bool Success { get; private set; }

        public static implicit operator bool(Operation operation) => operation.Success;

        public TMatch Match<TMatch>(
            Func<NotificationCollection, TMatch> failure,
            Func<TMatch> success
        ) => Success ? success() : failure(Notifications);

        protected void Succeeded()
        {
            Success = true;
        }

        protected void Failed()
        {
            Success = false;
        }

        protected void Failed(string errorMessage)
        {
            AddError(errorMessage);
            Failed();
        }

        protected void Failed(string errorKey, string errorMessage)
        {
            AddError(errorKey, errorMessage);
            Failed();
        }
    }

    public abstract class Operation<TOutput> : Operation
        where TOutput : IOperationOutput
    {
        public TOutput Output { get; private set; }

        public static implicit operator TOutput(Operation<TOutput> operation) => operation.Output;

        public TMatch Match<TMatch>(
            Func<NotificationCollection, TMatch> failure,
            Func<TOutput, TMatch> success
        ) => Success ? success(Output) : failure(Notifications);

        protected void Succeeded(TOutput output)
        {
            Output = output;
            Succeeded();
        }
    }
}