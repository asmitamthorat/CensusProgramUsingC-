using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CensusAnalyzerProblem
{
    public class CensusAnalyzerImpli
    {

        static private List<IndiaStateCodeDAO> IndiaStateCodeCsvList = new List<IndiaStateCodeDAO>();
        public List<IndiaStateCodeDAO> loadingStateCensusCSV(String path) {
            using (var file = new System.IO.StreamReader( path))
            {
                IndiaStateCodeCsvList = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture)
                    .GetRecords<IndiaStateCodeDAO>().ToList();
            }
            return IndiaStateCodeCsvList;
        }



        public List<IndiaStateCodeDAO> sortByStateCode(String Path) {
            List<IndiaStateCodeDAO> ListOfStateCode = loadingStateCensusCSV(Path);
            ListOfStateCode.Sort(delegate (IndiaStateCodeDAO c1, IndiaStateCodeDAO c2) { return c1.StateCode.CompareTo(c2.StateCode); });
            return ListOfStateCode;



        }
    }
}
