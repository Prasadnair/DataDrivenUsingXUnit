using Newtonsoft.Json;

namespace DataDrivenWithXUnit.Test
{
    public class CalculatorTestWithExternalData
    {
        private static string TestDataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "ExternalData.json");// Path.Combine(Directory.GetCurrentDirectory(),"ExternalData.json");

        [Theory]
        [MemberData(nameof(GetCalculatorTestDataFromJson))]
        public void Add_ShouldReturnCorrectSum_CustomData(int a, int b, int expected)
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            int result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }


        public static IEnumerable<object[]> GetCalculatorTestDataFromJson()
        {
            if (!File.Exists(TestDataFilePath))
            {
                
                throw new FileNotFoundException($"File not found: {TestDataFilePath}");
            }

            string jsonContent = File.ReadAllText(TestDataFilePath);
            var testData = JsonConvert.DeserializeObject<List<TestData>>(jsonContent)?? new List<TestData>();

            foreach (var data in testData)
            {
                yield return new object[]
                {
                data.a, 
                data.b, 
                data.expected,
                
                };
            }
        }


    }


    public class TestData
    {
        public int a { get; set; }
        public int b { get; set; }
        public int expected { get; set; }
        
    }   

}