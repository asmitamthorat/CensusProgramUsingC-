using NUnit.Framework;
using CensusAnalyzerProblem;
using System;
using System.Collections.Generic;

namespace CensusAnalyzerTest
{

    

    public class Tests
    {

        String IndiaStateCodeCensusFilePath = @"C:\\Users\\com\\Desktop\\csv\\IndiaStateCode.csv";
        String IndiaCensusDataFilePath = @"C:\\Users\\com\\Desktop\\csv\\IndiaStateCensusData.csv";
        String IndiaCensusDataWithDelimiter = @"C:\\Users\\com\\Desktop\\csv\\DelimiterIndiaStateCensusData.csv";
        String IndiaCensusDataWithWrongFile = @"C:\\Users\\com\\Desktop\\csv\\IndiaStateCode.txt";

        [Test]
        public void givenIndiaStateCodecsvFile_ifHasCorrectNumberOFRecord_ShouldReturnTrue() {

            CensusAnalyzerImpli censusAnalyzer = new CensusAnalyzerImpli();
            List<IndiaStateCode> list =censusAnalyzer.loadingStateCensusCSV(IndiaStateCodeCensusFilePath);
            int count = list.Count;
            Assert.AreEqual(37,count);
        }

        [Test]
        public void givenStateCensusData_ifHasCorrectNumberOfRecord_ShouldReturnTrue() {

            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List < StateCensusData >  list= stateCensusAnalyser.loadStateCensusData(IndiaCensusDataFilePath);
            int count = list.Count;
            Console.WriteLine(count);
            Assert.AreEqual(29, count);
        }

        [Test]
        public void givenStateCensusData_ifhasDelimiterIssue_ShouldException() {
            try {
                Delimiter delimiter = new Delimiter();
                List<StateCensusData> list = delimiter.loadData(IndiaCensusDataWithDelimiter);
            }
            catch (CustomException customException) {
                Assert.AreEqual(CustomException.ExceptionType.diliminator_issue,customException.type);

            }   
        }

        [Test]
        public void givenWrongIndiaStateCode_InputFile_ShouldThrowWxception() {
            try {
                WrongFileInput wrongFileInput = new WrongFileInput();
                wrongFileInput.loadFile(IndiaCensusDataWithWrongFile);
            }
            catch (CustomException customException) {
                Assert.AreEqual(CustomException.ExceptionType.Invalid_File, customException.type);
            }
        
        
        
        }


    }
}