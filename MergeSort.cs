using System;

namespace Algorithms

{

    public class MergeSort

    {

        /// <summary>
        /// A random class variable used to populate the array
        /// </summary>
        private Random rand = new Random();

        /// <summary>
        /// A random array of integers
        /// </summary>
        public int[] intArrRandom { get; set; }

        /// <summary>
        /// Initalize a random array of random size
        /// </summary>
        public MergeSort()

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
        
        /// <summary>
        /// Start sorting the random array
        /// </summary>
        public void SortArray()

        {

            intArrRandom = StartMergeSort(intArrRandom, 0, intArrRandom.Length - 1);

        }

        /// <summary>
        /// Start the merge sort for a given array in a given range from left (iL) to right (iR)
        /// </summary>
        /// <param name="intArrSource"></param>
        /// <param name="iL"></param>
        /// <param name="iR"></param>
        /// <returns></returns>
        private int[] StartMergeSort(int[] intArrSource, int iL, int iR)

        {

            int iM;

            // If the left index is below that of the right
            if (iL < iR)

            {

                // Set the middle, note the usual calculation is (l+r)/2, but this
                // will avoid overflow for large iL and iR
                iM = (iL + iR) / 2;

                // Start sorting this part of the array, looking only from the left to the middle
                intArrSource = StartMergeSort(intArrSource, iL, iM);

                // Start sorting this part of the array, looking only from the middle+1 to the right
                intArrSource = StartMergeSort(intArrSource, iM + 1, iR);

                // sort the array
                intArrSource = Sort(intArrSource, iL, iM, iR);

            }

            return intArrSource;

        }

        /// <summary>
        /// Sort the passed in array from left (iL) to right (iR)
        /// </summary>
        /// <param name="arrMerged"></param>
        /// <param name="iL"></param>
        /// <param name="iM"></param>
        /// <param name="iR"></param>
        /// <returns></returns>
        private int[] Sort(int[] arrMerged, int iL, int iM, int iR)

        {

            int iLeftCounter;
            int iRightCounter;
            int iMergedCounter;

            // The left array will be from the left side, to the middle, plus 1 (so subtracting
            // the left from the middle will give us the difference between the two, and we add
            // one since arrays are zero based.
            int iLeftLength = iM - iL + 1;

            // The right array will be from the middle to the right side (so substracting the
            // middle removes the entire left side
            int iRightLength = iR - iM;

            int[] arrLeft = new int[iLeftLength];
            int[] arrRight = new int[iRightLength];

            // Copy data from the source into the Left and Right arrays
            for(iLeftCounter = 0; iLeftCounter < iLeftLength; iLeftCounter++)

            {

                // Note in the merged array we're looking to go from the start of the left
                // side up to the end of the left array (i.e. iLeftCounter < iLeftLength) 
                arrLeft[iLeftCounter] = arrMerged[iL + iLeftCounter];
            }


            for (iRightCounter = 0; iRightCounter < iRightLength; iRightCounter++)

            {

                // Note we're doing the same thing here, going from the middle (+1) to
                // the end of the right array
                arrRight[iRightCounter] = arrMerged[iM + 1 + iRightCounter];

            }

            // Re-initialize the counters to zero
            iLeftCounter = 0;
            iRightCounter = 0;

            // Note we set the merged counter to the beginning of the left side, since that's
            // where we'll start filling in
            iMergedCounter = iL; 
            
            // While neither of the left and right array's counters have surpassed their length
            while (iLeftCounter < iLeftLength && iRightCounter < iRightLength)

            {

                // If the value at this location in the left array is less than that in the right array
                if (arrLeft[iLeftCounter] < arrRight[iRightCounter])

                {

                    // Then put the item in the left array into the merged array
                    arrMerged[iMergedCounter] = arrLeft[iLeftCounter];
                    iLeftCounter++;

                }

                else

                {

                    // Otherwise put the item in the right array into the merged array
                    arrMerged[iMergedCounter] = arrRight[iRightCounter];
                    iRightCounter++;

                }

                iMergedCounter++;

            }
            
            // Notice that due to the above while loop's condition, only one of the below while 
            // loops will execute.

            // If there are any items left in the left array then merge them into the merged array
            while(iLeftCounter < iLeftLength)

            {

                arrMerged[iMergedCounter] = arrLeft[iLeftCounter];
                iLeftCounter++;
                iMergedCounter++;

            }

            // If there are any items left in the right array then merge them into the merged array
            while (iRightCounter < iRightLength)

            {

                arrMerged[iMergedCounter] = arrRight[iRightCounter];
                iRightCounter++;
                iMergedCounter++;

            }

            return arrMerged;

        }

    }
    
}

