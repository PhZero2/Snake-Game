using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Codigo
{
    public class Direction
    {
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);
        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Rigth = new Direction(0, 1);

        public int X { get; }
        public int Y { get; }

        private Direction(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public Direction Oposite()
        {
            if (this == Up)
                return Down;

            if (this == Down)
                return Up;

            if (this == Left)
                return Rigth;

            if(this == Rigth)
            return Left;
            return null;
        }
        
    }
}
