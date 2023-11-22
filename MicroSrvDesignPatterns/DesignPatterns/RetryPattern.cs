using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSrvDesignPatterns.DesignPatterns
{
    public static class RetryPattern
    {
        public static void CheckRetry()
        {
            // Define a policy with a retry strategy, circuit breaker, and fallback
            var policy = Policy
                        .Handle<HttpRequestException>() // Specify the exception to handle
                        .WaitAndRetry(
                            3, // Retry 3 times
                            retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                        )


                        ;

          
                policy.Execute(() =>
                {
                    // Simulate an operation that might fail
                    DoSomethingThatMightFail();
                });
             

            Console.WriteLine("Program completed.");

        }

            private static void DoSomethingThatMightFail()
        {
            Console.WriteLine("Doing something that might fail...");
            // Simulate a network request that might throw an exception
            throw new HttpRequestException("Simulated network error");
        }
    }
}
