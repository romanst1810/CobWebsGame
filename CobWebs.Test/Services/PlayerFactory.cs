using System;
using CobWebs.Test.Domain;
using CobWebs.Test.Domain.Strategy;

namespace CobWebs.Test.Abstraction
{
    public class PlayerFactory: IPlayerFactory
    {
       public IPlayer Create(BasketPlayerSpecification spec, BasketGameConfig config)
        {
            IPlayerStrategy strategy;

            switch (spec.StrategyType)
            {
                case PlayerStrategyType.Random:
                    strategy = new RandomPlayerStrategy(config);
                    break;

                case PlayerStrategyType.Memory:
                    strategy = new RandomMemoryPlayerStrategy(config);
                    break;

                case PlayerStrategyType.Thorough:
                    strategy = new ThoroughPlayerStrategy(config);
                    break;

                case PlayerStrategyType.Cheater:
                    strategy = new CheaterPlayerStrategy(config);
                    break;

                case PlayerStrategyType.ThoroughCheater:
                    strategy = new ThoroughPlayerCheaterStrategy(config);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(spec.StrategyType));
            }

            return new BasketGamePlayer(strategy, spec.PlayerName);
        }
    }
}