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
        String USCensusData = @"C:\\Users\\com\\source\\repos\\CensusAnalyzerProblem\\CensusAnalyzerTest\\utilities\\USCensusData.csv";



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
                Assert.AreEqual(CustomException.ExceptionType.INVALID_DILIMINATOR,customException.type);

            }   
        }


        [Test]
        public void givenIndiaSateCodeCsvFile_withDilimiterIssue_ShouldException() {
            try {
                Delimiter delimiter = new Delimiter();
                delimiter.loadData(IndiaStateCodeWithDelimiter);

            }
            catch (CustomException customException) {
                Assert.AreEqual(CustomException.ExceptionType.INVALID_DILIMINATOR,customException.type);
            }
        
        
        }

        [Test]
        public void givenWrongIndiaStateCode_InputFile_ShouldThrowWxception() {
            try {
                WrongFileInput wrongFileInput = new WrongFileInput();
                wrongFileInput.loadFile(IndiaCensusDataWithWrongFile);
            }
            catch (CustomException customException) {
                Assert.AreEqual(CustomException.ExceptionType.INVALID_FILE, customException.type);
            }      
        }

        [Test]
        public void givenIndiaCensusAnalyserWithWrongFile_asInput_ShouldThrowException() {
            try {
                WrongFileInput wrongFileInput = new WrongFileInput();
                wrongFileInput.loadFile(IndiaCensusAnalyserWithWrong_File);
            }
            catch (CustomException customException) {
                Assert.AreEqual(CustomException.ExceptionType.INVALID_FILE, customException.type);
            
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
                Assert.AreEqual(CustomException.ExceptionType.INVALID_HEADER, customException.type);
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
                Assert.AreEqual(CustomException.ExceptionType.INVALID_HEADER, customException.type);
            }
        }


        [Test]
        public void givenStateCensusCsv_sortOntheBasisOfStateName() {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
           List<CensusDataDAO> JsonStateCensusData= stateCensusAnalyser.sortByStateName(IndiaCensusDataFilePath1);
            Assert.AreEqual("Andhra Pradesh", JsonStateCensusData[0].State);
        }

        [Test]
        public void givenStateCodeCsvFile_whenSorted_ShouldRetrunSortedList() 
        {
            CensusAnalyzerImpli censusAnalyzerImpli = new CensusAnalyzerImpli();
            List<IndiaStateCodeDAO> sortedIndiaStateCodelist=censusAnalyzerImpli.sortByStateCode(IndiaStateCodeCensusFilePath);
            Assert.AreEqual("AD", sortedIndiaStateCodelist[0].StateCode);
        }


        [Test]
        public void givenStateAnalyserCSVFile_whenSortedwithPopulation_ShouldRetrunSortedList() 
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List<CensusDataDAO> sortedStateCensusAnalyserList = stateCensusAnalyser.sortBYPopulation(IndiaCensusDataFilePath1);
            Assert.AreEqual("Uttar Pradesh", sortedStateCensusAnalyserList[sortedStateCensusAnalyserList.Count-1].State); 
        }


        [Test]
        public void givenStateAnalyserCSVFile_whenSortedWithPopulationDensity_ShouldReturnSortedList() 
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List<CensusDataDAO> sortedStateCensusAnalyserList = stateCensusAnalyser.sortByPopulationDensity(IndiaCensusDataFilePath1);
            Assert.AreEqual("West Bengal", sortedStateCensusAnalyserList[0].State);
        }


        [Test]
        public void givenIndiaStateCodeCSVFile_WhenSortedWithsStateArea_ShoudlReturnSortedList() 
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            List<CensusDataDAO> sortedStateCensusAnalyserList = stateCensusAnalyser.sortByStateArea(IndiaCensusDataFilePath1);
            Assert.AreEqual("Tripura", sortedStateCensusAnalyserList[0].State);
        }

        [Test]
        public void givenUSCensusData_ifHasCorrectNumberOfRecord_ShouldTrue() 
        {

            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
           List<USCensusAnalyserDAO> list= uSCensusAnalyser.loadUSCensusData(USCensusData);
            int count = list.Count;
            Assert.AreEqual(51,count); 
        }
        
        [Test]
        public void givenUSCensusCSV_WhenSortedBasedONPopulation_ShouldRetrunSortedList()
        {
            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            List<USCensusAnalyserDAO> list = uSCensusAnalyser.sortByPopulation(USCensusData);
            Assert.AreEqual("California", list[list.Count-1].State);

        }

       [Test]
        public void givenUSCensusCSV_WhenSortedBasedOnPopulationDensity_ShouldRetrunSortedList()
        {
            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            List<USCensusAnalyserDAO> list = uSCensusAnalyser.sortByPopulationDensity(USCensusData);
            Assert.AreEqual("District of Columbia", list[list.Count - 1].State);
        }

        [Test]
        public void givenUSCensusCSV_WhenSortedBasedOnArea_SholdReturnSortedList() 
        {

            USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
            List<USCensusAnalyserDAO> list = uSCensusAnalyser.sortByArea(USCensusData);
            Assert.AreEqual("Alaska", list[list.Count - 1].State);
        
        
        }

        [Test]
        public void givenTXT_Input() {
            try {
                USCensusAnalyser uSCensusAnalyser = new USCensusAnalyser();
                List<USCensusAnalyserDAO> list = uSCensusAnalyser.loadUSCensusData(IndiaCensusAnalyserWithWrong_File);
            }
            catch (CustomException customException) {
                Assert.AreEqual(CustomException.ExceptionType.INVALID_FILE, customException.type);
            }
        
        
        }
        


    }
}