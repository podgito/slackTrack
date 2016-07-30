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

        LogTaskCommandAction commandAction;

        [SetUp]
        public void Setup()
        {
            commandAction = new LogTaskCommandAction();
        }

        [Test]
        [TestCaseSource(typeof(CommandTextSource))]
        public void IsMatch_For_All_Following_Command_Text(string text)
        {
            //Assert
            var command = new SlackCommand { Text = text };

            //Act
            var isMatch = commandAction.IsMatch(command);

            //Assert
            isMatch.ShouldBeTrue();
        }

        private class CommandTextSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var list = new List<string> {
                    "2 hours building new feature",
                    "2 hours on new feature",
                    "2 hours working on building new feature",
                    "2.5 hours working on building new feature",
                    "2.5 hours  working on building new feature ",

                };

                return list.GetEnumerator();
            }
        }

    }
}
