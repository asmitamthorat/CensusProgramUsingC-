using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace CensusAnalyzerProblem
{
   public class USCensusAnalyser
    {
       // List<USCensusAnalyserDAO> USCensusDataList = new List<USCensusAnalyserDAO>();
        public Dictionary<String, List<USCensusAnalyserDAO>> Dictionary = new Dictionary<string, List<USCensusAnalyserDAO>>();
        public List<USCensusAnalyserDAO> loadUSCensusData(String path) {

            CSVBuilder cSVBuilder = new CSVBuilder();

            FileInfo csvFile = new FileInfo(path);
            String FileExtension = csvFile.Extension;
            if (FileExtension != ".csv") {
                throw new CustomException(CustomException.ExceptionType.INVALID_FILE, "provided file is not a csv file"); 
            }



            var file = new System.IO.StreamReader(path);
           cSVBuilder.CSVBuilder1(path, "USCensusAnalyser");
            
            Dictionary.Add("USCensusAnalyser", cSVBuilder.USCensusAnalyserlist);
            var matchKey = "USCensusAnalyser";
            return Dictionary[matchKey];
        }

        public List<USCensusAnalyserDAO> sortByPopulation(String path) {
            List<USCensusAnalyserDAO> USCensusDataList = loadUSCensusData(path);
            USCensusDataList.Sort(delegate (USCensusAnalyserDAO c1, USCensusAnalyserDAO c2) { return c1.Population.CompareTo(c2.Population); });
            return USCensusDataList;

        }

     public List<USCensusAnalyserDAO> sortByPopulationDensity(String Path) {
           List<USCensusAnalyserDAO> USCensusList = loadUSCensusData(Path);
            USCensusList.Sort(delegate (USCensusAnalyserDAO c1, USCensusAnalyserDAO c2) { return c1.PopulationDensity.CompareTo(c2.PopulationDensity); });
          return USCensusList;
        }

        public List<USCensusAnalyserDAO> sortByArea(string uSCensusData)
        {
            List<USCensusAnalyserDAO> USCensusList = loadUSCensusData(uSCensusData);
            USCensusList.Sort(delegate (USCensusAnalyserDAO c1, USCensusAnalyserDAO c2) { return c1.LandArea.CompareTo(c2.LandArea); });
            return USCensusList;
        }
    }
}
