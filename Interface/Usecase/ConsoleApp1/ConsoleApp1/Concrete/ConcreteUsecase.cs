using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Concrete
{
    class ConcreteUsecase : IUsecase<CommandParameter>
    {
        private IJudger<CommandParameter, bool> _judger;
        private IAction<CommandParameter> _okAction;
        private IAction<CommandParameter> _ngAction;

        public ConcreteUsecase(
            IJudger<CommandParameter, bool> judger,
            IAction<CommandParameter> ngaction,
            IAction<CommandParameter> okaction
            )
        {
            this._judger = judger;
            this._okAction = okaction;
            this._ngAction = ngaction;
        }

        public void Run(CommandParameter param)
        {
            if (false == _judger.IsValid(param))
            {
                _ngAction.Action(param);
                return;
            }
            _okAction.Action(param);
        }
    }
}
