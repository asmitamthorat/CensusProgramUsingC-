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
        


        public CensusDataDAO(StateCensusData stateCensusData)
        {
            this.State = stateCensusData.State;
            this.Population = stateCensusData.Population;
            this.AreaInSqKm = stateCensusData.AreaInSqKm;
            this.DensityPerSqKm = stateCensusData.DensityPerSqKm;
        }


      
    }
}
