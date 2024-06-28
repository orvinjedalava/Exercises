using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodilityNET
{
    public class HelperService
    {
        public static int[] BubbleSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length - 1 - i; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        int temp = input[j];
                        input[j] = input[j + 1];
                        input[j + 1] = temp;
                    }
                }
            }

            return input;
        }

        public static string DecimalToBinary(string data)
        {
            string result = string.Empty;
            int rem = 0;
            try
            {
                if (!data.All(char.IsNumber))
                    return "Invalid Value - This is not a numeric value";
                else
                {
                    int num = int.Parse(data);
                    while (num > 0)
                    {
                        rem = num % 2;
                        num = num / 2;
                        result = rem.ToString() + result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public static string FromBaseToBase(string input, int fromBase, int toBase)
        {
            return Convert.ToString(Convert.ToInt32(input, fromBase), toBase);
        }
    }
}
