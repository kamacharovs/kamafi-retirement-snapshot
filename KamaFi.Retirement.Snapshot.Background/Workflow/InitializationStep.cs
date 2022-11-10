using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaFi.Retirement.Snapshot.Background.Workflow
{
    public class InitializationStep : IStep
    {
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Hello from {nameof(InitializationStep)}");
        }
    }
}
