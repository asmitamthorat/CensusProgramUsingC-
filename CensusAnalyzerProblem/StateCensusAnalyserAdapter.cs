using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
    public interface IStateCensusAnalyserAdapter
    {
        public List<CensusDataDAO> loadStateCensusData(String path);
        public List<CensusDataDAO> sortByStateName(String path);
        public List<CensusDataDAO> sortBYPopulation(String path);
        public List<CensusDataDAO> sortByPopulationDensity(String path);

        public List<CensusDataDAO> sortByStateArea(String path);
    }
}
