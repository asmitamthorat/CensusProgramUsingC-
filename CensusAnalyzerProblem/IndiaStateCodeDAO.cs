using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
    public class IndiaStateCodeDAO
    {
        public int SrNo;
        public String StateName;
        public String TIN;
        public String StateCode;


        public IndiaStateCodeDAO(IndiaStateCode indiaStateCode)
        {
            this.SrNo = indiaStateCode.SrNo;
            this.StateName = indiaStateCode.StateName;
            this.TIN = indiaStateCode.TIN;
            this.StateCode = indiaStateCode.StateCode;


        }
    }
}
