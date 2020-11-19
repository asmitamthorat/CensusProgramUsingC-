using System;

namespace CensusAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            String IndiaCensusDataFilePath1 = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\IndiaStateCensusData.csv";
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();

            stateCensusAnalyser.sortByStateName(IndiaCensusDataFilePath1);


        }
    }
}
