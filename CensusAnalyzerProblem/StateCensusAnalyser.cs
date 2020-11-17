using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;


namespace CensusAnalyzerProblem
{
    public class StateCensusAnalyser
    {
        public List<CensusDataDAO> StateCensusAnalyserlist = new List<CensusDataDAO>();
        public Dictionary<String, List<CensusDataDAO>> Dictionary = new Dictionary<string, List<CensusDataDAO>>();
       
        public List<CensusDataDAO> loadStateCensusData(String path) {
            var file = new System.IO.StreamReader(path);
            StateCensusAnalyserlist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                    .GetRecords<CensusDataDAO>().ToList();

            Dictionary.Add("StateCensusAnalyzer", StateCensusAnalyserlist);
            var matchKey = "StateCensusAnalyzer";
            return Dictionary[matchKey];
        }


        public List<CensusDataDAO> sortByStateName(String path) {
           List<CensusDataDAO> list= loadStateCensusData(path);
            //sorting using delegate
            list.Sort(delegate (CensusDataDAO c1, CensusDataDAO c2) { return c1.State.CompareTo(c2.State); });
            // String JsonSortedStateCensusData = JsonConvert.SerializeObject(list);
            Console.WriteLine(list);
            return list;



        }

    }
}
