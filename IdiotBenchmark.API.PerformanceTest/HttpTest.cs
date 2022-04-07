using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using NBomber.Plugins.Network.Ping;

namespace IdiotBenchmark.API.PerformanceTest;

public class HttpTest
{
    public static void Run()
    {
        var httpFactory = HttpClientFactory.Create();

        var step = Step.Create("fetch_html_page",
            httpFactory,
            async context =>
            {
                var response = await context.Client.GetAsync("https://nbomber.com", context.CancellationToken);

                return response.IsSuccessStatusCode
                    ? Response.Ok(statusCode: (int) response.StatusCode)
                    : Response.Fail(statusCode: (int) response.StatusCode);
            });

        var scenario = ScenarioBuilder
            .CreateScenario("simple_http", step)
            .WithWarmUpDuration(TimeSpan.FromSeconds(5))
            .WithLoadSimulations(new[]
            {
                Simulation.InjectPerSec(rate: 100, during: TimeSpan.FromSeconds(30))
            });

        var pingPluginConfig = PingPluginConfig.CreateDefault(new[] {"nbomber.com"});
        var pingPlugin = new PingPlugin(pingPluginConfig);

        NBomberRunner
            .RegisterScenarios(scenario)
            .WithWorkerPlugins(pingPlugin)
            .Run();
    }
}