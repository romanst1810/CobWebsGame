using System;
using System.Linq;
using CobWebs.Test.Abstraction;

namespace CobWebs.Test.Domain.Strategy
{
    public class ThoroughPlayerCheaterStrategy : ThoroughPlayerStrategy
    {
        public ThoroughPlayerCheaterStrategy(BasketGameConfig config) : base(config)
        {
        }

        protected override int OnGetAnswer(BasketPlayerContext spec)
        {
            int weight;
            bool isNotExists;
            do
            {
                weight = base.OnGetAnswer(spec);
                isNotExists = !spec.History.Contains(weight);
            }
            while (!isNotExists);

            return weight;
        }
    }
}