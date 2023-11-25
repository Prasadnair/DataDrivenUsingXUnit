namespace DataDrivenWithXUnit.Test
{
    public class CalculatorTestWithInlineData
    {
        [Theory]
        [InlineData(2, 3, 5)] // Test case 1
        [InlineData(-1, 1, 0)] // Test case 2
        public void Add_ShouldReturnCorrectSum(int a, int b, int expected)
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            int result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }


    }
}