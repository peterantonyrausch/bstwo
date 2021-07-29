using BS2.Foundation.Operations.Async;
using BS2.Foundation.Validations;
using System.Threading.Tasks;

namespace Sample.Business.Pagamentos.AddTwoStrings
{
    public class AddTwoStringsOperationValidation : InOutAsyncOperation<AddTwoStringsInput, AddTwoStringsOutput>
    {
        public override Task ExecuteAsync(AddTwoStringsInput input)
        {
            AddValidations(
                Validates.ThatMembers()
                    .IsNotNullOrWhiteSpace(input.First, "Please enter the first value", "First")
                    .IsNotNullOrWhiteSpace(input.Second, "Please enter the second value", "Second")
                    .IsTrue(decimal.TryParse(input.First, out var first), "First value is not a valid decimal and will be considered zero.", "First")
                    .IsTrue(decimal.TryParse(input.Second, out var second), "Second value is not a valid decimal and will be considered zero.", "Second")
                    .IsTrue(first != second, "The first and second values must be different.", "First", "Second")
            );

            return Result(first + second);
        }

        private Task Result(decimal result)
        {
            if (HasErrors)
            {
                Failed();
                return Task.CompletedTask;
            }

            Succeeded(new AddTwoStringsOutput(result));
            return Task.CompletedTask;
        }
    }
}