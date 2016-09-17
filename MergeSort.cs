using System;

namespace Algorithms

{

    public class MergeSort : ISort

    {

        public string Name { get; set; }
        public Random rand { get; set; }
        public int[] intArrRandom { get; set; }
        public int[] intArrSorted { get; set; }

        /// <summary>
        /// Initalize a random array of random size
        /// </summary>
        public MergeSort()

        {
            
            Name = "Merge Sort";

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

                // Set the middle
                iM = GetMiddleValue(iL, iR);

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
        /// Get the middle value of two numbers (i.e. the left and right values)
        /// </summary>
        /// <param name="intL"></param>
        /// <param name="intR"></param>
        /// <returns></returns>
        public int GetMiddleValue(int intL, int intR)
        {

            return ((intL + intR) / 2);

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

            // The right array will be from the middle to the right side (so subtracting the
            // middle removes the entire left side
            int iRightLength = iR - iM;

            int[] arrLeft = new int[iLeftLength];
            int[] arrRight = new int[iRightLength];

            // Get the left subarray
            arrLeft = GetArraySubset(arrMerged, iL, iLeftLength, true);
            
            // Get the right subarray
            arrRight = GetArraySubset(arrMerged, iM, iRightLength, false);
            
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

            // Due to the above while loop's condition, only one of the below functions
            // will actually update the arrMerged variable.

            // If there are any items left in the left array then merge them into the merged array
            arrMerged = MergeSubArray(iLeftCounter, iMergedCounter, arrLeft, arrMerged);

            // If there are any items left in the right array then merge them into the merged array
            arrMerged = MergeSubArray(iRightCounter, iMergedCounter, arrRight, arrMerged);
            
            return arrMerged;

        }

        public int[] GetArraySubset(int[] intArrSource, int intStartIndex, int intNewArrLength, bool bZeroBased)
        {

            int iCounter;
            int[] intArrSubset = new int[intNewArrLength];

            // Copy data from the source into the Left and Right arrays
            for (iCounter = 0; iCounter < intNewArrLength; iCounter++)

            {

                // If this is a zero based subset, just add the start index to the counter
                // If this is not a zero based subet, then we need to add one
                intArrSubset[iCounter] = bZeroBased ?
                    intArrSource[intStartIndex + iCounter] : intArrSource[intStartIndex + iCounter + 1];

            }

            return intArrSubset;

        }

        public int[] MergeSubArray(int intSubArrayStart, int intMergeIndex, int[] intArrSubArray, int[] intMergeArray)

        {

            while (intSubArrayStart < intArrSubArray.Length)

            {

                intMergeArray[intMergeIndex] = intArrSubArray[intSubArrayStart];
                intSubArrayStart++;
                intMergeIndex++;

            }

            return intMergeArray;

        }

    }
    
}

