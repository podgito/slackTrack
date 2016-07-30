using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackTrack.Commands
{
    public class CommandReader
    {
        private readonly IEnumerable<ICommandAction> commands;

        public CommandReader(IEnumerable<ICommandAction> commands)
        {
            this.commands = commands;
        }

        public ICommandAction GetCommandAction(SlackCommand command)
        {
            throw new NotImplementedException();
        }
            


    }


}
