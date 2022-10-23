using Calculator.Services;

namespace UnitTests.CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        protected ICalculatorService? CalculatorService;
        [OneTimeSetUp]
        public void Setup()
        {
            CalculatorService = new CalculatorService();
        }
        [OneTimeTearDown]
        public void Exit()
        {
            
        }
    }
}