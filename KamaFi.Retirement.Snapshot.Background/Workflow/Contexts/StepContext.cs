using KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces;

namespace KamaFi.Retirement.Snapshot.Background.Workflow.Contexts
{
    public class StepContext : IStepContext
    {
        // Core
        private bool _isCoreHealthy { get; set; } = false;

        private int Counter;

        public StepContext()
        {
            Counter = 0;
        }

        // Core
        public void SetIsCoreHealthy(bool health) => _isCoreHealthy = health;
        public bool IsCoreHealthy() => _isCoreHealthy;

        public void IncrementCounter(int n)
        {
            Counter += n;
        }

        public void DecrementCounter(int n)
        {
            Counter -= n;
        }

        public int GetCounter()
        {
           return Counter;
        }
    }
}
