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
                    Error = "Result either too small or too large"
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
                        Error = "Result either too small or too large"
                    };
                }
                catch (DivideByZeroException)
                {
                    return new CalculatorRequestResponse
                    {
                        Error = "Cannot divide by 0"
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
                    Error = "Result either too small or too large"
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
                    Error = "Result either too small or too large"
                };
            }
            return new CalculatorRequestResponse { Result = result };
        }
    }
}
