﻿using System.Collections.Generic;

namespace PerfomanceRecord1.View.Command
{
    public class CommandInvoker
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
        public void ClearCommands()
        {
            _commands.Clear();
        }


    }
}
