using BenchmarkDotNet.Attributes;
using Sample.Business.Pagamentos.AddTwoStrings;

namespace PerformanceTests
{
    [MemoryDiagnoser]
    [DisassemblyDiagnoser]
    [ThreadingDiagnoser]
    public class Startup
    {
        private int _executionTimes;

        public Startup()
        {
            _executionTimes = 10;
        }

        public Startup(int executionTimes)
        {
            _executionTimes = executionTimes;
        }

        [Benchmark(Baseline = true)]
        public void WithDefault()
        {
            for (int i = 0; i < _executionTimes; i++)
            {
                TestWithDefault("", "");
                TestWithDefault("a", "b");
                TestWithDefault("1", "2");
                TestWithDefault("1.1", "2.2");
                TestWithDefault("1,1", "2,2");
            }
        }

        [Benchmark]
        public void WithValidations()
        {
            for (int i = 0; i < _executionTimes; i++)
            {
                TestWithValidations("", "");
                TestWithValidations("a", "b");
                TestWithValidations("1", "2");
                TestWithValidations("1.1", "2.2");
                TestWithValidations("1,1", "2,2");
            }
        }

        [Benchmark]
        public void WithException()
        {
            for (int i = 0; i < _executionTimes; i++)
            {
                TestWithException("", "");
                TestWithException("a", "b");
                TestWithException("1", "2");
                TestWithException("1.1", "2.2");
                TestWithException("1,1", "2,2");
            }
        }

        private void TestWithDefault(string first, string second)
        {
            try
            {
                var registerOperation = new AddTwoStringsOperation();
                registerOperation
                    .ExecuteAsync(new AddTwoStringsInput { First = first, Second = second })
                    .GetAwaiter()
                    .GetResult();
            }
            catch
            {
            }
        }

        private void TestWithValidations(string first, string second)
        {
            try
            {
                var registerOperation = new AddTwoStringsOperationValidation();
                registerOperation
                    .ExecuteAsync(new AddTwoStringsInput { First = first, Second = second })
                    .GetAwaiter()
                    .GetResult();
            }
            catch
            {
            }
        }

        private void TestWithException(string first, string second)
        {
            try
            {
                var registerOperation = new AddTwoStringsOperationException();
                registerOperation
                    .ExecuteAsync(new AddTwoStringsInput { First = first, Second = second })
                    .GetAwaiter()
                    .GetResult();
            }
            catch
            {
            }
        }
    }
}