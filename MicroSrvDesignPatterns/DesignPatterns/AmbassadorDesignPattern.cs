using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polly;

namespace MicroSrvDesignPatterns.DesignPatterns;

 


// Ambassador Interface
public interface ICalculatorServiceAmbassador
{
    public int AddWithLoggingAndRetry(Func<CalcArguements, int> operation, CalcArguements aa, int a, int b);


}




public static class RetryHelper
{
    public static T Retry<T>(Func<T> operation, int maxRetries = 3)
    {
        int retries = 0;

        while (true)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Operation failed. Retrying ({retries + 1}/{maxRetries})...");
                retries++;

                if (retries >= maxRetries)
                {
                    Console.WriteLine($"Max retries reached. Unable to complete the operation. Exception: {ex.Message}");
                    throw;
                }
            }
        }
    }
}





public class CalculatorServiceAmbassador : ICalculatorServiceAmbassador
{
    private readonly ICalculatorService  _calculatorService;
    private readonly ILogger<CalculatorServiceAmbassador> _logger;
 

    public CalculatorServiceAmbassador(ICalculatorService calculatorService,
     ILogger<CalculatorServiceAmbassador> logger )
    {
        _calculatorService = calculatorService;
        _logger = logger;
      
    }

    public int AddWithLoggingAndRetry(Func<CalcArguements, int>operation, CalcArguements aa,int a, int b)
    {
        return RetryHelper.Retry<int>(() =>
        {
            _logger.LogInformation($"Calling AddWithLoggingAndRetry({a}, {b})");
            /* int result = _calculatorService.Add(new CalcArguements { a = a, b = b },0);
             result+= _calculatorService.Multiply(new CalcArguements { a = a, b = b }, "dot");
             result += _calculatorService.Subtract(new CalcArguements { a = a, b = b } );
            */
            int result = operation(aa);
            _logger.LogInformation($"Result: {result}");
            return result;
        }, 6);

    }
}

