using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityNET
{
    public class CodilityExercise
    {
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
    }
}
