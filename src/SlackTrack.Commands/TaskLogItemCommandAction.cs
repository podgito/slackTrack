using SlackTrack.Commands.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SlackTrack.Commands
{
    public class TaskLogItemCommandAction : ICommandAction
    {

        public SlackResponse Action(SlackCommand command)
        {
            var parser = new TaskLogItemParser();

            var log = parser.Parse(command);

            return new SlackResponse { Text = string.Format("Added {0} hours working on {1}", log.Hours, log.Name) };
        }

        public bool IsMatch(SlackCommand command)
        {
            Regex rgx = new Regex(TaskLogItemParser.regexPattern, RegexOptions.IgnoreCase);
            return rgx.IsMatch(command.Text);
        }
    }
}
