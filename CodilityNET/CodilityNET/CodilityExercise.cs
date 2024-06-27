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

    }
}
