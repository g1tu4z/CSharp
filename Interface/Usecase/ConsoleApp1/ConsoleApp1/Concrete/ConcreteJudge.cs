using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Concrete
{
    class ConcreteJudge : IJudger<CommandParameter, bool>
    {
        public bool IsValid(CommandParameter param)
        {
            return param.ReturnData;
        }
    }
}
