using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Concrete
{
    class ConcreteNGAction : IAction<CommandParameter>
    {
        public void Action(CommandParameter param)
        {
            Console.WriteLine(param.NGData);
        }
    }
}
