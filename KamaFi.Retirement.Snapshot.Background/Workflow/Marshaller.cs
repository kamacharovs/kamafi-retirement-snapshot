using KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces;
using KamaFi.Retirement.Snapshot.Data.Options;
using Microsoft.Extensions.Options;

namespace KamaFi.Retirement.Snapshot.Background.Workflow
{
    public class Marshaller : BackgroundService
    {
        private readonly ILogger<Marshaller> _logger;
        private readonly IEnumerable<IStep> _steps;
        private readonly IStepContext _stepContext;
        private readonly TimeSpan _period;

        public Marshaller(
            ILogger<Marshaller> logger,
            IEnumerable<IStep> steps,
            IStepContext stepContext,
            IOptions<BackgroundServiceOptions> options)
        {
            _logger = logger;
            _steps = steps;
            _stepContext = stepContext;
            _period = TimeSpan.FromSeconds(options.Value.Period);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    foreach (var step in _steps)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        
                        await step.ExecuteAsync(_stepContext, cancellationToken);
                    }

                    await Task.Delay(_period, cancellationToken);
                }
                catch (OperationCanceledException oce)
                {
                    _logger.LogInformation(oce, "Operation was cancelled");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Failure during Marshaller's execution");
                }
            }
        }
    }
}
