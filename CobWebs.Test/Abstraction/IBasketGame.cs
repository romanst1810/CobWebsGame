using System;
using System.Collections.Generic;
using System.Text;
using CobWebs.Test.Domain;

namespace CobWebs.Test.Abstraction
{
    public interface IBasketGame
    {
        void Start(int basketWeight, IEnumerable<BasketPlayerSpecification> players);
    }
}
