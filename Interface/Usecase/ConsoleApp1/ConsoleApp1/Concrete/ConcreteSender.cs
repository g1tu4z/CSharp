using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Concrete
{
    class ConcreteSender : ISender<CommandParameter>
    {
        public void Send(CommandParameter param)
        {
            Console.WriteLine("Senderで次のメッセージを送信：" + param.SendMessage);
        }
    }
}
