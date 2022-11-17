using KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces;

namespace KamaFi.Retirement.Snapshot.Background.Workflow
{
    public class InitializationStep : IStep
    {
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => Console.WriteLine($"Hello from {nameof(InitializationStep)}"));
        }
    }
}
