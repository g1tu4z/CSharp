using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Concrete
{
    class ConcreteOKAction : IAction<CommandParameter>
    {
        private IMessenger<CommandParameter, bool> _messenger;

        public ConcreteOKAction(IMessenger<CommandParameter, bool> messenger)
        {
            this._messenger = messenger;
        }

        public void Action(CommandParameter param)
        {
            Console.WriteLine(param.OKData);
            _messenger.SetRecivedAction(
                new ConcreteRecivedAction(),
                new ConcreteTimeOutAction()
                );
            _messenger.Send(param);
        }
    }
}
