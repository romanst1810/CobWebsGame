using System.Collections.Generic;

namespace CobWebs.Test.Domain
{
    public class BasketPlayerContext
    {
        public IReadOnlyCollection<int> History { get; private set; }

        public BasketPlayerContext(IEnumerable<int> history)
        {
            History = new HashSet<int>(history);
        }
    }
}