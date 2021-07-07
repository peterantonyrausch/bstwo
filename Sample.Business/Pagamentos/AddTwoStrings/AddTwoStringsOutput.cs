using BS2.Foundation.Operations;

namespace Sample.Business.Pagamentos.AddTwoStrings
{
    public class AddTwoStringsOutput : IOperationOutput
    {
        public decimal Result { get; set; }

        public AddTwoStringsOutput(decimal result)
        {
            Result = result;
        }
    }
}