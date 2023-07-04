using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Concrete
{
    class ConcreteMessenger : IMessenger<CommandParameter, bool>
    {
        private ISender<CommandParameter> _sender;
        private IAction<bool> _reciveAction;
        private IAction<bool> _timeoutAction;

        public ConcreteMessenger(ISender<CommandParameter> sender)
        {
            this._sender = sender;
        }

        public void OnRecived(bool result)
        {
            Console.WriteLine("応答受信しましたー");
            _reciveAction?.Action(true);
        }

        public void OnTimeout()
        {
            Console.WriteLine("受信タイムアウトしましたー");
            _timeoutAction?.Action(false);
        }

        public void Send(CommandParameter param)
        {
            _sender?.Send(param);
        }

        public void SetRecivedAction(IAction<bool> reciveAction, IAction<bool> timeoutAction)
        {
            this._reciveAction = reciveAction;
            this._timeoutAction = timeoutAction;
        }
    }
}
