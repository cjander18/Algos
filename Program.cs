using System;
using System.Collections.Generic;

namespace Algorithms

{

    class Program

    {

        static void Main(string[] args)

        {

            string strDirections = "\r\nType 'exit' at any time to close the program.\r\n";
            string strUserInput = "";
            int iSelectedAlgorithm;
            bool bValidNumber;

            // Will hold the algorithm the user chooses to use
            ISort sortSelected;

            InsertionSort insertSort = new InsertionSort();
            MergeSort mergeSort = new MergeSort();

            List<ISort> lstr_SortingStrategies = new List<ISort>();

            // Add the algorithms to the list
            lstr_SortingStrategies.Add(insertSort);
            lstr_SortingStrategies.Add(mergeSort);

            // Create the directions for them
            foreach(ISort algorithm in lstr_SortingStrategies)

            {

                strDirections += string.Format("Press {0} for {1}.\r\n"
                    , lstr_SortingStrategies.IndexOf(algorithm)
                    , algorithm.Name);

            }

            // Do the following at least once
            do

            {

                // Wait for user to hit a key to continue
                Console.WriteLine(strDirections);

                strUserInput = Console.ReadLine();

                bValidNumber = Int32.TryParse(strUserInput, out iSelectedAlgorithm);

                // If it's a valid number, is greater than or equal to zero, and less than the total number of strategies
                if (bValidNumber &&
                   iSelectedAlgorithm >= 0 &&
                   iSelectedAlgorithm < lstr_SortingStrategies.Count)

                {

                    // Get the selected algorithm
                    sortSelected = lstr_SortingStrategies[Convert.ToInt32(iSelectedAlgorithm)];

                    // Create the random values
                    sortSelected.InitalizeArray();

                    // Write the random array to the console
                    Console.WriteLine("\r\nRandom Array:");
                    WriteArrayToConsole<int>(sortSelected.intArrRandom);

                    // Sort the array
                    sortSelected.SortArray();

                    // Write the sorted array to the console
                    Console.WriteLine("\r\nSorted Array:");
                    WriteArrayToConsole<int>(sortSelected.intArrRandom);

                }

            }

            // While the user hasn't entered exit
            while (!String.Equals(strUserInput, "exit", StringComparison.OrdinalIgnoreCase));
            
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
            for (int index = 0; index < genericArray.Count; index++)

            {

                // If it's not the last item, or the only item, in the array then add a comma
                if (index < genericArray.Count - 1 && 
                    genericArray.Count > 1)

                    Console.Write(string.Format("{0},", genericArray[index]));

                // Otherwise it's either alone or at the end, so it needs no trailing comma
                else

                    Console.Write(genericArray[index]);

            }
            
        }

    }

}
