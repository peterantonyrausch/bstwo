using System.Threading.Tasks;
using Sample.Business.Pagamentos.AddTwoStrings;

namespace Console.Mobile
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await Test("", "");
            await Test("a", "b");
            await Test("1", "2");
            await Test("1.1", "2.2");
            await Test("1,1", "2,2");
        }

        private static async Task Test(string first, string second)
        {
            var registerOperation = new AddTwoDifferentStringsOperation();
            await registerOperation.ExecuteAsync(new AddTwoStringsInput { First = first, Second = second });

            var toPrint = registerOperation.Match(
                failure => $"Ocorreram {failure.Count} erros no processamento:\r\n{failure}",
                success => $"Operação processada com sucesso!\r\nResultado: {success.Result}"
            );

            AddTwoStringsOutput output = registerOperation;

            System.Console.WriteLine(toPrint);
            System.Console.WriteLine($"Output result value is: {output.Result}");
        }
    }
}