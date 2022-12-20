using KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces;

namespace KamaFi.Retirement.Snapshot.Background.Workflow.Steps
{
    public class InitializationStep : IStep
    {
        public async Task ExecuteAsync(IStepContext context, CancellationToken cancellationToken)
        {
            context.IncrementCounter(1);

            await Task.Run(() => Console.WriteLine($"Hello from {nameof(InitializationStep)}. Counter is {context.GetCounter()}"));
        }
    }
}
