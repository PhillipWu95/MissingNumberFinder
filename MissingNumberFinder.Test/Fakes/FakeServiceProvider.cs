using Microsoft.Extensions.Logging;
using MissingNumberFinder.Algorithms;
using MissingNumberFinder.Algorithms.Wrapper;
using MissingNumberFinder.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumberFinder.Test.Fakes
{
    public class FakeServiceProvider : IServiceProvider
    {
        private List<IMissingNumberFinder> _finderList;

        public List<IMissingNumberFinder> FinderList
        {
            get { return _finderList; }
        }

        public FakeServiceProvider()
        {
            _finderList = new List<IMissingNumberFinder>([
                new GaussianMissingNumberFinder(),
                new XORMissingNumberFinder(),
                new DictionaryMissingNumberFinder()
            ]);   
        }
        public object? GetService(Type serviceType)
        {
            ILogger<IMissingNumberFinder> fakeLogger = new FakeLogger();
            return _finderList.FirstOrDefault(c => c.GetType() == serviceType);
        }
    }
}
