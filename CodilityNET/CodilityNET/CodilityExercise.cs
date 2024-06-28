using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityNET
{
    public class CodilityExercise
    {
        #region BinaryGap
        public int BinaryGap(int n)
        {
            string binary = HelperService.FromBaseToBase(n.ToString(), 10, 2);

            int longestGap = 0;
            int currentGap = 0;
            bool startCounting = false;

            char[] arr = binary.ToCharArray();
            
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '1')
                {
                    if (!startCounting)
                        startCounting = true;

                    if (longestGap < currentGap)
                        longestGap = currentGap;

                    currentGap = 0;
                }
                
                if (startCounting && arr[i] == '0')
                    currentGap++;
            }

            return longestGap;
        }

        #endregion

        #region CyclicRotation

        public int[] CyclicRotation(int[] A, int K)
        {
            if (A.Length == 0)
                return A;
            int counter = 0;
            while(counter < K)
            {
                A = RotateOnce(A);
                counter++;
            }

            return A;
        }

        private int[] RotateOnce(int[] A)
        {
            int holder = A[A.Length - 1];
            for (int i = A.Length - 2; i >= 0; i--)
            {
                A[i + 1] = A[i];
            }
            A[0] = holder;

            return A;
        }

        #endregion

        #region OddOccurencesInArray

        public int OddOccurencesInArray(int[] A)
        {
            HashSet<int> set = new HashSet<int>();

            for(int i= 0; i < A.Length; i++)
            {
                if (set.Contains(A[i]))
                {
                    set.Remove(A[i]);
                }
                else
                {
                    set.Add(A[i]);
                }
            }

            return set.FirstOrDefault();
        }

        #endregion

        #region FrogJump

        public int FrogJump(int X, int Y, int D)
        {
            int distanceBetween = Y - X;
            int remainder = distanceBetween % D;

            if (remainder == 0)
                return distanceBetween / D;
            else
                return (distanceBetween / D) + 1;
            
        }

        #endregion

        #region PermMissingElem

        public int PermMissingElem(int[] A)
        {
            if (A.Length == 0)
                return 1;

            Array.Sort(A);

            if (A[0] != 1)
                return 1;

            int counter = 0;
            int expected = 1;
            while (counter < A.Length - 1)
            {
                expected = A[counter] + 1;
                if (expected != A[counter + 1])
                    return expected;
                counter++;
            }

            return expected + 1;
        }

        #endregion

        #region TapeEquilibrium

        public int TapeEquilibrium(int[] A)
        {
            int leftSum = A[0];
            int rightSum = A.Sum() - A[0];
            int minDiff = Math.Abs(leftSum - rightSum);
            
            for(int i = 1; i < A.Length - 1; i++)
            {
                leftSum += A[i];
                rightSum -= A[i];

                int diff = Math.Abs(leftSum - rightSum);
                if (minDiff > diff)
                    minDiff = diff;
            }
            
            return minDiff;
        }

        #endregion

        #region FrogRiverOne

        public int FrogRiverOne(int X, int[] A)
        {
            int result = -1;
            if (X == 0)
                return 0;
            if (X < 0)
                return -1;

            HashSet<int> set = new HashSet<int>();
            int steps = X;
            
            while(steps >= 1)
            {
                set.Add(steps);
                steps--;
            }

            for(int i = 0; i < A.Length; i++)
            {
                if (set.Contains(A[i]))
                    set.Remove(A[i]);

                if (set.Count == 0)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        #endregion

        #region PermCheck

        public int PermCheck(int[] A)
        {
            int maxValue = A.Length;
            HashSet<int> set = new HashSet<int>();

            while(maxValue >= 1)
            {
                set.Add(maxValue);
                maxValue--;
            }

            for(int i = 0; i < A.Length; i++)
            {
                if (A[i] > A.Length)
                    return 0;

                if (set.Contains(A[i]))
                    set.Remove(A[i]);
            }

            if (set.Count > 0)
                return 0;

            return 1;
        }

        #endregion
    }
}
