using System.Collections;

namespace DataDrivenWithXUnit.Test
{
    public class CalculatorTestWithMemberData
    {
        [Theory]
        [MemberData(nameof(CombinedData))]        
        public void Add_ShouldReturnCorrectSum(int a, int b, int expected)
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            int result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }


        public static IEnumerable<object[]> CombinedData()
        {
            var testData = new List<object[]>
            {
                new object[] { 2, 3, 5 },   // Test case 1: a=2, b=3, expected=5
                new object[] { -1, 1, 0 }  // Test case 2: a=-1, b=1, expected=0
            };

            return testData;
        }


    }
   
}