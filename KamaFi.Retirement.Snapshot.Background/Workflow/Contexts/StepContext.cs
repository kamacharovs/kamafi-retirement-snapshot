using KamaFi.Retirement.Snapshot.Background.Workflow.Interfaces;

namespace KamaFi.Retirement.Snapshot.Background.Workflow.Contexts
{
    public class StepContext : IStepContext
    {
        private int Counter;

        public StepContext()
        {
            Counter = 0;
        }

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
