using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Codigo
{
    public class Colocador : IColocador
    {
        Mapa mapa;
        State[] estados;
        Random random = new Random();

        TimeSpan tiempo = TimeSpan.Zero;
        DateTime time = new DateTime();
        Location? lo;
        State coloc;

        public Colocador(Mapa mapa, params State[] estados) => (this.estados, this.mapa) = (estados, mapa);

        private void BorrarAnterior()
        {
            mapa.Remove(lo.Value);
        }

        public void Colocar()
        {
            if (tiempo == TimeSpan.Zero)
            {
                if (lo.HasValue && mapa[lo.Value.X, lo.Value.Y] == coloc)
                    BorrarAnterior();

                var colocado = estados[random.Next() % estados.Length];

                coloc = colocado;
                lo = mapa.Colocar(colocado);
                tiempo = TimeSpan.FromSeconds(10);

                time = DateTime.Now;
            }
            else
            {
                var i = DateTime.Now.Second - time.Second;
                time = DateTime.Now;
                tiempo = tiempo.Subtract(TimeSpan.FromSeconds(i));

                if (tiempo.Seconds <= 0)
                    tiempo = TimeSpan.Zero;
            }
        }
    }

}
