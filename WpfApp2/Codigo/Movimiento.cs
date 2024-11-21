using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Codigo
{
    public class Movimiento : IMovimiento
    {
        private LinkedList<Direction> dirBuffer = new LinkedList<Direction>();
        private Direction direction;

        public Movimiento(Direction direccionInicial) => direction = direccionInicial;
        public Direction Direction
        {
            get
            {
                SigDire();

                return direction;
            }
        } 
        public void AddDirection(Direction direction)
        {
            if (Aceptada(direction) && CanChangeDirection(direction))
                dirBuffer.AddLast(direction);
        }

        private Direction GetLastDirection() => dirBuffer.Count == 0 ? Direction : dirBuffer.Last.Value;
        private bool Aceptada(Direction dir) => dir != this.Direction.Oposite();
        private void SigDire()
        {
            if (dirBuffer.Count > 0)
            {
                direction = dirBuffer.First();
                dirBuffer.RemoveFirst();
            }
        }
        private bool CanChangeDirection(Direction dir)
        {
            if (dirBuffer.Count == 2)
                return false;

            Direction las = GetLastDirection();

            return dir != las && dir != las.Oposite();
        }
    }
}
