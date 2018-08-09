using System;

namespace ColorViewer
{
    internal class DelegateCommand : Command
    {
        private Func<bool> canExecuteMethod;
        private Action executeMethod;

        public DelegateCommand(Action executeMethod) :
            this(executeMethod, () => true)
        {
        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public override bool CanExecute()
        {
            return canExecuteMethod();
        }

        public override void Execute()
        {
            executeMethod();
        }
    }
}