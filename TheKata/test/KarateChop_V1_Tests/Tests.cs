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
    }
}
