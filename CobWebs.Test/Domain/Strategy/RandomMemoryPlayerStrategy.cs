using System;
using System.Collections.Generic;
using System.Linq;
using CobWebs.Test.Abstraction;

namespace CobWebs.Test.Domain.Strategy
{

    public class RandomMemoryPlayerStrategy : RandomPlayerStrategy
    {
        private readonly HashSet<int> _history = new HashSet<int>();
        public RandomMemoryPlayerStrategy(BasketGameConfig config) : base(config)
        {
        }

        protected override int OnGetAnswer(BasketPlayerContext spec)
        {
            int weight;
            bool isNotExists;
            do
            {
                weight = base.OnGetAnswer(spec);
                isNotExists = !_history.Contains(weight);
            }
            while (!isNotExists);

            _history.Add(weight);

            return weight;
        }
    }
}