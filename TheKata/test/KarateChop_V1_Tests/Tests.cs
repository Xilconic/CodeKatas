using FluentAssertions;
using System;
using Xunit;

namespace KarateChop_V1_Tests
{
    public class Tests
    {
        private ArrayChopper chopper;

        public Tests()
        {
            chopper = new ArrayChopper();
        }

        [Fact]
        public void GivenCollectionOfNumberNull_WhenChopping_ThrowArgumentNullException()
        {
            Action call = () => chopper.Chop(default, null);
            call.Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("numbers");
        }

        [Fact]
        public void GivenEmptyCollectionOfNumbers_WhenChopping_AlwaysReturnMinusOne()
        {
            var result = chopper.Chop(default, Array.Empty<int>());
            result.Should().Be(-1);
        }

        [Fact]
        public void GivenArrayWithOneElement_WhenChoppingForThatElement_AlwaysReturnZero()
        {
            var element = 1;
            var result = chopper.Chop(element, new[] { element });
            result.Should().Be(0);
        }

        [Theory]
        [InlineData(new[] { 2 })]
        [InlineData(new[] { 2, 3})]
        public void GivenArrayOfAnySize_WhenChoppingForNonElement_AlwaysReturnMinusOne(
            int[] numbers)
        {
            var result = chopper.Chop(1, numbers);
            result.Should().Be(-1);
        }
    }
}
