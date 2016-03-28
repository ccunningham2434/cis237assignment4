using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        // >Temporary array used for merging.
        private static IComparable[] tempArray;

        
        public static void Sort(IComparable[] array)
        {
            tempArray = new IComparable[array.Length];

            // >Pass in the full array for sorting.
            Sort(array, 0, array.Length -1);
        }

        // >Recursive method.
        private static void Sort(IComparable[] array, int low, int high) 
        {
            // >Base case.
            if (high <= low)
            {
                return;
            }

            // >Find the mid point of the passed in array.
            int mid = low + (high - low) / 2;//(high + low) / 2;

            // >Split the array into 2 smaller arrays.
            //
            // >Pass in the first half of the array.
            Sort(array, low, mid);
            // >Pass in the second half of the array.
            Sort(array, mid + 1, high);

            // >Merge the two halves together.
            Merge(array, low, mid, high);







            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(((IDroid)array[i]).TotalCost);
            }
            Console.WriteLine("---------------------------");
        }

        // >Merge two sides of the array.
        private static void Merge(IComparable[] array, int low, int mid, int high)
        {
            int leftPointer = low;
            int rightPointer = mid + 1;

            // >Copy the passed in array values to the temporary array.
            for (int k = low; k <= high; k++ )
            {
                tempArray[k] = array[k];
            }

            // >Compare the values of the passed in array.
            for (int k = low; k <= high; k++)
            {
                // >If the left pointer is greater than the middle of the array, throw the rest of the right side into the array.
                if (leftPointer > mid)
                {
                    array[k] = tempArray[rightPointer++];
                }
                    // >If the right pointer is greater than the max of the array, throw the rest of the left side into the array.
                else if (rightPointer > high)
                {
                    array[k] = tempArray[leftPointer++];
                }
                    // >If the value of the right pointer less than the value of the left pointer, put the right pointer into the array.
                else if (tempArray[rightPointer].CompareTo(tempArray[leftPointer]) < 0)
                {
                    array[k] = tempArray[rightPointer++];
                }
                // >If the value of the left pointer greater than or equal to the value of the right pointer, put the left pointer into the array.
                else 
                {
                    array[k] = tempArray[leftPointer++];
                }
            }

        }


    }
}
