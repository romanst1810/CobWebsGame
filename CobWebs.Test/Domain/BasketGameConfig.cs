using System;

namespace CobWebs.Test.Domain
{
    public class BasketGameConfig
    {
        public int MinWeight { get; set; } = 40;
        public int MaxWeight { get; set; } = 140;
        public int MaxAttempts { get; set; } = 100;
        public TimeSpan MaxTime { get; set; } = TimeSpan.FromMilliseconds(1500);
    }
}