using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzerProblem
{
    public class CustomException:Exception
    {
        public enum ExceptionType { 
        
        INVALID_HEADER,INVALID_FILE,INVALID_DILIMINATOR
        }

        public readonly ExceptionType type;

        public CustomException(ExceptionType type, string messge) : base(messge) {

            this.type = type;
        }
    }
}
