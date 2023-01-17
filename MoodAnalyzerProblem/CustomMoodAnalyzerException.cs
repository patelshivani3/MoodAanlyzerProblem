using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class CustomMoodAnalyzerException : Exception
    {
        public ExceptionTypes exceptionTypes;
        public enum ExceptionTypes
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
            CLASS_NOT_FOUND,
            NO_SUCH_METHOD,
            CONSTRUCTOR_NOT_FOUND,
        }
        public CustomMoodAnalyzerException(string msg, ExceptionTypes exceptionTypes) : base(msg)
        {
            this.exceptionTypes = exceptionTypes;
            Console.WriteLine(msg);
        }
    }
}
