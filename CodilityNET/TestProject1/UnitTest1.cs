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
        [InlineData("3125", 10, 2, "110000110101")]
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
        [InlineData(3125, 4)]
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

        [Theory]
        [InlineData(new int[] { 3, 8, 9, 7, 6 }, 1, new int[] { 6, 3, 8, 9, 7 })]
        [InlineData(new int[] { 6 },10, new int[] { 6 })]
        [InlineData(new int[] { 3, 8, 9, 7, 6}, 3, new int[] { 9, 7, 6, 3, 8})]
        [InlineData(new int[] { 0, 0, 0}, 1, new int[] { 0, 0, 0})]
        [InlineData(new int[] { 1, 2, 3, 4}, 4, new int[] { 1, 2, 3, 4})]
        [InlineData(new int[] { }, 5, new int[] { })]
        public void CyclicRotation_Test(int[] input, int rotationCount, int[] expectedResult)
        {
            int[] result = _exercise.CyclicRotation(input, rotationCount);

            for(int i = 0; i < result.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 9, 3, 9, 3, 9, 7, 9}, 7)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 5, 2, 2, 2, 2 }, 5)]
        [InlineData(new int[] { 6, 2, 4, 4, 6 }, 2)]
        public void OddOccurencesInArray_Test(int[] input, int expectedResult)
        {
            int result = _exercise.OddOccurencesInArray(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 85, 30, 3)]
        [InlineData(1, 100, 4, 25)]
        [InlineData(10, 20, 100, 1)]
        public void FrogJump_Test(int start, int end, int jumpDistance, int expectedResult)
        {
            int result = _exercise.FrogJump(start, end, jumpDistance);

            Assert.Equal(expectedResult, result);
        }
    }
}