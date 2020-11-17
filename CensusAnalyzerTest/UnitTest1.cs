using NUnit.Framework;
using CensusAnalyzerProblem;
using System;
using System.Collections.Generic;

namespace CensusAnalyzerTest
{

    

    public class Tests
    {

        String IndiaStateCodeCensusFilePath = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\IndiaStateCode.csv";
        String IndiaCensusDataWithDelimiter = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\DelimiterIndiaStateCensusData.csv";
        String IndiaCensusDataWithWrongFile = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\IndiaStateCode.txt";
        String IndiaCensusDataFilePath1 = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\IndiaStateCensusData.csv";
        String IndiaStateCensusWithoutHeader = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\WrongHeaderIndiaStateCensusData.csv";
        String IndiaCensusAnalyserWithWrong_File = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\IndiaCensusAnalyser.txt";

        String IndiaStateCodeWithDelimiter = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\IndiaStateCode_withDelimiterIssue.csv";



        [Test]
        public void givenIndiaStateCodecsvFile_ifHasCorrectNumberOFRecord_ShouldReturnTrue() {

            CensusAnalyzerImpli censusAnalyzer = new CensusAnalyzerImpli();
            List<IndiaStateCodeDAO> list =censusAnalyzer.loadingStateCensusCSV(IndiaStateCodeCensusFilePath);
            int count = list.Count;
            Assert.AreEqual(37,count);
        }

        [Test]
        public void givenStateCensusData_ifHasCorrectNumberOfRecord_ShouldReturnTrue() {

            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List < CensusDataDAO >  list= stateCensusAnalyser.loadStateCensusData(IndiaCensusDataFilePath1);
            int count = list.Count;
            Console.WriteLine(count);
            Assert.AreEqual(29, count);
        }

        [Test]
        public void givenStateCensusData_ifhasDelimiterIssue_ShouldException() {
            try {
                Delimiter delimiter = new Delimiter();
                delimiter.loadData(IndiaCensusDataWithDelimiter);
            }
            catch (CustomException customException) {
                Assert.AreEqual(CustomException.ExceptionType.diliminator_issue,customException.type);

            }   
        }


        [Test]
        public void givenIndiaSateCodeCsvFile_withDilimiterIssue_ShouldException() {
            try {
                Delimiter delimiter = new Delimiter();
                delimiter.loadData(IndiaStateCodeWithDelimiter);

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

        [Test]
        public void givenIndiaCensusAnalyserWithWrongFile_asInput_ShouldThrowException() {
            try {
                WrongFileInput wrongFileInput = new WrongFileInput();
                wrongFileInput.loadFile(IndiaCensusAnalyserWithWrong_File);
            }
            catch (CustomException customException) {
                Assert.AreEqual(CustomException.ExceptionType.Invalid_File, customException.type);
            
            }
        }

        [Test]
        public void givenStateCensusAnalyser_WithoutHeader_ShouldThrowException() {
            try
            {
                CSVHeaderCheck csvHeaderCheck = new CSVHeaderCheck();
                csvHeaderCheck.loadFile(IndiaStateCensusWithoutHeader);
            }
            catch (CustomException customException)
            {
                Assert.AreEqual(CustomException.ExceptionType.Invalid_Header, customException.type);
            }
        }


        [Test]
        public void givenIndiaStateCodeCSVFile_withoutHeader_ShouldThrowWxception() {
            try
            {
                CSVHeaderCheck cSVHeaderCheck = new CSVHeaderCheck();
                cSVHeaderCheck.loadFile(IndiaStateCodeWithDelimiter);
            }
            catch (CustomException customException)
            {
                Assert.AreEqual(CustomException.ExceptionType.Invalid_Header, customException.type);
            }
        }


        [Test]
        public void givenStateCensusCsv_sortOntheBasisOfStateName() {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
           List<CensusDataDAO> JsonStateCensusData= stateCensusAnalyser.sortByStateName(IndiaCensusDataFilePath1);
            Assert.AreEqual("Andhra Pradesh", JsonStateCensusData[0].State);
        }

        [Test]
        public void givenStateCodeCsvFile_whenSorted_ShouldRetrunSortedList() {
            CensusAnalyzerImpli censusAnalyzerImpli = new CensusAnalyzerImpli();
            List<IndiaStateCodeDAO> sortedIndiaStateCodelist=censusAnalyzerImpli.sortByStateCode(IndiaStateCodeCensusFilePath);
            Assert.AreEqual("AD", sortedIndiaStateCodelist[0].StateCode);
        }


        [Test]
        public void givenStateAnalyserCSVFile_whenSorted_ShouldRetrunSortedList() {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List<CensusDataDAO> sortedStateCensusAnalyserList = stateCensusAnalyser.sortBYPopulation(IndiaCensusDataFilePath1);
            Assert.AreEqual("Uttar Pradesh", sortedStateCensusAnalyserList[sortedStateCensusAnalyserList.Count-1].State);
        
        
        }


    }
}