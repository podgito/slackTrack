using NUnit.Framework;
using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackTrack.Commands.Tests
{
    [TestFixture]
    public class LogTaskCommandActionTest
    {

        TaskLogItemCommandAction commandAction;

        [SetUp]
        public void Setup()
        {
            commandAction = new TaskLogItemCommandAction();
        }

        [Test]
        [TestCaseSource(typeof(CommandTextMatchingSource), "TestCases")]
        public bool IsMatch_For_All_Following_Command_Text(string text)
        {
            //Assert
            var command = new SlackCommand { Text = text };

            //Act
            return commandAction.IsMatch(command);
        }

        private class CommandTextMatchingSource
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData("1 hour building new feature").Returns(true);
                    yield return new TestCaseData("2 hours building new feature").Returns(true);
                    yield return new TestCaseData("2h building new feature").Returns(true);
                    yield return new TestCaseData("2 h building new feature").Returns(true);
                    yield return new TestCaseData("2 hours on new feature").Returns(true);
                    yield return new TestCaseData("2 hours working on major fix").Returns(true);
                    yield return new TestCaseData("2.5 hours working on building new feature").Returns(true);
                    yield return new TestCaseData("2.5 hours  working on building new feature ").Returns(true);
                    yield return new TestCaseData("2.5 hours on new feature").Returns(true);
                    yield return new TestCaseData("2.5 hours on new feature #newfeature").Returns(true);
                    yield return new TestCaseData("2.5 hours  on new feature#newfeature ").Returns(true);
                    yield return new TestCaseData(".5 hours on new feature#newfeature").Returns(true);
                    yield return new TestCaseData("0.5 hours on new feature#newfeature").Returns(true);
                    yield return new TestCaseData("30 mins on new feature#newfeature").Returns(true);
                    yield return new TestCaseData("30 minutes on new feature#newfeature").Returns(true);
                    yield return new TestCaseData("1 hour").Returns(false);
                    yield return new TestCaseData("asdfasdf").Returns(false);
                }
            }
        }

        

    }
}
