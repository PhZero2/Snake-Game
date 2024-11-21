using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class StateChecker : CheckerBase
    {
        private State status;
        public StateChecker(ICondition next, ICondition acciones, State state) : base(next, acciones) 
            => status = state;

        protected override bool Check(GameState gameState, Location futuro) =>
            gameState.Mapa[futuro.X, futuro.Y] == status;
    }
}
