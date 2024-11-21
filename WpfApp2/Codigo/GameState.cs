using System;
using System.Threading.Tasks;
using WpfApp2.Variante;

namespace WpfApp2.Codigo
{
    public class GameState
    {
        public Score Score { get; }
        public Mapa Mapa { get; }
        public Snake Snake { get; }

        private IColocador colocador;

        private ICondition condition;

        public IMovimiento Movimiento { get; }
       public IPotenciadorExcecutor Executor { get; }

        public Location Head => Snake.Head;
        public bool GameOver { get; set; } = false;

        public GameState(ICondition condition, Snake snake, Mapa mapa, IColocador colocador, IMovimiento movimiento, IPotenciadorExcecutor exc)
        {
            this.condition = condition;

            Movimiento = movimiento;
            Snake = snake;
            Score = new Score();
            Mapa = mapa;
            this.colocador = colocador;
            Executor = exc;
        }

        public void AddDirection(Direction e)
        {
           Movimiento.AddDirection(e);
        }
        public void Ejecutar()
        {
             
            colocador.Colocar();
            
            var dire = Movimiento.Direction;
            var futuro = Snake.Head.Translate(dire);

            condition.Execute(this, futuro);
        }

        private Mapa Inicializar(Location loc)
        {
            Mapa m = new Mapa(loc.X, loc.Y);
            Location val = new Location(loc.X / 2, 1);

            for (int i = 0; i < 3; i++)
            {
                m.Add(val, State.Snake);
                Snake.Grow(val);
                val = val.Translate(Direction.Rigth);
            }

            return m;
        }
    }
}