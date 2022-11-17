namespace KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces
{
    public interface IStep
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
