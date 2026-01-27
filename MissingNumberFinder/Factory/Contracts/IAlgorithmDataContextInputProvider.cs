using MissingNumberFinder.Factory.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumberFinder.Factory.Contracts
{
    public interface IAlgorithmDataContextInputProvider
    {
        public AlgorithmDataContext CreateDataContext();
    }
}
