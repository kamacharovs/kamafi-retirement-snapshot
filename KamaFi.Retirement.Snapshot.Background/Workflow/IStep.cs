namespace KamaFi.Retirement.Snapshot.Background.Workflow
{
    public interface IStep
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
