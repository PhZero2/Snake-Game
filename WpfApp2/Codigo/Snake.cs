using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Codigo
{
    public class Snake
    {
        private LinkedList<Location> snake = new LinkedList<Location>(); 

        public int Lenght { get => snake.Count; }
        public void Grow(Location location) => snake.AddFirst(location);
        public void Move(Location nueva)
        {
            snake.RemoveLast();
            snake.AddFirst(nueva);
        }
        public void Remove() => snake.RemoveLast();

        public Location Head => snake.First.Value;
        public Location Tail => snake.Last.Value;
    }
}
