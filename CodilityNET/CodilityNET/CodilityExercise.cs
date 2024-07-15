using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        #region FibFrog

        public int FibFrog(int[] A)
        {
            int totalSteps = A.Length  + 1;
            List<Fibonacci> fibVals = GenerateFib(100);
            int cursorIndex = A.Length - 1;
            int destinationIndex = A.Length;
            Fibonacci? fib = null;
            int jumps = 0;
            int currentIndex = -1;

            while (totalSteps > 0)
            {
                fib = fibVals.Find(x => x.Value == totalSteps);
                if (fib != null)
                {
                    jumps++;
                    return jumps;
                }    

                if (A[cursorIndex] == 1 && fibVals.Find(x => x.Value == cursorIndex - currentIndex) != null)
                {
                    totalSteps -= cursorIndex - currentIndex;
                    currentIndex = cursorIndex;
                    jumps++;
                    cursorIndex = A.Length - 1;
                }
                else
                {
                    cursorIndex--;
                    if (cursorIndex < 0 || currentIndex == cursorIndex)
                        return -1;
                }
            }

            return -1;
        }

        public class Fibonacci
        {
            public int Value { get; private set; }
            public Fibonacci(int value)
            {
                Value = value;
            }
        }

        public List<Fibonacci> GenerateFib(int max)
        {
            int index = 0;
            List<Fibonacci> result = new List<Fibonacci>();
            int[] temp = new int[max + 1];
            
            while(index <= max)
            {
                if (index == 0)
                {
                    temp[index] = 0;
                    result.Add(new Fibonacci(0));
                }
                if (index == 1)
                {
                    temp[index] = 1;
                    result.Add(new Fibonacci(1));
                }
                if (index >= 2)
                {
                    temp[index] = temp[index - 1] + temp[index - 2];
                    result.Add(new Fibonacci(temp[index]));
                }
                
                index++;
            }

            return result.ToList();
        }

        #endregion

        #region Peaks

        public int Peaks(int[] A)
        {
            if (A.Length <= 2)
                return 0;

            List<int> peaks = new List<int>();
            for(int i = 1; i < A.Length - 1; i++)
            {
                if (A[i - 1] < A[i] && A[i] > A[i + 1])
                    peaks.Add(i);
            }
            if (peaks.Count <= 1)
                return peaks.Count;

            int result = 1;

            for (int i = 2; i <= A.Length / 2; i += 2)
            {
                if (A.Length % i == 0)
                {
                    if (AllBlocksHavePeaks(i, A.Length, peaks))
                        result++;
                }
            }

            int squareRoot = (int)Math.Floor(Math.Sqrt(A.Length));

            for (int i = 3; i <= squareRoot; i += 2)
            {
                if (A.Length % i == 0)
                {
                    if (AllBlocksHavePeaks(i, A.Length, peaks))
                        result++;
                }
            }

            return result;
        }

        private bool AllBlocksHavePeaks(int divisor, int length, List<int> peaks)
        {
            HashSet<int> peaksUsed = new HashSet<int>();

            for (int j = 0; j < length; j = j + divisor)
            {
                int start = j;
                int end = j + divisor - 1;
                int peak = peaks.Find(x => start <= x && x <= end);
                if (peak == 0 && !peaksUsed.Contains(peak))
                {
                    return false;
                }
                peaksUsed.Add(peak);
            }

            return true;
        }

        private bool IsPrimeNumber(int number)
        {
            if (number == 1 || number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            int squareRoot = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= squareRoot; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        #endregion

        #region Brackets

        public int Brackets(string S)
        {
            Stack<char> stack = new Stack<char>();

            char[] arr = S.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ']') 
                {
                    if (stack.Count > 0 && stack.Peek() == '[')
                        stack.Pop();
                    else
                        return 0;
                }
                else if (arr[i] == '}')
                {
                    if (stack.Count > 0 && stack.Peek() == '{')
                        stack.Pop();
                    else
                        return 0;
                }
                else if (arr[i] == ')')
                {
                    if (stack.Count > 0 && stack.Peek() == '(')
                        stack.Pop();
                    else
                        return 0;
                }
                else
                {
                    stack.Push(arr[i]);
                }
            }

            if (stack.Count != 0)
                return 0;

            return 1;
        }

        #endregion

        #region Fish

        public int Fish(int[] A, int[] B)
        {
            if (A.Length == 0)
                return 0;

            if (A.Length == 1)
                return 1;

            Dictionary<int, int> fishToDirections = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                fishToDirections.Add(A[i], B[i]);
            }

            Queue<int> queue = new Queue<int>(A.ToList());
            Stack<int> stack = new Stack<int>();

            while(queue.Any())
            {
                int fish = queue.Dequeue();
                if (fishToDirections[fish] == 0)
                {
                    if (!stack.Any())
                    {
                        stack.Push(fish);
                        continue;
                    }
                    while (stack.Any())
                    {
                        int prevFish = stack.Peek();
                        if (fishToDirections[prevFish] == 1)
                        {
                            if (prevFish > fish)
                            {
                                break;
                            }
                            else
                            {
                                stack.Pop();
                                if (stack.Count == 0)
                                {
                                    stack.Push(fish);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            stack.Push(fish);
                            break;
                        }
                    }
                    
                }
                else
                {
                    if (!queue.Any())
                    {
                        stack.Push(fish);
                        continue;
                    }
                    while(queue.Any())
                    {
                        if (queue.Count == 0)
                            stack.Push(fish);
                        int nextFish = queue.Peek();
                        if (fishToDirections[nextFish] == 0)
                        {
                            if (nextFish > fish)
                            {
                                break;
                            }
                            else
                            {
                                queue.Dequeue();
                                if (queue.Count == 0)
                                    stack.Push(fish);
                            }
                        }
                        else
                        {
                            stack.Push(fish);
                            break;
                        }
                    }
                }
            }

            return stack.Count;
        }

        #endregion

        #region MinAbsSum

        public int MinAbsSum(int[] input)
        {
            int sum = 0;
            for(int i = 0; i< input.Length; i++)
            {
                sum += Math.Abs(input[i]);
            }

            float center = sum / 2f;
            int range = (int)Math.Floor(center);

            int[] r = new int[range + 1];
            r[0] = 1;

            foreach(int i in input)
            {
                for (int j = r.Length - 1; j >= 0; j--)
                {
                    if (j - Math.Abs(i) >= 0)
                    {
                        if (r[j - Math.Abs(i)] == 1)
                        {
                            r[j] = 1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for(int i = range; i >= 0; i--)
            {
                if (r[i] == 1)
                {
                    return (int)((center - i) * 2);
                }
            }

            return -1;
        }

        #endregion

        //#region MinMaxDivision

        //public int MinMaxDivision(int K, int M, int[] A)
        //{
        //    int min = 0;
        //    int max = 0;
        //    for(int i = 0; i < A.Length; i++)
        //    {
        //        max += A[i];
        //        min = Math.Max(min, A[i]);
        //    }

        //    int result = max;

        //    while(min <= max)
        //    {
        //        int mid = (min + max) / 2;
        //        if (divisionSolvable(mid, K - 1, A))
        //        {
        //            max = mid - 1;
        //            result = mid;
        //        } else
        //        {
        //            min = mid + 1;
        //        }
        //    }

        //    return max;
        //}

        //private bool divisionSolvable(int mid, int k, int[] a)
        //{
        //    int sum = 0;
        //    for(int i = 0; i < a.Length; i++)
        //    {
        //        sum += a[i];
        //        if (sum > mid)
        //        {
        //            sum = a[i];
        //            k--;
        //        }
        //        if (k < 0)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        //#endregion

        #region TieRopes

        public int TieRopes(int K, int[] A)
        {
            int result = 0;
            int sum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
                if (sum >= K)
                {
                    result++;
                    sum = 0;
                }
            }

            return result;
        }

        #endregion

        #region MinMaxDivision

        /// <summary>
        /// Use Binary Algorithm
        /// https://www.youtube.com/watch?v=cAQAb_DI1J0&list=PLTMybUaeagJbTAelBd-pGBuAngpPtnw8b&index=38
        /// </summary>
        /// <param name="k"></param>
        /// <param name="m"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public int MinMaxDivision(int k, int m, int[] input)
        {
            // the possible least "largest sum" array
            int min = 0;
            // the sum of all elements in the array is the largest "largest sum" array.
            int max = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                max += input[i];
                min = Math.Max(min, input[i]);
            }

            // the best fit value for k blocks
            int bestAnswer = max;

            while(min <= max)
            {
                // get the mid point
                int mid = (min + max) / 2;

                int blocks = CheckHowManyBlocksFor(input, mid);

                if (blocks > k) // guess value provided in CheckHowManyBlocksFor() is smaller than what we are looking for.
                {
                    min = mid + 1;
                }
                // guess value provided in CheckHowManyBlocksFor() resulted in valid number of blocks.
                // we can fill up the remaining blocks with empty arrays ( [] ). Continue adjusting 
                else
                {
                    max = mid - 1;
                    if (mid < bestAnswer)
                    {
                        bestAnswer = mid;
                    }
                }
            }

            return bestAnswer;
            
        }

        /// <summary>
        /// Gives the number of maximum blocks that can be formed from an array for a given guess value.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        private int CheckHowManyBlocksFor(int[] input, int guess)
        {
            // the iteration start will count as first block (1)
            int blocks = 1;
            int blockSum = 0;

            for(int i = 0; i < input.Length; i++)
            {
                blockSum += input[i];
                // if adding current element overflows the sum, add a block and reset the sum to the current element
                if (blockSum > guess) 
                {
                    blocks++;
                    blockSum = input[i];
                }
            }

            return blocks;
        }

        #endregion

        public void Playground()
        {
            char[] arry = new char[] { '1', '2' };
            Console.WriteLine(arry.ToString());
        }
    }
}
