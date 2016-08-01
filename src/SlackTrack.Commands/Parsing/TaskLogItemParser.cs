using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SlackTrack.Commands.Parsing
{
    class TaskLogItemParser
    {
        //public const string regexPattern = @"[-+]?([0-9]*\.[0-9]+|[0-9]+)\s+(\bhour(?:s)?\b|\bdays\b)\s+(?:working\s+)?(?:on\s+)?([a-z0-9 ]*)";
        public const string regexPattern = @"[-+]?(?<time>[0-9]*\.[0-9]+|[0-9]+)\s+(?<timeUnit>\bmin(?:ute)?(?:s)?\b|\bh(?:our)?(?:s)?\b|\bdays\b)\s+(?:working\s+)?(?:on\s+)?(?<taskName>[a-z0-9 ]*)";
        //[-+]?(?<time>[0-9]*\.[0-9]+|[0-9]+)\s+(?<timeUnit>\bhour(?:s)?\b|\bdays\b)\s+(?:working\s+)?(?:on\s+)?(?<taskName>[a-z0-9 ]*)
        //[-+]?(?P<time>[0-9]*\.[0-9]+|[0-9]+)\s+(?P<timeUnit>\bhour(?:s)?\b|\bdays\b)\s+(?:working\s+)?(?:on\s+)?(?P<taskName>[a-z0-9 ]*)
        public TaskLogItem Parse(SlackCommand command)
        {
            Regex rgx = new Regex(regexPattern, RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(command.Text)) throw new ArgumentException("Command text format is invalid");

            var match = rgx.Match(command.Text);

            double time = 0;
            double.TryParse(match.Groups["time"].Value, out time);
            var timeUnit = match.Groups["timeUnit"].Value;

            var timeInHours = ConvertTimeToHours(time, timeUnit);

            var taskName = match.Groups["taskName"].Value;

            

            return  new TaskLogItem { UserId = command.User_id, Hours = timeInHours, Name = taskName, Categories = null };
        }

        

        private double ConvertTimeToHours(double time, string timeUnit)
        {
            double timeInHours = 0;
            switch(timeUnit.ToLower())
            {
                case "h":
                case "hour":
                case "hours":
                    timeInHours = time;
                    break;
                case "min":
                case "mins":
                case "minute":
                case "minutes":
                    timeInHours = time / 60;
                    break;
                    
            }

            return timeInHours;


        }

    }
}
