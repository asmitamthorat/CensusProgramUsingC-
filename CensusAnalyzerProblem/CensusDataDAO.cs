using System;
using System.Collections.Generic;
using System.Text;


namespace CensusAnalyzerProblem
{
   public class CensusDataDAO
    {
        public String State;
        public int Population;
        public String AreaInSqKm;
        public String DensityPerSqKm;
      ///  public int SrNo;
     //   public String StateName;
     //   public String TIN;
     //   public String StateCode;


        public CensusDataDAO(StateCensusData stateCensusData) {
            this.State = stateCensusData.State;
            this.Population = stateCensusData.Population;
            this.AreaInSqKm = stateCensusData.AreaInSqKm;
            this.DensityPerSqKm = stateCensusData.DensityPerSqKm;
        }

    //    public CensusDataDAO(IndiaStateCode indiaStateCode) {
    //        this.SrNo = indiaStateCode.SrNo;
     //       this.StateName = indiaStateCode.StateName;
   //         this.TIN = indiaStateCode.TIN;
   //         this.StateCode = indiaStateCode.StateCode;
//        
 //       }


    }
}
