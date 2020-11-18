using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyzerProblem
{
   public class USCensusAnalyser
    {
        List<USCensusAnalyserDAO> USCensusDataList = new List<USCensusAnalyserDAO>();
        public List<USCensusAnalyserDAO> loadUSCensusData(String path) {
            var file = new System.IO.StreamReader(path);
            USCensusDataList = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                        .GetRecords<USCensusAnalyserDAO>().ToList();

            return USCensusDataList;
        }

        public List<USCensusAnalyserDAO> sortByPopulation(String path) {
            List<USCensusAnalyserDAO> USCensusDataList = loadUSCensusData(path);
            USCensusDataList.Sort(delegate (USCensusAnalyserDAO c1, USCensusAnalyserDAO c2) { return c1.Population.CompareTo(c2.Population); });
            Console.WriteLine(USCensusDataList[USCensusDataList.Count-1].State);
            return USCensusDataList;

        }

        public List<USCensusAnalyserDAO> sortByPopulationDensity(String Path) {
            List<USCensusAnalyserDAO> USCensusList = loadUSCensusData(Path);
            USCensusList.Sort(delegate (USCensusAnalyserDAO c1, USCensusAnalyserDAO c2) { return c1.PopulationDensity.CompareTo(c2.PopulationDensity); });
            Console.WriteLine(USCensusDataList[USCensusDataList.Count - 1].State);
            return USCensusDataList;
        }

        public List<USCensusAnalyserDAO> sortByArea(string uSCensusData)
        {
            List<USCensusAnalyserDAO> USCensusList = loadUSCensusData(uSCensusData);
            USCensusList.Sort(delegate (USCensusAnalyserDAO c1, USCensusAnalyserDAO c2) { return c1.LandArea.CompareTo(c2.LandArea); });
            Console.WriteLine(USCensusList[USCensusList.Count-1].State);
            return USCensusList;
        }
    }
}
