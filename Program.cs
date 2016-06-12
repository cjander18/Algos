using System;
using System.Collections.Generic;

namespace Algorithms

{

    class Program

    {

        static void Main(string[] args)

        {

            InsertionSort insertSort;
            MergeSort mergeSort;

            // Wait for user to hit a key to continue
            Console.WriteLine("Press 1 for Insertion Sort, 2 for MergeSort, and 3 to exit:");

            string input = Console.ReadLine();

            if (Convert.ToInt32(input) == 1)

            {

                insertSort = new InsertionSort();

                // Write the random array to the console
                Console.WriteLine("Random Array:");
                WriteArrayToConsole<int>(insertSort.intArrRandom);
                
                // Sort the array
                insertSort.SortArray();

                // Write the sorted array to the console
                Console.WriteLine("Sorted Array:");
                WriteArrayToConsole<int>(insertSort.intArrRandom);

            }

            else if (Convert.ToInt32(input) == 2)

            {

                mergeSort = new MergeSort();

                // Write the random array to the console
                Console.WriteLine("Random Array:");
                WriteArrayToConsole<int>(mergeSort.intArrRandom);
                
                // Sort the array
                mergeSort.SortArray();

                // Write the sorted array to the console
                Console.WriteLine("Sorted Array:");
                WriteArrayToConsole<int>(mergeSort.intArrRandom);

            }

            else

            {

                // exit
                return;

            }

            // Wait for user to hit a key to continue
            Console.WriteLine("Press enter to close this window.");

            Console.ReadLine();
            
        }

        /// <summary>
        /// Write a generic object array to the console, this lets us handle
        /// generic string/int/etc... array objects
        /// This works because all basic arrays that have a lower bound of zero 
        /// leverage the IList<T> interface.
        /// </summary>
        /// <param name="genericArray"></param>
        public static void WriteArrayToConsole<T> (IList<T> genericArray)

        {

            // for each object in the generic array
            foreach (object intValue in genericArray)

            {

                // write it's contents to the console
                Console.WriteLine(intValue);

            }
            
        }

    }

}
