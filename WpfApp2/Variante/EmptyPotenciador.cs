using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class EmptyPotenciador : IConditionPotenciador
    {
        public static IConditionPotenciador Empty = new EmptyPotenciador();

        private EmptyPotenciador() { }


        public TimeSpan Tiempo => TimeSpan.Zero;

        public void Execute(GameState gameState, Location futuro)
        {
           
        }
    }
}
