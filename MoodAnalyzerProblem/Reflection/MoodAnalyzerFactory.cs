using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem.Reflection
{
    public class MoodAnalyzerFactory
    {
        public object CreateMoodAnalyzer(string className, string constructor)
        {
            //MoodAnalyzerProblem.MoodAnalyzer
            string pattern = "." + constructor + "$";
            bool result = Regex.IsMatch(className, pattern);
            if (result)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyzerType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyzerType);
                }
                catch (Exception ex)
                {
                    throw new CustomMoodAnalyzerException("Class not found", CustomMoodAnalyzerException.ExceptionTypes.CLASS_NOT_FOUND);
                }
            }
            else
            {
                throw new CustomMoodAnalyzerException("Constructor not found", CustomMoodAnalyzerException.ExceptionTypes.NO_SUCH_METHOD);
            }
        }
    }
}
