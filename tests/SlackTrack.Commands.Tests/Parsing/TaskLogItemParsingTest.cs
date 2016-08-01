using NUnit.Framework;
using SlackTrack.Commands.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackTrack.Commands.Tests.Parsing
{
    [TestFixture]
    public class TaskLogItemParsingTest
    {
        TaskLogItemParser parser;

        [SetUp]
        public void Setup()
        {
            parser = new TaskLogItemParser();
        }

        [Test, TestCaseSource(typeof(CommandTextParsingHoursSource), "TestCases")]
        public double ParseHours(string text)
        {
            //Arrange
            var command = new SlackCommand { Text = text };

            //Act
            var logItem = parser.Parse(command);
            return logItem.Hours;
        }

        [Test, TestCaseSource(typeof(CommandTextParsingNameSource), "TestCases")]
        public string ParseName(string text)
        {
            //Arrange
            var command = new SlackCommand { Text = text };

            //Act
            var logItem = parser.Parse(command);
            return logItem.Name;
        }

        private class CommandTextParsingHoursSource
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData("2 hours building new feature").Returns(2);
                    yield return new TestCaseData("2.5 hours building new feature").Returns(2.5);
                    yield return new TestCaseData("0.5 hours building new feature").Returns(0.5);
                    yield return new TestCaseData(".5 hours building new feature").Returns(0.5);
                    yield return new TestCaseData("30 mins building new feature").Returns(0.5);
                    yield return new TestCaseData("15 mins building new feature").Returns(0.25);
                }
            }
        }

        private class CommandTextParsingNameSource
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData("2 hours building new feature").Returns("building new feature");
                    yield return new TestCaseData("2.5 hours working on reports").Returns("reports");
                    //yield return new TestCaseData("0.5 hours building new feature").Returns(0.5);
                    //yield return new TestCaseData(".5 hours building new feature").Returns(0.5);
                    //yield return new TestCaseData("30 mins building new feature").Returns(0.5);
                }
            }
        }
    }
}
