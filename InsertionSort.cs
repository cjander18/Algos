using System;
using System.Linq;

namespace Algorithms

{

    public class InsertionSort : ISort

    {

        public string Name { get; set;}
        public Random rand { get; set; }
        public int[] intArrRandom { get; set; }

        // Initalize the integer array with random values
        public InsertionSort()

        {
            
            Name = "Insertion Sort";

            rand = new Random();
            
        }

        /// <summary>
        /// Initalize the random array
        /// </summary>
        public void InitalizeArray()

        {

            // Create an array with a random length
            intArrRandom = new int[rand.Next(2, 100)];

            // For each place in the array
            for (int i = 0; i < intArrRandom.Length; i++)

            {

                // Put a random number in it
                intArrRandom[i] = rand.Next(0, 100);

            }

        }

        // Sort the array
        public void SortArray()

        {

            // For each place in the array
            for (int intCurrentLocation = 0; intCurrentLocation < intArrRandom.Count(); intCurrentLocation++)

            {

                // Get the value of the current location
                int intCurrentValue = intArrRandom[intCurrentLocation];

                // Get the prior location
                int intPriorLocation = intCurrentLocation - 1;

                // If the prior location is the first or greater positon
                // And the prior location's value is greater than the current value
                while (intPriorLocation >= 0 && intArrRandom[intPriorLocation] > intCurrentValue)

                {

                    // Then we need to move the prior value up one, since it's greater than our current value
                    intArrRandom[intPriorLocation + 1] = intArrRandom[intPriorLocation];

                    // And move back down the list, looking for a value smaller than our current value
                    intPriorLocation = intPriorLocation - 1;

                }

                // Once we've either come to the end of the list or found the current values proper location
                intArrRandom[intPriorLocation + 1] = intCurrentValue;

            }

        }

    }

}
