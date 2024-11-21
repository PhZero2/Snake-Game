using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public interface ICondition
    {
        void Execute(GameState gameState, Location futuro);
    }
}
