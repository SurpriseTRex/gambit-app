using GambitApp.Conditionals;
using Xunit;

namespace GambitApp.Tests
{
    public class ComparatorTests
    {
        [Fact]
        public void Equal()
        {
            var a = 2;
            var b = 2;
            
            var result = Comparators.IsUnderOrEqual.Invoke(a, b);
            
            Assert.True(result);
        }
        
        [Fact]
        public void Over()
        {
            var a = 2;
            var b = 1;

            var result = Comparators.IsOver.Invoke(a, b);
            
            Assert.True(result);
        }
        
        [Fact]
        public void OverOrEqual()
        {
            var a = 3;
            var b = 2;
            var c = 2;

            var underResult = Comparators.IsOverOrEqual.Invoke(a, b);
            var equalResult = Comparators.IsOverOrEqual.Invoke(b, c);
            
            Assert.True(underResult);
            Assert.True(equalResult);
        }
        
        [Fact]
        public void Under()
        {
            var a = 1;
            var b = 2;

            var result = Comparators.IsUnder.Invoke(a, b);
            
            Assert.True(result);
        }
        
        [Fact]
        public void UnderOrEqual()
        {
            var a = 1;
            var b = 2;
            var c = 2;

            var underResult = Comparators.IsUnderOrEqual.Invoke(a, b);
            var equalResult = Comparators.IsUnderOrEqual.Invoke(b, c);
            
            Assert.True(underResult);
            Assert.True(equalResult);
        }
    }
}