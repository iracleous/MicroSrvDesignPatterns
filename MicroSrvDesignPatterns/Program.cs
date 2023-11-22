using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MicroSrvDesignPatterns.DesignPatterns;
ICalculatorService calculatorService = new CalculatorService();


// Set up DI container and configure logging
var serviceProvider = new ServiceCollection()
    .AddLogging(builder => builder.AddConsole())
    .BuildServiceProvider();

if (serviceProvider == null)
{
    Console.WriteLine("provider is unAvailable");
    return;
}

ILogger<CalculatorServiceAmbassador> logger = 
    serviceProvider.GetService<ILogger<CalculatorServiceAmbassador>>();


ICalculatorServiceAmbassador calculatorServiceAmbassador
     = new CalculatorServiceAmbassador(calculatorService, logger);

calculatorServiceAmbassador.AddWithLoggingAndRetry(
    calculatorService.Subtract, new CalcArguements { a=2, b=5}, 2,4);
