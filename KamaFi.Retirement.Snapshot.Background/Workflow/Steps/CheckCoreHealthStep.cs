using KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces;
using KamaFi.Retirement.Snapshot.Data.Options;
using Microsoft.Extensions.Options;

namespace KamaFi.Retirement.Snapshot.Background.Workflow.Steps
{
    public class CheckCoreHealthStep : IStep
    {
        private readonly BackgroundServiceApiOptions _options;

        public CheckCoreHealthStep(IOptions<BackgroundServiceApiOptions> options)
        {
            _options = options.Value;
        }

        public async Task ExecuteAsync(IStepContext context, CancellationToken cancellationToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_options.BaseUrl!);
                var response = await httpClient.GetAsync(_options.Endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    Console.WriteLine($"Core is {responseString}");
                    context.SetIsCoreHealthy(true);
                }
                else
                {
                    Console.WriteLine("Something unexpected happened. Core is not reachable");
                    context.SetIsCoreHealthy(false);
                }
            }          
        }
    }
}
