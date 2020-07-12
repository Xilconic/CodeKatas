using System;

namespace KarateChop_V1_Tests
{
    public class ArrayChopper
    {
        private const int elementNotInArrayReturnValue = -1;

        public int Chop(int target, int[] numbers)
        {
            if (numbers is null) throw new ArgumentNullException(nameof(numbers));

            if (numbers.Length == 0) return elementNotInArrayReturnValue;

            var index = numbers.Length / 2;
            if(numbers[index] == target)
            {
                return index;
            }
            else
            {
                index = numbers[index] > target ? index - 1 : index + 1;
                if (IndexInsideBoundsOfArray(index, numbers))
                {
                    return elementNotInArrayReturnValue;
                }
                return numbers[index] == target ? index : elementNotInArrayReturnValue;
            }
        }

        private bool IndexInsideBoundsOfArray(int index, int[] numbers)
        {
            return index > numbers.Length - 1 || index < 0;
        }
    }
}