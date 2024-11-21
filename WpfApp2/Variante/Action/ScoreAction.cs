using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class ScoreAction : ICondition
    {
        int cant;
        public ScoreAction(int cant) => this.cant = cant;
        public void Execute(GameState gameState, Location futuro)
        {
            gameState.Score.Incrementar(cant);
        }
    }
}
