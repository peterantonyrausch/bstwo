using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace PerformanceTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner
                .Run<Startup>(
                    ManualConfig
                        .Create(DefaultConfig.Instance)
                        //.AddJob(Job.ShortRun.WithRuntime(ClrRuntime.Net48))
                        .AddJob(Job.ShortRun.WithRuntime(CoreRuntime.Core31))
                );
        }
    }
}