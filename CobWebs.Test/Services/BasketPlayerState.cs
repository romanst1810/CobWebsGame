using System;
using System.Collections.Generic;
using CobWebs.Test.Abstraction;

namespace CobWebs.Test
{
    public class BasketPlayerState
    {
        public IPlayer Player { get; set; }

        public int Attempts { get; set; }

        public TimeSpan Timeout = TimeSpan.Zero;

        public ICollection<int> Answers { get; set; } = new List<int>();
    }
}