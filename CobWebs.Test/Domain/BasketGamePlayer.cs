using System;
using CobWebs.Test.Abstraction;

namespace CobWebs.Test.Domain
{
    public class BasketGamePlayer: IPlayer
    {
        private readonly IPlayerStrategy _strategy;

        public string Name { get; private set; }

        public BasketGamePlayer(IPlayerStrategy strategy, string name)
        {
            this._strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            this.Name = name;
        }

        public int GetAnswer(BasketPlayerContext spec)
        {
            return _strategy.GetAnswer(spec);
        }


        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}";
        }
    }
}