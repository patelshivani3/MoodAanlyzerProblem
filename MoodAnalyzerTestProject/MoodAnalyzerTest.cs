using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using System;

namespace MoodAnalyzerTestProject
{
    [TestClass]
    public class MoodAnalyzerTest
    {
        [TestMethod]
        [DataRow("I am in sad mood", "sad")]
        [DataRow("I am in Any mood", "happy")]
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
