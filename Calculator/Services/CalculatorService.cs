using Calculator.Models;
using System.Runtime.CompilerServices;

namespace Calculator.Services
{
    public interface ICalculatorService
    {
        public CalculatorRequestResponse Add(CalculatorRequest request);
        public CalculatorRequestResponse Subtract(CalculatorRequest request);
        public CalculatorRequestResponse Multiply(CalculatorRequest request);
        public CalculatorRequestResponse Divide(CalculatorRequest request);
    }
    public class CalculatorService : ICalculatorService
    {
        private const string _overflowMessage = "Result either too small or too large";
        private const string _divideZeroMessage = "Cannot divide by 0";
        public CalculatorRequestResponse Add(CalculatorRequest request)
        {
            decimal result;
            try
            {
                result = request.Parameters!.Aggregate((numerator, denominator) => numerator + denominator);
            }
            catch (OverflowException)
            {
                return new CalculatorRequestResponse
                {
                    Error = _overflowMessage
                };
            }
            return new CalculatorRequestResponse { Result = result };
        }

        public CalculatorRequestResponse Divide(CalculatorRequest request)
        {
            decimal result;
                try
                {
                    result = request.Parameters!.Aggregate((numerator, denominator) => numerator / denominator);
                }
                catch (OverflowException)
                {
                    return new CalculatorRequestResponse
                    {
                        Error = _overflowMessage
                    };
                }
                catch (DivideByZeroException)
                {
                    return new CalculatorRequestResponse
                    {
                        Error = _divideZeroMessage
                    };
                }
            return new CalculatorRequestResponse { Result = result };
        }

        public CalculatorRequestResponse Multiply(CalculatorRequest request)
        {
            decimal result;
            try
            {
                result = request.Parameters!.Aggregate((numerator, denominator) => numerator * denominator);
            }
            catch (OverflowException)
            {
                return new CalculatorRequestResponse
                {
                    Error = _overflowMessage
                };
            }
            return new CalculatorRequestResponse { Result = result };
        }

        public CalculatorRequestResponse Subtract(CalculatorRequest request)
        {
            decimal result;
            try
            {
                result = request.Parameters!.Aggregate((numerator, denominator) => numerator - denominator);
            }
            catch (OverflowException)
            {
                return new CalculatorRequestResponse
                {
                    Error = _overflowMessage
                };
            }
            return new CalculatorRequestResponse { Result = result };
        }
    }
}
