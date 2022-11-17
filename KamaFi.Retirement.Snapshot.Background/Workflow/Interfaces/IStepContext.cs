namespace KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces
{
    public interface IStepContext
    {
        public void IncrementCounter(int n);
        public void DecrementCounter(int n);
        public int GetCounter();
    }
}
