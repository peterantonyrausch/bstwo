using BS2.Foundation.Operations.Async;
using BS2.Foundation.Validations;
using System.Threading.Tasks;

namespace Sample.Business.Pagamentos.AddTwoStrings
{
    public class AddTwoDifferentStringsOperation : InOutAsyncOperation<AddTwoStringsInput, AddTwoStringsOutput>
    {
        public override Task ExecuteAsync(AddTwoStringsInput input)
        {
            AddValidations(
                Validates.ThatMembers()
                    .IsNotNullOrWhiteSpace(input.First, "Please enter the first value", "First")
                    .IsNotNullOrWhiteSpace(input.Second, "Please enter the second value", "Second")
            );

            if (!decimal.TryParse(input.First, out var first))
            {
                AddWarning(nameof(AddTwoStringsInput.First), "First value is not a valid decimal and will be considered zero.");
            }

            if (!decimal.TryParse(input.Second, out var second))
            {
                AddWarning(nameof(AddTwoStringsInput.Second), "Second value is not a valid decimal and will be considered zero.");
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