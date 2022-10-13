using DiamondKata.Generators;
using DiamondKata.Renderer;
using DiamondKata.Validators;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = BuildServiceProvider();
var inputValidator = serviceProvider.GetRequiredService<IValidator>();

if (args.Length == 1 && inputValidator.IsValid(args[0]))
{
    var diamondRenderer = serviceProvider.GetRequiredService<IDiamondRenderer>();
    diamondRenderer.RenderDiamond(args[0][0]);
}
else
{
    Console.WriteLine("Please pass a valid English letter as the argument.");
}



//DI Setup
IServiceProvider BuildServiceProvider()
{
    return new ServiceCollection()
        .AddSingleton<IValidator, EnglishLetterValidator>()
        .AddSingleton<IDiamondMatrixGenerator, DiamondMatrixGenerator>()
        .AddSingleton<IDiamondRenderer, ConsoleRenderer>()
        .BuildServiceProvider();
}
