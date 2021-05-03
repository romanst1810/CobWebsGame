using System;
using CobWebs.Test.Abstraction;
using CobWebs.Test.Domain;

namespace CobWebs.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerSpecs = new[]
            {
                new BasketPlayerSpecification
                    {PlayerName = "Random Player", StrategyType = PlayerStrategyType.Random},

                new BasketPlayerSpecification
                    {PlayerName = "Memory Player", StrategyType = PlayerStrategyType.Memory},

                new BasketPlayerSpecification
                    {PlayerName = "Thorough Player", StrategyType = PlayerStrategyType.Thorough},

                new BasketPlayerSpecification
                    {PlayerName = "Cheater Player", StrategyType = PlayerStrategyType.Cheater},

                new BasketPlayerSpecification
                    {PlayerName = "ThoroughCheater Player", StrategyType = PlayerStrategyType.ThoroughCheater},
            };

            var basketWeight = 125;
            var config = new BasketGameConfig();
            IPlayerFactory playerFactory = new PlayerFactory();
            
            IBasketGame basketGame = new BasketGame(playerFactory, config);

            basketGame.Start(basketWeight, playerSpecs);

            Console.ReadKey();
        }
    }
}
