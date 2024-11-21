using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class MultiplyPotenciador : IConditionPotenciador
    {
        int factor;
        Func<State, int> calc;

        public MultiplyPotenciador(int factor, int duration, Func<State, int> calculador) =>
            (this.factor, this.Tiempo, calc) = (factor, TimeSpan.FromSeconds(duration), calculador);

        public TimeSpan Tiempo { get; }

        public void Execute(GameState gameState, Location futuro)
        {
            gameState.Score.Incrementar(factor * calc(gameState.Mapa[futuro.X, futuro.Y]));
        }
    }
}
