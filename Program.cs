using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MissingNumberFinder;
using MissingNumberFinder.Algorithms;
using MissingNumberFinder.Contracts;
using MissingNumberFinder.Factory;
using MissingNumberFinder.Factory.Contracts;

var service = new ServiceCollection();

service.AddLogging(builder => builder.AddConsole());

service.AddTransient<INumberInputProvider, ConsolerInputProvider>();
service.AddTransient<INumberOutputPrinter, ConsoleNumberPrinter>();
service.AddTransient<IAlgorithmDataContextInputProvider, AlgorithmDataContextConsoleInputProvider>();
service.AddSingleton<IAlgorithmFactory, AlgorithmFactory>();


service.AddTransient<IMissingNumberFinder, GaussianMissingNumberFinder>();
service.AddTransient<IMissingNumberFinder, XORMissingNumberFinder>();
service.AddTransient<IMissingNumberFinder, DictionaryMissingNumberFinder>();


service.AddTransient<MissingNumberFinderConsoleApplication>();

var provider = service.BuildServiceProvider();

var app = provider.GetRequiredService<MissingNumberFinderConsoleApplication>();

//var app = new MissingNumberFinderConsoleApplication(
//    new ConsolerInputProvider(),
//    new AlgorithmDataContextConsoleInputProvider(),
//    new AlgorithmFactory(),
//    new ConsoleNumberPrinter()
//    );
while (true) {
    app.Run();
}
       