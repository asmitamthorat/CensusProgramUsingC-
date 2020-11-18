using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
     public  interface IUSAdapter
    {
        public List<USCensusAnalyserDAO> loadUSCensusData(String path);
        public List<USCensusAnalyserDAO> sortByPopulation(String path);
        public List<USCensusAnalyserDAO> sortByPopulationDensity(String Path);

        public List<USCensusAnalyserDAO> sortByArea(string uSCensusData);
    }
}
