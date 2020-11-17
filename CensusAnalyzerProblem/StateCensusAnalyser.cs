using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;


namespace CensusAnalyzerProblem
{
    public class StateCensusAnalyser
    {
        public List<StateCensusData> StateCensusAnalyserlist = new List<StateCensusData>();
        public Dictionary<String, List<StateCensusData>> Dictionary = new Dictionary<string, List<StateCensusData>>();
       
        public List<StateCensusData> loadStateCensusData(String path) {
            
            var file = new System.IO.StreamReader(path);
            StateCensusAnalyserlist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                    .GetRecords<StateCensusData>().ToList();

            Dictionary.Add("StateCensusAnalyzer", StateCensusAnalyserlist);
            var matchKey = "StateCensusAnalyzer";


            return Dictionary[matchKey];
        }


        public List<StateCensusData> sortByStateName(String path) {
           List<StateCensusData> list= loadStateCensusData(path);
            //sorting using delegate
            list.Sort(delegate (StateCensusData c1, StateCensusData c2) { return c1.State.CompareTo(c2.State); });
           // String JsonSortedStateCensusData = JsonConvert.SerializeObject(list);
            return list;



        }

    }
}
