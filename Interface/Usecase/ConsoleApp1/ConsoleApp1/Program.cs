using ConsoleApp1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var msg = new ConcreteMessenger(new ConcreteSender());

            new ConcreteUsecase(
                new ConcreteJudge(),
                new ConcreteNGAction(),
                new ConcreteOKAction(msg)
                )
                .Run(new CommandParameter());

            msg.OnRecived(true);
            msg.OnTimeout();
        }
    }
}
