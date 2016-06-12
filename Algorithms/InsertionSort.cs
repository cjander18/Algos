using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms

{

    class InsertionSort

    {

        private Random rand = new Random();

        public int[] intArrRandom { get; set; }

        // Initalize the integer array with random values
        public InsertionSort()

        {

            // Create an array with a random length
            intArrRandom = new int[rand.Next(0, 100)];

            // For each place in the array
            for (int i = 0; i < intArrRandom.Count(); i++)

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
