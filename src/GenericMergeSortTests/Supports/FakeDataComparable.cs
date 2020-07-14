using System;
using System.Collections.Generic;
using System.Text;

namespace GenericMergeSortTests
{
    public class FakeDataComparable : IComparable
    {
        public int data { get; set; } = 2;

        public int CompareTo(object obj)
        {
            var inData = (FakeDataComparable)obj;

            if (data < inData.data)
            {
                return 0;
            }
            if (data == inData.data)
            {
                return 1;
            }
            if(data > inData.data)
            {
                return 2;
            }

            throw new ArgumentException();
        }
    }
}
