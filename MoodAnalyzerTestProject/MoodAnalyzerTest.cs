using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using MoodAnalyzerProblem.Reflection;
using System;

namespace MoodAnalyzerTestProject
{
    [TestClass]
    public class MoodAnalyzerTest
    {
        MoodAnalyzerFactory factory = new MoodAnalyzerFactory();

        [TestMethod]
        [TestCategory ("Exception") ]
        //UC1 T.C-1.1,1.2
        //[DataRow("I am in sad mood", "sad")]
        //[DataRow("I am in Any mood", "happy")]
        //UC2 T.C-2.1
        [DataRow(null, "happy")]
        public void Given_Message_Should_Return_TypeOf_Mood(string message, string expected)
        {
            try
            {
                //Arrange
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
                //Act
                string actual = moodAnalyzer.AnalyseMood();

                if (actual != null)
                    Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CustomException")]
        //UC-3
        //T.C-3.1[Null Message]
        //T.C-3.2[Empty Message]
        public void Given_Message_Should_Return_Custom_Exception()
        {
            string expected = "Message should not be empty";
            try
            {
                //Arrange
                string message = "";
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
                //Act
                string actual = moodAnalyzer.AnalyseMood();
            }
            catch (CustomMoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Reflection")]
        //UC-4
        //T.C.4.1
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer")]
        //T.C.4.2
        [DataRow("MoodAnalyzerProblem.Customer", "Customer")]
        //T.C.4.3
        //[DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer1")]
        public void Gievn_Class_Info_Return_Default_Constructor(string className, string constructor)
        {
            string expectedMsg = "Class not found";
            
            try
            {
                //AAA Methodology
                //Arrange
                Object expected = new MoodAnalyzer();
                object actual = factory.CreateMoodAnalyzer(className, constructor);
                //Act
                actual.Equals(expected);
            }
            catch (CustomMoodAnalyzerException ex)
            {
                //Assert
                Assert.AreEqual(expectedMsg, ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Reflection")]
        //UC-5
        public void Given_MoodAnalyser_With_Message_Using_Reflection_Return_Parameterized_Constructor()
        {
            //string mesaage = "I am in happy mood";
            Object expected = new MoodAnalyzer("Happy");
            object actual = null;
            try
            {
                //AAA methodology
                //Act
                actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyzer", "MoodAnalyzer", "Happy");
                actual.Equals(expected);
            }
            catch (CustomMoodAnalyzerException exception)
            {
                //Assert
                Assert.AreEqual("Constructor not found", exception.Message);
            }
        }
    }
}
