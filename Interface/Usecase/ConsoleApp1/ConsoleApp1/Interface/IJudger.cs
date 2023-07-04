using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IJudger<T, R>
    {
        R IsValid(T param);
    }
}
