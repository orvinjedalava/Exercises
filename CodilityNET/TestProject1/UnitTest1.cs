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

        [Theory]
        [InlineData(new int[] { 2, 3, 1, 5}, 4)]
        [InlineData(new int[] { 10,7,3,4,6,5,2,8,1 }, 9)]
        [InlineData(new int[] { }, 1)]
        [InlineData(new int[] { 2 }, 1)]
        [InlineData(new int[] { 1, 2, 3 }, 4)]
        public void PermMissingElem_Test(int[] input, int expectedResult)
        {
            int result = _exercise.PermMissingElem(input);

            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [InlineData(new int[] { 5,3}, 2)]
        [InlineData(new int[] { 3, 1, 2, 4, 3}, 1)]
        [InlineData(new int[] { 6, 2, 2 }, 2)]
        public void TapeEquilibrium_Test(int[] input, int expectedResult)
        {
            int result = _exercise.TapeEquilibrium(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 3, 5, 3, 10, 11, 2, 1, 1,  }, 3,  6)]
        [InlineData(new int[] { 3, 1, 2, 4, 3 }, 10, -1)]
        [InlineData(new int[] { 1, 3, 1, 4, 2, 3, 5, 4 }, 5, 6)]
        public void FrogRiverOne_Test(int[] input, int destination, int expectedResult)
        {
            int result = _exercise.FrogRiverOne(destination, input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 2 , 5, 4 }, 1)]
        [InlineData(new int[] { 3, 1, 2, 4, 3 }, 0)]
        [InlineData(new int[] { 4, 1, 3 }, 0)]
        public void PermCheck_Test(int[] input, int expectedResult)
        {
            int result = _exercise.PermCheck(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 3, 4, 4, 6, 1, 4, 4 }, 5, new int[] { 3, 2, 2, 4, 2 })]
        public void MaxCounters_Test(int[] input, int counters, int[] expectedResult)
        {
            int[] result = _exercise.MaxCounters(counters, input);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 6, 4, 1, 2 }, 5)]
        [InlineData(new int[] { 1, 2, 3 }, 4)]
        [InlineData(new int[] { -1, -3 }, 1)]
        public void MissingInteger_Test(int[] input, int expectedResult)
        {
            int result = _exercise.MissingInteger(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 5, 2, 1, 4, 0 }, 11)]
        public void NumberOfDiscIntersections_Test(int[] input, int expectedResult)
        {
            int result = _exercise.NumberOfDiscIntersections(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(6,11,2,3)]
        [InlineData(6, 12, 2, 4)]
        public void CountDiv_Test(int a, int b, int k, int expectedResult)
        {
            int result = _exercise.CountDiv(a, b, k);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 4, -3 }, 1)]
        [InlineData(new int[] { -8, 4, 5, -10, 3}, 3)]
        [InlineData(new int[] { 6 }, 12)]
        [InlineData(new int[] { 8, 5, 3, 4, 6, 8 }, 6)]
        [InlineData(new int[] { 3, 4, 5, 6, 8, 8 }, 6)]

        public void MinAbsSumOfTwo_Test(int[] input, int expectedResult)
        {
            int result = _exercise.MinAbsSumOfTwo(input);
            
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1 }, 2)]
        [InlineData(new int[] { 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0 }, 3)]
        [InlineData(new int[] { 0, 0, 0, 0, 0, 1, 1  }, 1)]
        [InlineData(new int[] { 0, 0, 0, 0, 0, 1 }, -1)]
        public void FibFrog_Test(int[] input, int expectedResult)
        {
            int result = _exercise.FibFrog(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 }, 3)]
        //[InlineData(new int[] { 0, 1, 0, 0, 1, 0, 0, 1, 0 }, 3)]
        public void Peaks_Test(int[] input, int expectedResult)
        {
            int result = _exercise.Peaks(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("{[()()]}", 1)]
        [InlineData("([)()]", 0)]
        [InlineData(")(", 0)]
        //[InlineData(new int[] { 0, 1, 0, 0, 1, 0, 0, 1, 0 }, 3)]
        public void Brackets_Test(string input, int expectedResult)
        {
            int result = _exercise.Brackets(input);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 0, 0, 0 }, 2)]
        [InlineData(new int[] { 0 }, new int[] { 0 }, 1)]
        [InlineData(new int[] { 6 }, new int[] { 1 }, 1)]

        [InlineData(new int[] { 0, 1 }, new int[] { 0, 0 }, 2)]
        [InlineData(new int[] { 0, 1 }, new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 0, 1 }, new int[] { 1, 0 }, 1)]
        [InlineData(new int[] { 0, 1 }, new int[] { 1, 1 }, 2)]

        [InlineData(new int[] { 1, 0 }, new int[] { 0, 0 }, 2)]
        [InlineData(new int[] { 1, 0 }, new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 1, 0 }, new int[] { 1, 0 }, 1)]
        [InlineData(new int[] { 1, 0 }, new int[] { 1, 1 }, 2)]

        [InlineData(new int[] { 0, 1, 2 }, new int[] { 1, 1, 0 }, 1)]
        [InlineData(new int[] { 0, 1, 2 }, new int[] { 0, 1, 0 }, 2)]

        [InlineData(new int[] { 2, 1, 0 }, new int[] { 1, 1, 0 }, 2)]

        public void Fish_Test(int[] sizes, int[] directions, int expectedResult)
        {
            int result = _exercise.Fish(sizes, directions);

            Assert.Equal(expectedResult, result);
        }

        //[Theory]
        //[InlineData(3, 5, new int[] { 2,1,5,1,2,2,2}, 6)]
        //public void MinMaxDivision_Test(int size, int max, int[] input, int expectedResult)
        //{
        //    int result = _exercise.MinMaxDivision(size, max, input);

        //    Assert.Equal(expectedResult, result);
        //}

        [Fact]
        //[InlineData(new int[] { 1, 2, 3, 4, 1, 1, 3 }, 4,  3)]
        //[InlineData(new int[] { }, 4, 0)]
        //[InlineData(new int[] { 4}, 4, 1)]
        //[InlineData(new int[] { 3 }, 4, 0)]
        //[InlineData(new int[] { 2, 5, 2 }, 5, 1)]
        //[InlineData(new int[] { 2, 3, 5 }, 5, 2)]
        //[InlineData(new int[] { 3, 5, 2 }, 5, 1)]
        //[InlineData(new int[] { 2, 2, 5 }, 5, 1)]
        //[InlineData(new int[] { 1, 1, 4, 1, 1 }, 5, 1)]
        public void TieRopes_Test()
        {
            _exercise.Playground();

            //Assert.Equal(expectedResult, result);
        }
    }
}