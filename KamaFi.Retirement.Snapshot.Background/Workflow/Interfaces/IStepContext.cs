namespace KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces
{
    public interface IStepContext
    {
        void SetIsCoreHealthy(bool health);
        bool IsCoreHealthy();

        void IncrementCounter(int n);
        void DecrementCounter(int n);
        int GetCounter();
    }
}
