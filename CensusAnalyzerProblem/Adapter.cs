using CsvHelper;
using System;
using System.IO;

namespace CensusAnalyzerProblem
{
   public class Adapter
    {
        public static void loadtheData(String path) {
            using (StreamReader reader = new StreamReader(path))
            {

                String data = reader.ReadLine();

                if (!data.Contains(","))
                {

                    throw new CustomException(CustomException.ExceptionType.INVALID_DILIMINATOR, "dilimiter issue");
                }
                var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
                if (!csv.Configuration.HasHeaderRecord)
                {

                    throw new CustomException(CustomException.ExceptionType.INVALID_HEADER, "csv file doesn't have header");

                }

            }

        }
    }
}
