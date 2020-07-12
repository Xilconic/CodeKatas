using System;

namespace KarateChop_V1_Tests
{
    public class ArrayChopper
    {
        private const int elementNotInArrayReturnValue = -1;

        public int Chop(int number, int[] numbers)
        {
            if(numbers is null) throw new ArgumentNullException(nameof(numbers));

            if (numbers.Length == 0) return elementNotInArrayReturnValue;
            return numbers[0] == number ? 0 : elementNotInArrayReturnValue;
        }
    }
}