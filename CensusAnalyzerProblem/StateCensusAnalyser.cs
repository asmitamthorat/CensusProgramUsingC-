using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



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


        public  string sortByStateName(String path) {
           List<CensusDataDAO> list= loadStateCensusData(path);
            //sorting using delegate
            list.Sort(delegate (CensusDataDAO c1, CensusDataDAO c2) { return c1.State.CompareTo(c2.State); });
           String JsonSortedStateCensusData = JsonConvert.SerializeObject(list);
            // Console.WriteLine(JsonSortedStateCensusData);
            //Console.WriteLine(JsonSortedStateCensusData[6]);
            //var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(JsonSortedStateCensusData);

            //var jsonObject = (JObject)JsonConvert.DeserializeObject(JsonSortedStateCensusData);
            //var example1Model = new JavaScriptSerializer().Deserialize<USCensusAnalyserDTO>(JsonSortedStateCensusData);
            var records = JsonConvert.DeserializeObject(JsonSortedStateCensusData);
            
           // Console.WriteLine(records[0]);
            //Console.WriteLine(jsonObject[0]);
            //var jo = JObject.Parse((string)records);
            //   string sJSONResponse = JsonConvert.SerializeObject(respmsg);
            //  Console.WriteLine(jo[0]);
            return JsonSortedStateCensusData;
        }


        public List<CensusDataDAO> sortBYPopulation(String path) {
            List<CensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate(CensusDataDAO c1,CensusDataDAO c2) { return c1.Population.CompareTo(c2.Population); });
            return list;

        }

        public List<CensusDataDAO> sortByPopulationDensity(String path) {
            List<CensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (CensusDataDAO c1, CensusDataDAO c2) { return c1.DensityPerSqKm.CompareTo(c2.DensityPerSqKm); });
            
            return list;
        }


        public List<CensusDataDAO> sortByStateArea(String path) {
            List<CensusDataDAO> list = loadStateCensusData(path);
            list.Sort(delegate (CensusDataDAO c1, CensusDataDAO c2) { return c1.AreaInSqKm.CompareTo(c2.AreaInSqKm); });
            return list;

        }

    }
}
