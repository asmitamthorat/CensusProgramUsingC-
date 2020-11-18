using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CensusAnalyzerProblem
{
    public class WrongFileInput
    {
        public void loadFile(String fileName) {
            FileInfo file = new FileInfo(fileName);
            String FileExtension = file.Extension;
            if (FileExtension != ".csv") {
                throw new CustomException(CustomException.ExceptionType.INVALID_FILE, "not a csv file");
            }

        }
    }
}
