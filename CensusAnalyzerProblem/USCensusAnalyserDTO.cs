using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
   public class USCensusAnalyserDTO
    {

        public String StateId { get; set; }

        public String State { get; set; }

        public int Population { get; set; }
        public int HousingUnits { get; set; }
            
        public float TotalArea { get; set; }
            
        public float WaterArea { get; set; }
        public float LandArea { get; set; }

        public float PopulationDensity { get; set; }
        public float HousingDensity { get; set; }

        public override string ToString()
        {
            return $"StateId {StateId}: State: {State},Population: {Population}, HousingUnits: {HousingUnits},TotalArea: {TotalArea},WaterArea: {WaterArea},LandArea: {LandArea},PopulationDensity: {PopulationDensity},HousingDensity:{HousingDensity}";
        }




    }
}
