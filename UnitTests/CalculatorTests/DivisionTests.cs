using Calculator.Models;
using UnitTests.Helpers;

namespace UnitTests.CalculatorTests
{

    public class DivisionTests:CalculatorTests
    {
        private CalculatorRequestResponse? _validResponse, _overflowResponse, _divideZeroResponse;
        [SetUp]
        public void GivenACalculatorDivideRequest()
        {
            _validResponse = CalculatorService!.Divide(CalculatorResponseProvider.CreateRequest("divide", 12, 3, 4));
            _overflowResponse = CalculatorService!.Divide(CalculatorResponseProvider.CreateRequest("divide", Decimal.MaxValue, 0.1M));
            _divideZeroResponse = CalculatorService!.Divide(CalculatorResponseProvider.CreateRequest("divide", 5, 0));
        }

        [Test]
        public void ThenValidRequestReturnsCorrectResult()
        {
            Assert.That(_validResponse, Is.Not.Null);
            Assert.That(_validResponse.Error, Is.Null);
            Assert.That(_validResponse.Result, Is.EqualTo(1M));
        }
        [Test]
        public void AndOverflowRequestReturnsValidErrorResponse()
        {
            Assert.That(_overflowResponse, Is.Not.Null);
            Assert.That(_overflowResponse.Result, Is.Null);
            Assert.That(_overflowResponse.Error, Is.EqualTo(CalculatorResponseProvider.OverflowResponse.Error));
        }
        [Test]
        public void AndDivideZeroRequestReturnsValidErrorResponse()
        {
            Assert.That(_divideZeroResponse, Is.Not.Null);
            Assert.That(_divideZeroResponse.Result, Is.Null);
            Assert.That(_divideZeroResponse.Error, Is.EqualTo(CalculatorResponseProvider.DivideByZeroResponse.Error));
        }
    }
}
