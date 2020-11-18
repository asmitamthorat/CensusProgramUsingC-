using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
    public class CensusDataDAO
    {
        public string State;
        public int Population;
        public string AreaInSqKm;
        public string DensityPerSqKm;
       



        public CensusDataDAO(StateCensusData stateCensusData)
        {
            this.State = stateCensusData.State;
            this.Population = stateCensusData.Population;
            this.AreaInSqKm = stateCensusData.AreaInSqKm;
            this.DensityPerSqKm = stateCensusData.DensityPerSqKm;
        }

        

    }
}
