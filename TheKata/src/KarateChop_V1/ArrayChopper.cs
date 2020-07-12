using System;

namespace KarateChop_V1_Tests
{
    public class ArrayChopper
    {
        public int Chop(int number, int[] numbers)
        {
            if(numbers is null) throw new ArgumentNullException(nameof(numbers));

            return -1;
        }
    }
}