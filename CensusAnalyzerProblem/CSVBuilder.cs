using System;
using System.Collections.Generic;

using System.Linq;
using System.IO;

namespace CensusAnalyzerProblem
{
   public class CSVBuilder
    {
       public List<USCensusAnalyserDAO> USCensusAnalyserlist = new List<USCensusAnalyserDAO>();
      public  List<IndiaStateCodeDAO> IndiaStateCodelist = new List<IndiaStateCodeDAO>();
       
       
        public void CSVBuilder1(string path,string name) 
        {
            var file = new System.IO.StreamReader(path);
            switch (name) {
                case "USCensusAnalyser":
                    USCensusAnalyserlist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture).GetRecords<USCensusAnalyserDAO>().ToList();
                    Console.WriteLine(USCensusAnalyserlist[0].State);

                    break;

                   
                case "StateCensusAnalyser":
                    IndiaStateCodelist = new CsvHelper.CsvReader(file, System.Globalization.CultureInfo.InvariantCulture).GetRecords<IndiaStateCodeDAO>().ToList();
                    break;
                   

            }

           
            

        }
    }
}
