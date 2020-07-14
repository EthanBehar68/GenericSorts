using EthanBehar.GenericSorts.GenericMergeSort;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GenericMergeSortTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 2 })]
        public void MergeSort_LengthOfOne_ReturnsSameArray(int[] arrayToSort)
        {
            var firstElement = arrayToSort[0];

            arrayToSort = GenericMergeSort.MergeSort(arrayToSort);

            Assert.AreEqual(firstElement, arrayToSort[0]);
        }

        // Test won't compile b/c FakeData is NOT comparable - this is good
        //[Test]
        //public void MergeSort_ArrayIsntIComparable_ThrowsException()
        //{
        //    var fakeList = new List<FakeData>()
        //    {
        //        new FakeData
        //        {
        //            data = 5
        //        },
        //        new FakeData
        //        {
        //            data = 6
        //        },
        //        new FakeData
        //        {
        //            data = 4
        //        }
        //    };

        //    Assert.Throws<ArgumentException>(
        //        () =>
        //        {
        //            GenericMergeSort.MergeSort(fakeList.ToArray(), EthanBehar.GenericSorts.SortingOption.Ascending);
        //        });
        //}

        [Test]
        public void MergeSort_ArrayIsComparable_SortsArray()
        {
            var fakeArray = new List<FakeDataComparable>()
            {
                new FakeDataComparable
                {
                    data = 7
                },
                new FakeDataComparable
                {
                    data = 100
                },
                new FakeDataComparable
                {
                    data = 5
                },
                new FakeDataComparable
                {
                    data = 6
                },
                new FakeDataComparable
                {
                    data = 4
                },
                new FakeDataComparable
                {
                    data = 1
                },
                new FakeDataComparable
                {
                    data = 50
                }
            }.ToArray();

            fakeArray = GenericMergeSort.MergeSort(fakeArray);

            Assert.AreEqual(1, fakeArray[0].data);
            Assert.AreEqual(4, fakeArray[1].data);
            Assert.AreEqual(5, fakeArray[2].data);
            Assert.AreEqual(6, fakeArray[3].data);
            Assert.AreEqual(7, fakeArray[4].data);
            Assert.AreEqual(50, fakeArray[5].data);
            Assert.AreEqual(100, fakeArray[6].data);
        }
    }
}