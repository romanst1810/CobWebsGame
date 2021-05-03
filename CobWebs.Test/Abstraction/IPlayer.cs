using CobWebs.Test.Domain;

namespace CobWebs.Test.Abstraction
{
    public interface IPlayer
    {
        public string Name { get; }
        int GetAnswer(BasketPlayerContext spec);
    }
}
