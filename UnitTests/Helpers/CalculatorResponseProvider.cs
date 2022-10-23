using Calculator.Models;

namespace UnitTests.Helpers
{
    public static class CalculatorResponseProvider
    {
        public static CalculatorRequest CreateRequest(string operation, params decimal[] args)
        {
            CalculatorRequest request = new CalculatorRequest { Operation = operation, Parameters = args};
            return request;
        }

        public static CalculatorRequestResponse OverflowResponse => new CalculatorRequestResponse { Error = "Result either too small or too large" };
        public static CalculatorRequestResponse DivideByZeroResponse => new CalculatorRequestResponse { Error = "Cannot divide by 0" };
        public static CalculatorRequestResponse ResultResponse(decimal response) => new CalculatorRequestResponse { Result = response };
    }
}
