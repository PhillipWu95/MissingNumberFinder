using MissingNumberFinder;
using MissingNumberFinder.Algorithms;
using MissingNumberFinder.Contracts;
using MissingNumberFinder.Factory;
using MissingNumberFinder.Factory.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

builder.Services.AddTransient<INumberInputProvider, ConsolerInputProvider>();
builder.Services.AddTransient<INumberOutputPrinter, ConsoleNumberPrinter>();
builder.Services.AddTransient<IAlgorithmDataContextInputProvider, AlgorithmDataContextConsoleInputProvider>();
builder.Services.AddSingleton<IAlgorithmFactory, AlgorithmFactory>();


builder.Services.AddTransient<IMissingNumberFinder, GaussianMissingNumberFinder>();
builder.Services.AddTransient<IMissingNumberFinder, XORMissingNumberFinder>();
builder.Services.AddTransient<IMissingNumberFinder, DictionaryMissingNumberFinder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
