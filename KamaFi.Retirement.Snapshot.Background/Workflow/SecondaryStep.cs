namespace KamaFi.Retirement.Snapshot.Background.Workflow
{
    public class SecondaryStep : IStep
    {
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Hello from {nameof(SecondaryStep)}");
        }
    }
}
