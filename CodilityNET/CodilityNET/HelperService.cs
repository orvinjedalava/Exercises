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
