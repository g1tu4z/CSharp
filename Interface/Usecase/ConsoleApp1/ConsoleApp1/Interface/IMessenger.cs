using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IMessenger<T, A>
    {
        void Send(T param);
        void OnRecived(bool result);
        void OnTimeout();
        void SetRecivedAction(IAction<A> reciveAction, IAction<A> timeoutAction);
    }
}
