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
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {

            if (message.ToLower().Contains("sad"))
            {
                return "sad";
            }
            else
            {
                return "happy";
            }

        }
    }
}
