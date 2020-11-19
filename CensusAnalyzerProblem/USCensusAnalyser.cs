using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CensusAnalyzerProblem
{
   public class USCensusAnalyser:Adapter
    {
      
        
        public List<USCensusAnalyserDAO> loadUSCensusData(String path) {

            CSVFactory CSVFactory = new CSVFactory();
            FileInfo csvFile = new FileInfo(path);
            String FileExtension = csvFile.Extension;
            if (FileExtension != ".csv") {
                throw new CustomException(CustomException.ExceptionType.INVALID_FILE, "provided file is not a csv file"); 
            }
           
            CSVFactory.CSVBuilder(path, "USCensusAnalyser");
            return CSVFactory.mapUSCensusAnalyser["USCensusAnalyser"];
        }

        public List<USCensusAnalyserDAO> sortByPopulation(String path) {
            List<USCensusAnalyserDAO> USCensusDataList = loadUSCensusData(path);
            USCensusDataList.Sort(delegate (USCensusAnalyserDAO Object1, USCensusAnalyserDAO Object2) { return Object1.Population.CompareTo(Object2.Population); });
            return USCensusDataList;

        }

     public List<USCensusAnalyserDAO> sortByPopulationDensity(String Path) {
           List<USCensusAnalyserDAO> USCensusList = loadUSCensusData(Path);
            USCensusList.Sort(delegate (USCensusAnalyserDAO Object1, USCensusAnalyserDAO Object2) { return Object1.PopulationDensity.CompareTo(Object2.PopulationDensity); });
          return USCensusList;
        }

        public List<USCensusAnalyserDAO> sortByArea(string uSCensusData)
        {
            List<USCensusAnalyserDAO> USCensusList = loadUSCensusData(uSCensusData);
            USCensusList.Sort(delegate (USCensusAnalyserDAO Object1, USCensusAnalyserDAO Object2) { return Object1.LandArea.CompareTo(Object2.LandArea); });
            return USCensusList;
        }
    }
}
