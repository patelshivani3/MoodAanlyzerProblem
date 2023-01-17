using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using System;

namespace MoodAnalyzerTestProject
{
    [TestClass]
    public class MoodAnalyzerTest
    {
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
    }
}
