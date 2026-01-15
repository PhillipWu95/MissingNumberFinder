using MissingNumberFinder;

var app = new MissingNumberFinderConsoleApplication(
    new ConsolerInputProvider(),
    new GaussianMissingNumberFinder(),
    new ConsoleNumberPrinter()
    );
while (true) {
    app.Run();
}
       