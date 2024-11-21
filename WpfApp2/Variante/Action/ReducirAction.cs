using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class ReducirAction : ICondition
    {
        public void Execute(GameState gameState, Location futuro)
        {
            gameState.Mapa.Remove(gameState.Snake.Tail);
            gameState.Snake.Remove();
        }
    }
}
