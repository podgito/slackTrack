using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackTrack.Commands
{
    public class TaskLogItem
    {
        public string UserId { get; set; }

        public double Hours { get; set; }
        public string Name { get; set; }
        public string[] Categories { get; set; }

    }
}
