using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class AddPotenciadorAction : ICondition
    {
        Func<IConditionPotenciador> potenciador;

        public AddPotenciadorAction(Func<IConditionPotenciador> pot) => potenciador = pot;
        public void Execute(GameState gameState, Location futuro)
        {
            gameState.Executor.AgregarPotenciador(potenciador());
        }
    }
}
