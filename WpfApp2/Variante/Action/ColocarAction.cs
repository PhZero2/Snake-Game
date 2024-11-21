using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    class ColocarAction : ICondition
    {
        State state;
        public ColocarAction(State s)
        {
            state = s;
        }
        public void Execute(GameState gameState, Location futuro)
        {
            gameState.Mapa.Colocar(state);
        }
    }
}
