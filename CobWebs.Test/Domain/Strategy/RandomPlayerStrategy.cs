using System;
using CobWebs.Test.Abstraction;

namespace CobWebs.Test.Domain.Strategy
{
    public class RandomPlayerStrategy : PlayerStrategyBase
    {
        protected readonly Random _random = new Random();
        public RandomPlayerStrategy(BasketGameConfig config) : base(config)
        {
            
        }

        protected override int OnGetAnswer(BasketPlayerContext spec)
        {
            return _random.Next(_config.MinWeight, _config.MaxWeight);
        }
    }
}