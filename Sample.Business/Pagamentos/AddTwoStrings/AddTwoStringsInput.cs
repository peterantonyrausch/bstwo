using BS2.Foundation.Operations;

namespace Sample.Business.Pagamentos.AddTwoStrings
{
    public class AddTwoStringsInput : IOperationInput
    {
        public string First { get; set; }
        public string Second { get; set; }
    }
}