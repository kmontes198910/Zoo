using System;

namespace Shared.Domain.Bus.Command
{
    public class CommandNotRegisteredError : Exception
    {
        public CommandNotRegisteredError(global::Shared.Domain.Bus.Command.Command command) : base(
            $"The command {command} has not a command handler associated")
        {
        }
    }
}
