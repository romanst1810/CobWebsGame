using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using CobWebs.Test.Abstraction;
using CobWebs.Test.Domain;

namespace CobWebs.Test
{
    public class BasketGame: IBasketGame
    {
        private readonly BasketGameConfig _config;
        private readonly IPlayerFactory _playerFactory;

        public BasketGame(IPlayerFactory playerFactory, BasketGameConfig config)
        {
            this._playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(config));
            this._config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void Start(int basketWeight, IEnumerable<BasketPlayerSpecification> items)
        {
            var history = new List<int>();
            var playersSpec = (items ?? new BasketPlayerSpecification[0]).ToArray();

            if (playersSpec.Length < 3 || playersSpec.Length > 8)
            {
                throw new ArgumentException(nameof(items));
            }

            var playerStates = playersSpec
                .Select(x => _playerFactory.Create(x, _config))
                .Select(x=> new BasketPlayerState{ Player = x})
                .ToArray();

            var context = new BasketGameContext
            {
                RealBasketWeight = basketWeight,
                Players = playerStates
            };

            BasketPlayerState winnerState = null;
            var timer = context.Timer;

            context.Timer.Start();

            do
            {
                var hasWinnerPlayer = TryGetWinner(context, out winnerState);

                if (hasWinnerPlayer)
                {
                    break;
                }

                Console.WriteLine("Attempts: {0}", context.Attempts);

            } while (context.Attempts < _config.MaxAttempts && 
                     timer.Elapsed < _config.MaxTime);

            timer.Stop();

            PrintResult(context, winnerState);
        }

        private static bool TryGetWinner(BasketGameContext context, out BasketPlayerState winnerState)
        {
            winnerState = null;

            foreach (var state in context.Players)
            {

                Console.WriteLine("Player: {0}", state.Player.Name);
                Thread.Sleep(state.Timeout);

                var playerContext = new BasketPlayerContext(context.Answers);
                var weight = state.Player.GetAnswer(playerContext);

                state.Answers.Add(weight);
                state.Timeout = TimeSpan.FromMilliseconds(Math.Abs(context.RealBasketWeight - weight));
                state.Attempts++;

                context.Answers.Add(weight);
                context.Attempts++;

                if (weight == context.RealBasketWeight)
                {
                    winnerState = state;
                    break;
                }
            }

            return winnerState != null;
        }

        private static void PrintResult(
            BasketGameContext context,
            BasketPlayerState winnerState)
        {
            var timer = context.Timer;

            Console.WriteLine($"The real weight of the basket: {context.RealBasketWeight}.");
            Console.WriteLine($"Game Attempts: [{context.Attempts}] milliseconds.");
            Console.WriteLine($"Game Elapsed: [{timer.ElapsedMilliseconds}] milliseconds.");
            if (winnerState != null)
            {
                Console.WriteLine(
                    $"Winner name [{winnerState.Player}] total amount of attempts [{winnerState.Attempts}].");
                return;
            }

            var closestWinner = context.Players
                .Select(x => new
                {
                    State = x,
                    ClosestValue = x.Answers
                        .Select(w => new
                        {
                            Distance = Math.Abs(w - context.RealBasketWeight),
                            Weight = w
                        })
                        .OrderBy(d => d.Distance).First()

                }).First();

            Console.WriteLine(
                $"Winner name [{closestWinner.State.Player.Name}], " +
                $"his guess [{closestWinner.ClosestValue.Weight}], " +
                $"his distance [{closestWinner.ClosestValue.Distance}], " +
                $"attempts [{closestWinner.State.Attempts}].");
        }
    }
}
