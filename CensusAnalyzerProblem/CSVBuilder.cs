using System;
using System.Collections.Generic;

using System.Linq;
using System.IO;

namespace CensusAnalyzerProblem
{
   public class CSVFactory
    {
       public List<USCensusAnalyserDAO> USCensusAnalyserlist = new List<USCensusAnalyserDAO>();
        public Dictionary<String, List<USCensusAnalyserDAO>>mapUSCensusAnalyser = new Dictionary<string, List<USCensusAnalyserDAO>>();
        public  List<CensusDataDAO> StateCensusAnalyserlist = new List<CensusDataDAO>();
        public Dictionary<String, List<CensusDataDAO>> mapStateCensusAnalyser = new Dictionary<string, List<CensusDataDAO>>();


        public void CSVBuilder(string path,string name) 
        {
            var file = new System.IO.StreamReader(path);
            switch (name) {
                case "USCensusAnalyser":
                    USCensusAnalyserlist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture).GetRecords<USCensusAnalyserDAO>().ToList();Console.WriteLine(USCensusAnalyserlist[0].State);
                    mapUSCensusAnalyser.Add("USCensusAnalyser", USCensusAnalyserlist);
                    break;

                   
                case "StateCensusAnalyser":
                    StateCensusAnalyserlist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture).GetRecords<CensusDataDAO>().ToList();
                    mapStateCensusAnalyser.Add("StateCensusAnalyser", StateCensusAnalyserlist);
                    break;
                   

            }

           
            

        }
    }
}
