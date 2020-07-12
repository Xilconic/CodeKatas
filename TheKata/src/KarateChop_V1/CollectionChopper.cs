using System;
using System.Collections.Generic;

namespace KarateChop_V1_Tests
{
    public class CollectionChopper
    {
        private const int elementNotInArrayReturnValue = -1;
        private const int comparisonEqualsToken = 0;

        public int Chop(int target, IReadOnlyList<int> numbers)
        {
            if (numbers is null) throw new ArgumentNullException(nameof(numbers));

            var window = CollectionSearchWindow.FromFullArrayScope(numbers);

            while (true)
            {
                var index = window.GetNewSearchIndex();
                if (window.IndexInsideSearchWindow(index))
                {
                    var compareResult = numbers[index].CompareTo(target);
                    if (compareResult == comparisonEqualsToken)
                    {
                        return index;
                    }
                    else if (compareResult > comparisonEqualsToken)
                    {
                        window.AdjustUpperBoundOneBelow(index);
                    }
                    else
                    {
                        window.AdjustLowerBoundToOneAbove(index);
                    }
                }
                else
                {
                    return elementNotInArrayReturnValue;
                }
            }
        }

        private class CollectionSearchWindow
        {
            public int LowerBoundIndex { get; private set; }
            public int UpperBoundIndex { get; private set; }

            internal static CollectionSearchWindow FromFullArrayScope(IReadOnlyList<int> collection)
            {
                return new CollectionSearchWindow
                {
                    LowerBoundIndex = 0,
                    UpperBoundIndex = collection.Count - 1
                };
            }

            internal void AdjustLowerBoundToOneAbove(int index)
            {
                LowerBoundIndex = index + 1;
            }

            internal void AdjustUpperBoundOneBelow(int index)
            {
                UpperBoundIndex = index - 1;
            }

            internal int GetNewSearchIndex()
            {
                return (LowerBoundIndex + UpperBoundIndex) / 2;
            }

            internal bool IndexInsideSearchWindow(int index)
            {
                return LowerBoundIndex <= index && index <= UpperBoundIndex;
            }
        }
    }
}