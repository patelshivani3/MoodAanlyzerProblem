using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        public string message;
        public MoodAnalyzer()
        {
            Console.WriteLine("Default Constructor");
        }
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                if (message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else if (message.ToLower().Equals(string.Empty))
                {
                    Console.WriteLine(message);
                    throw new CustomMoodAnalyzerException("Message should not be empty", CustomMoodAnalyzerException.ExceptionTypes.EMPTY_MESSAGE);
                }
                else
                {
                    return "sad";
                }
            }
            catch (NullReferenceException ex)
            {
                throw new CustomMoodAnalyzerException("Message should not be null", CustomMoodAnalyzerException.ExceptionTypes.NULL_MESSAGE);
            }
        }
    }
}
