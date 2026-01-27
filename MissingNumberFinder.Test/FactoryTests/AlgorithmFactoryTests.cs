using Microsoft.Extensions.DependencyInjection;
using MissingNumberFinder.Algorithms;
using MissingNumberFinder.Algorithms.Wrapper;
using MissingNumberFinder.Contracts;
using MissingNumberFinder.Factory;
using MissingNumberFinder.Factory.DataModels;
using MissingNumberFinder.Test.Fakes;

namespace MissingNumberFinder.Test.FactoryTests
{
    public class AlgorithmFactoryTests
    {
        [Fact]
        public void AlgorithmFactoryTest1()
        {
            IMissingNumberFinder gaussianFinder = new GaussianMissingNumberFinder();
            IMissingNumberFinder xorFinder = new XORMissingNumberFinder();
            IMissingNumberFinder dictiornayFinder = new DictionaryMissingNumberFinder();
            IEnumerable<IMissingNumberFinder> finders = new List<IMissingNumberFinder>([gaussianFinder, xorFinder, dictiornayFinder]);
            //IServiceProvider serviceProvider = new FakeServiceProvider();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            var serviceProvider = serviceCollection.BuildServiceProvider();


            var factory = new AlgorithmFactory(finders, serviceProvider);

            var gaussianContext = new AlgorithmDataContext() { UserInputAlgorithm = "Dictionary" };

            var dictionrayAlgorithmResult = factory.CreateAlgorithm(gaussianContext);
            Assert.IsType<AlgorithmPerformanceTrackingWrapper>(dictionrayAlgorithmResult);
            Assert.Equal("Dictionary", dictionrayAlgorithmResult.AlgorithmName);
        }
    }
}
