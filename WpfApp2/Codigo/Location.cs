using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Codigo
{
    public struct Location
    {
         public int X { get; }
         public int Y { get; }

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Location Translate(Direction direccion) => new Location(direccion.X + this.X, direccion.Y + Y);

        public override bool Equals(object obj)
        {
            if (!(obj is Location))
            {
                return false;
            }

            var location = (Location)obj;
            return X == location.X &&
                   Y == location.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Location e1, Location e2)
        {
            return e1.X == e2.X && e1.Y == e2.Y;
        }
        public static bool operator !=(Location e1, Location e2)
        {
            return !(e1 == e2);
        }
    }
}
