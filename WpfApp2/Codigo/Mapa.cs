using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Codigo
{
    public class DataEventArgs : EventArgs
    {
        public Location Location { get; }
        public State State { get; }

        public DataEventArgs(Location loca, State state) => (this.Location, this.State) = (loca, state);

    }

    public class Mapa
    {
        private State[,] mapa;

        public event EventHandler<DataEventArgs> ActionEventHandler;

        public Mapa(int cantX, int cantY)
        {
            mapa = new State[cantX, cantY];
            //libre = cantX * cantY - 3;
        }

        public State this[int x, int y]
        {
            get => mapa[x, y];
        }

        public Location? Colocar(State state)
        {
            //#warning si se acaba el espacio se rompe
            var pos = EmptyPosition();

            mapa[pos.X, pos.Y] = state;

            OnAction(new DataEventArgs(pos, state));

            return pos;
        }

        public void Add(Location location, State elem)
        {
            mapa[location.X, location.Y] = elem;

            OnAction(new DataEventArgs(location, elem));

        }
        public void Interchange(Location nueva, Location vieja, State element)
        {
            //this.mapa[vieja.X, vieja.Y] = State.Vacio;
            Remove(vieja);
            this.mapa[nueva.X, nueva.Y] = element;

            OnAction(new DataEventArgs(nueva, element));
        }
        public void Remove(Location loca)
        {
            this.mapa[loca.X, loca.Y] = State.Vacio;

            OnAction(new DataEventArgs(loca, State.Vacio));
        }

        public bool IsInside(Location location) =>
                        location.X < 0 || 
                        location.Y < 0 || 
                        location.X >= this.mapa.GetLength(0) ||
                        location.Y >= this.mapa.GetLength(1);

        private Location EmptyPosition()
        {
            Random rnd = new Random();
            int x, y;
            do
            {
                x = rnd.Next() % mapa.GetLength(0);
                y = rnd.Next() % mapa.GetLength(1);
            }
            while (mapa[x, y] != State.Vacio);

            return new Location(x, y);

        }

        protected virtual void OnAction(DataEventArgs e)
        {
            ActionEventHandler?.Invoke(this, e);
        }
    }
}