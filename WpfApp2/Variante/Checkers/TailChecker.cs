using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class TailChecker : CheckerBase
    {
        public TailChecker(ICondition siguiente, ICondition action) : base(siguiente, action)
        {
        }

        protected override bool Check(GameState gameState, Location futuro) =>
            gameState.Snake.Tail == futuro;
    }
}
