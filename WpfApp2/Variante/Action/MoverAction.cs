using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class MoverAction : ICondition
    {
        public void Execute(GameState gameState, Location futuro)
        {
            gameState.Mapa.Interchange(futuro, gameState.Snake.Tail, State.Snake);
            gameState.Snake.Move(futuro);
        }
    }
}
