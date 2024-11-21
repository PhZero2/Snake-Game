﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Codigo;

namespace WpfApp2.Variante
{
    public class AdicionarAction : ICondition
    {
        State v;
        public AdicionarAction(State e) => v = e;
        public void Execute(GameState gameState, Location futuro)
        {
            gameState.Mapa.Add(futuro, v);
        }
    }
}
