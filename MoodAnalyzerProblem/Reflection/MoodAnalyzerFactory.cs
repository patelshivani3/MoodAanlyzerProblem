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

        public object CreateMoodAnalyserParameterizedObject(string className, string constructor, string message)
        { 
            try
            {
                Type type = typeof(MoodAnalyzer);
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    try
                    {
                        if (type.Name.Equals(constructor))
                        {
                            ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                            object instance = constructorInfo.Invoke(new object[] { message });
                            return instance;
                        }
                        else
                        {
                            throw new CustomMoodAnalyzerException("Constructor is not found", CustomMoodAnalyzerException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        throw new CustomMoodAnalyzerException("Constructor is not found", CustomMoodAnalyzerException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                    }
                }
                else
                {
                    throw new CustomMoodAnalyzerException("Class is not found", CustomMoodAnalyzerException.ExceptionTypes.CLASS_NOT_FOUND);
                }
            }
            catch (CustomMoodAnalyzerException ex)
            {
                throw new CustomMoodAnalyzerException(ex.Message, ex.exceptionTypes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string InvokeAnalyzerMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyzer);
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
                object moodAnalyzerObject = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object info = methodInfo.Invoke(moodAnalyzerObject, null);
                return info.ToString();
            }
            catch (CustomMoodAnalyzerException ex)
            {
                if (ex.Message.Equals("Class not found"))
                {
                    throw new CustomMoodAnalyzerException("Class not found", CustomMoodAnalyzerException.ExceptionTypes.CLASS_NOT_FOUND);
                }
                else
                {
                    throw new CustomMoodAnalyzerException("Constructor not found", CustomMoodAnalyzerException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                }
            }
            catch (Exception)
            {
                throw new CustomMoodAnalyzerException("Method not found", CustomMoodAnalyzerException.ExceptionTypes.NO_SUCH_METHOD);
            }
        }
    }
}

