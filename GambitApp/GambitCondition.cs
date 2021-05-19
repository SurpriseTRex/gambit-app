using System;

namespace GambitApp
{
    public class GambitCondition
    {
        public GambitCondition(
            Func<Character, int> comparisonProperty,
            Func<int, int, bool> comparisonFunc,
            int comparisonValue)
        {
            ComparisonProperty = comparisonProperty;
            ComparisonFunc = comparisonFunc;
            ComparisonValue = comparisonValue;
        }
        
        public Func<Character, int> ComparisonProperty { get; }
        public int ComparisonValue { get;} = 30;
        public Func<int, int, bool> ComparisonFunc { get; } = (a, b) => a < b;

        public Func<Character, bool> Compose => target 
            => ComparisonFunc.Invoke(ComparisonProperty.Invoke(target), ComparisonValue);
    }
}