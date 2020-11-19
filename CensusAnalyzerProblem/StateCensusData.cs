using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
   public class StateCensusData
    {
        public string State { get; set; }
        public int  Population { get; set; }
        public string AreaInSqKm { get; set; }
        public string DensityPerSqKm { get; set; }


        public override string ToString()
        {
            return $"State {State}: Population: {Population},AreaInSqKm: {AreaInSqKm}, DensityPerSqKm: {DensityPerSqKm}";
        }
    }
}
