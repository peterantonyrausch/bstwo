using BS2.Foundation.Operations.Async;
using System.Threading.Tasks;

namespace Sample.Business.Pagamentos.AddTwoStrings
{
    public class AddTwoStringsOperation : InOutAsyncOperation<AddTwoStringsInput, AddTwoStringsOutput>
    {
        public override Task ExecuteAsync(AddTwoStringsInput input)
        {
            if (string.IsNullOrWhiteSpace(input.First))
            {
                AddError("Please enter the first value", "First");
            }

            if (string.IsNullOrWhiteSpace(input.Second))
            {
                AddError("Please enter the second value", "Second");
            }

            if (!decimal.TryParse(input.First, out var first))
            {
                AddError(nameof(AddTwoStringsInput.First), "First value is not a valid decimal and will be considered zero.");
            }

            if (!decimal.TryParse(input.Second, out var second))
            {
                AddError(nameof(AddTwoStringsInput.Second), "Second value is not a valid decimal and will be considered zero.");
            }

            if (first == second)
            {
                AddError("The first and second values must be different.");
            }

            if (HasErrors)
            {
                Failed();
                return Task.CompletedTask;
            }

            var result = first + second;

            Succeeded(new AddTwoStringsOutput(result));

            return Task.CompletedTask;
        }
    }
}