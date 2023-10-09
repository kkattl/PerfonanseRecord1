using System;

namespace PerfomanceRecord1.View.Command
{
    public class ConcreteCommand : ICommand
    {
        private Action _action;

        public ConcreteCommand(Action action)
        {
            _action = action;
        }

        public void Execute()
        {
            _action.Invoke();
        }
    }
}
