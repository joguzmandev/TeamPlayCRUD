using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamPlayCRUD.Algorithm
{
    public class AlgorithmFunction
    {
        public Object GetBiggerNumberAndBiggerList(List<int>[] arrayOfListInt)
        {
            List<int> tempList = new List<int>();
            var biggerList = new List<int>();

            foreach (var item in arrayOfListInt)
            {
                item.ForEach(li => tempList.Add(li));
                if (item.Count > biggerList.Count)
                    biggerList = item;
            }
            return new object[] { tempList.Max(), biggerList };
        }

        public List<int> FibonacciSequence(int numGiven)
        {
        
            int toIterate = 5,
                num1 = numGiven - 1, 
                num2 = numGiven, 
                counter = 0;

            List<int> items = new List<int>();

            items.Add(num1);
            items.Add(num2);
            for (int x = 1; x < toIterate; x++)
            {
                counter = num1 + num2;
                items.Add(counter);
                num1 = num2;
                num2 = counter;
            }

            return items
        }
    }
}
