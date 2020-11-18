using System;

namespace CensusAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            String USCensusData = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\USCensusData.csv";
            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            uSCensusAnalyser.sortByArea(USCensusData);
        }
    }
}
