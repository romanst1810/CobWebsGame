using System.Diagnostics;
using CobWebs.Test.Domain;

namespace CobWebs.Test.Abstraction
{
    public enum PlayerStrategyType
    {
        Random,
        Memory,
        Thorough,
        Cheater,
        ThoroughCheater
    }

    public interface IPlayerFactory
    {
        IPlayer Create(BasketPlayerSpecification spec, BasketGameConfig config);
    }
}