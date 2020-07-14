using System;

namespace EthanBehar.GenericSorts.GenericMergeSort
{
    public static class GenericMergeSort
    {
        public static SortingOption sortOption { get; set; } = SortingOption.Ascending;

        // TODO implement SortingOptions

        public static T[] MergeSort<T>(T[] arrayToSort, SortingOption sortOption = SortingOption.Ascending) where T : IComparable
        {
            // Already sorted if 1 or less element
            if (arrayToSort.Length <= 1)
            {
                return arrayToSort;
            }

            if(arrayToSort[0] !is IComparable)
            {
                throw new InvalidOperationException("Generic merge requires objects to implement IComparable interface.");
            }

            var auxiliaryArray = (T[])arrayToSort.Clone();

            // Start recursion
            Console.WriteLine();
            MergeSortHelper(arrayToSort, 0, arrayToSort.Length - 1, auxiliaryArray);

            return arrayToSort;
        }

        private static void MergeSortHelper<T>(T[] mainArray, int startIndex, int endIndex, T[] auxiliaryArray) where T : IComparable
        {
            // Base case finished recursive merge sort.
            if (startIndex == endIndex)
            {
                return;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            // "Divide"
            // Swapping arrays is key to making algorithm work.
            MergeSortHelper(auxiliaryArray, startIndex, middleIndex, mainArray);
            MergeSortHelper(mainArray, middleIndex + 1 , endIndex, auxiliaryArray);

            // "Conquer"
            // Actual sorting done in this method
            DoMergeSort(mainArray, startIndex, middleIndex, endIndex, auxiliaryArray);
        }


        // Move through both "unsorted array" comparing elements and placing them in sorted order 
        // Used "" b/c we are using the same array, we don't have multiple arrays(exception our auxiliaryArray). 
        // We are tracking portions of the main array using indices This is so Space Complexity can be O(n).
        private static void DoMergeSort<T>(T[] mainArray, int startIndex, int middleIndex, int endIndex, T[] auxiliaryArray) where T : IComparable
        {
            // Initialize indice trackers
            int sortedIndex = startIndex;
            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;

            // While leftIndex and rightIndex are still within bounds
            // Once either is out of bounds we stop
            while (leftIndex <= middleIndex && rightIndex <= endIndex)
            {
                // Left is smaller so put it in sorted portion of mainArray increment left index
                if(auxiliaryArray[leftIndex].CompareTo(auxiliaryArray[rightIndex]) <= 0)
                {
                    mainArray[sortedIndex] = auxiliaryArray[leftIndex];
                    leftIndex++;
                }
                // Right is smaller so put it in sorted portion of mainArray and increment right index
                else
                {
                    mainArray[sortedIndex] = auxiliaryArray[rightIndex];
                    rightIndex++;
                }

                // Increment sortedArray index
                sortedIndex++;
            }

            // Undoubtly one will have remaining elements so check for that
            
            // While left still has remaining elements
            while (leftIndex <= middleIndex)
            {
                // Put them in the sorted portion of mainArray (no check b/c we know right is already sorted within itself)
                mainArray[sortedIndex] = auxiliaryArray[leftIndex];

                // Increment indices as needed
                leftIndex++;
                sortedIndex++;
            }

            // While right still has remaining elements
            while (rightIndex <= endIndex)
            {
                // Put them in the sorted portion of mainArray (no check b/c we know right is already sorted within itself)
                mainArray[sortedIndex] = auxiliaryArray[rightIndex];
                // Increment indices as needed
                rightIndex++;
                sortedIndex++;
            }
        }
    }
}
