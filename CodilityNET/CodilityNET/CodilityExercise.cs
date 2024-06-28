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

        #region MaxCounters

        public int[] MaxCounters(int N, int[] A)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            int key = 1;
            while(key <= N)
            {
                map.Add(key, 0);
                key++;
            }

            int maxValueBomb = 0;
            int maxValue = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == N + 1)
                {
                    maxValueBomb = maxValue;
                    continue;
                }

                int currentCounter = A[i];

                if (map[currentCounter] < maxValueBomb)
                    map[currentCounter] = maxValueBomb;

                map[currentCounter]++;

                if (map[currentCounter] > maxValue)
                    maxValue = map[currentCounter];
            }

            int[] result = new int[N];
            int index = 0;

            foreach(var item in map)
            {
                if (item.Value < maxValueBomb)
                    result[index] = maxValueBomb;
                else
                    result[index] = item.Value;

                index++;
            }

            return result;
        }

        #endregion

        #region MissingInteger

        public int MissingInteger(int[] A)
        {
            int limit = 100000;
            bool[] nums = new bool[limit+2];

            for (int j = 0; j < A.Length; j++)
            {
                int index = A[j];
                if (index < 0 || index > limit)
                    continue;
                nums[index] = true;
            }
            
            for(int k = 1; k <= limit+1; k++)
            {
                if (!nums[k])
                    return k;
            }

            return 1;
        }

        #endregion

        #region NumberOfDiscIntersections

        public int NumberOfDiscIntersections(int[] A)
        {
            int result = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                decimal iStart = i - A[i];
                decimal iEnd = i + A[i];

                for(int j = i+1; j < A.Length; j++)
                {
                    decimal jStart = j - A[j];
                    decimal jEnd = j + A[j];

                    if ( 
                        ( jStart <= iStart && iStart <= jEnd )
                        || ( jStart <= iEnd && iEnd <= jEnd ) 
                        || ( iStart <= jStart && jStart <= iEnd)
                        || ( iStart <= jEnd && jEnd <= iEnd))
                    {
                        result++;
                        continue;
                    }
                }
            }

            return result;
        }

        #endregion

        #region CountDiv

        public int CountDiv(int A, int B, int K)
        {
            int lowerBound = int.MinValue;
            int higherBound = int.MinValue;

            if (A == B )
            {
                if (A % K == 0)
                    return 1;
                else 
                    return 0;
            }


            int current = A;
            while(current <= B)
            {
                if ( current % K == 0)
                {
                    lowerBound = current;
                    break;
                }
                current++;
            }

            current = B;
            while(current >= A)
            {
                if (current % K == 0)
                {
                    higherBound = current;
                    break;
                }
                current--;
            }

            if (lowerBound == int.MinValue && higherBound == int.MinValue)
                return 0;
            if (lowerBound == int.MinValue || higherBound == int.MinValue)
                return 1;

            return (higherBound - lowerBound) / K + 1;
        }

        #endregion

        #region MinAbsSumOfTwo

        public int MinAbsSumOfTwo(int[] A)
        {
            int tail = 0;
            int head = A.Length - 1;
            Array.Sort(A);
            int minSum = int.MaxValue;
            while(tail <= head)
            {
                int sum = A[tail] + A[head];
                minSum = Math.Min(minSum, Math.Abs(sum));

                if (sum <= 0)
                    tail++;
                else
                    head--;
            }
            return minSum;
        }

        #endregion
    }
}
