using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Concrete
{
    class ConcreteRecivedAction : IAction<bool>
    {
        public void Action(bool param)
        {
            Console.WriteLine(param.ToString() + "で受信処理しましたー");
        }
    }
}
