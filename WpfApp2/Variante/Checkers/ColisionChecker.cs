using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class ColisionChecker : CheckerBase
    {
        public ColisionChecker(ICondition condition, ICondition acciones) : base(condition, acciones) {  }

        protected override bool Check(GameState gameState, Location futuro) =>
            gameState.Mapa[futuro.X, futuro.Y] == State.Snake && futuro != gameState.Snake.Tail; 
    }
}
