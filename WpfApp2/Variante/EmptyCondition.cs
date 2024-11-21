using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class EmptyCondition : ICondition
    {
        public static ICondition Empty { get; } = new EmptyCondition();

        private EmptyCondition() { }
        public void Execute(GameState context, Location futuro)
        {
           
        }
    }
}
