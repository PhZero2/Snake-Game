using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public abstract class CheckerBase : ICondition
    {
        protected ICondition next, action;
        public CheckerBase(ICondition siguiente, ICondition action) => (next, this.action) = (siguiente, action);

        public void Execute(GameState gameState, Location futuro)
        {
            if (Check(gameState, futuro))
                action.Execute(gameState, futuro);
            else
                next.Execute(gameState, futuro);
        }

        protected abstract bool Check(GameState gameState, Location futuro);
    }
}
