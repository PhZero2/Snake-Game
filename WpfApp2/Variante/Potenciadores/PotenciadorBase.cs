using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class PotenciadorBaseChecker : ICondition
    {
        ICondition siguiente;
        public PotenciadorBaseChecker(ICondition siguiente) => (this.siguiente) = (siguiente);

        public void Execute(GameState gameState, Location futuro)
        {
            gameState.Executor.Execute(gameState, futuro); 
            siguiente.Execute(gameState, futuro);
        }
    }
}
