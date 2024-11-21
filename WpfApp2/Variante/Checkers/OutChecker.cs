using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class OutChecker : CheckerBase
    {
        public OutChecker(ICondition condition, ICondition acciones) : base(condition, acciones){ }
        protected override bool Check(GameState gameState, Location futuro) =>
                gameState.Mapa.IsInside(futuro);
    }
}
