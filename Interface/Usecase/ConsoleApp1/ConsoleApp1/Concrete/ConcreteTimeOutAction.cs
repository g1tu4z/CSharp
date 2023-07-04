using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Concrete
{
    class ConcreteTimeOutAction : IAction<bool>
    {
        public void Action(bool param)
        {
            Console.WriteLine(param.ToString() + "で受信タイムアウト処理しましたー");
        }
    }
}
