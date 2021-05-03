using System;
using CobWebs.Test.Abstraction;

namespace CobWebs.Test.Domain.Strategy
{
    public class ThoroughPlayerStrategy : PlayerStrategyBase
    {
        private int? lastWeight;

        public ThoroughPlayerStrategy(BasketGameConfig config) : base(config)
        {
        }

        protected override int OnGetAnswer(BasketPlayerContext spec)
        {
            if (!lastWeight.HasValue)
            {
                lastWeight = _config.MinWeight;

                return lastWeight.Value;
            }

            lastWeight++;

            return lastWeight.Value >= _config.MaxWeight ? 
                _config.MaxWeight : 
                lastWeight.Value;
        }
    }
}