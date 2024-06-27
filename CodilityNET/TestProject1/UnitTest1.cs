using CodilityNET;

namespace TestProject1
{
    public class UnitTest1
    {
        CodilityExercise _exercise = new ();

        [Theory]
        [InlineData("3", 10, 2, "11")]
        [InlineData("4", 10, 2, "100")]
        [InlineData("5", 10,2,"101")]
        [InlineData("1041", 10, 2, "10000010001")]
        [InlineData("100", 10, 16, "64")]
        [InlineData("15", 10, 16, "F")]
        [InlineData("10", 10, 8, "12")]
        public void FromBaseToBase_Test(string input, int fromBase, int toBase, string expectedResult)
        {
            string result = HelperService.FromBaseToBase(input, fromBase, toBase);

            Assert.Equal(expectedResult, result, ignoreCase: true);
        }

        [Theory]
        [InlineData(3,0)]
        [InlineData(4,0)]
        [InlineData(5,1)]
        [InlineData(1041, 5)]
        [InlineData(32, 0)]
        public void BinaryGap_Test(int input, int expectedResult)
        {
            int result = _exercise.BinaryGap(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("3","11")]
        [InlineData("4","100")]
        
        public void DecimalToBinary_Test(string input, string expectedResult)
        {
            string result = HelperService.DecimalToBinary(input);

            Assert.Equal(expectedResult, result, ignoreCase: true);
        }
    }
}