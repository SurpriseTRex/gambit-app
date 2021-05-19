using System;

namespace GambitApp.Conditionals
{
    public static class Comparators
    {
        public static Func<int, int, bool>
            IsUnder = (a, b) => a < b,
            IsUnderOrEqual = (a, b) => a <= b,
            IsOver = (a, b) => a > b,
            IsOverOrEqual = (a, b) => a >= b,
            IsEqual = (a, b) => a == b;
    }
}