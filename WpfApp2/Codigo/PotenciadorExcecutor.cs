using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Variante;

namespace WpfApp2.Codigo
{
    public interface IPotenciadorExcecutor : ICondition
    {
        bool AgregarPotenciador(IConditionPotenciador accion);
    }

    public class PotenciadorExcecutor : IPotenciadorExcecutor
    {
        private DateTime time;
        private TimeSpan span;
        private IConditionPotenciador action = EmptyPotenciador.Empty;
        public bool AgregarPotenciador(IConditionPotenciador accion)
        {
            if (accion != null && IsValid(accion))
            {
                this.time = DateTime.Now;
                this.span = accion.Tiempo;

                this.action = accion;
                return true;
            }
            return false;
        }

        private bool IsValid(IConditionPotenciador accion) =>
           span == TimeSpan.Zero;

        private void DisminuirTiempo()
        {
            var i = DateTime.Now.Second - time.Second;
            time = DateTime.Now;
            span = span.Subtract(TimeSpan.FromSeconds(i));

            if (span.Seconds <= 0)
                span = TimeSpan.Zero;
        }

        public void Execute(GameState gameState, Location futuro)
        {
            if (span != TimeSpan.Zero)
            {
                this.action.Execute(gameState, futuro);
                DisminuirTiempo();
            }
        }
    }
}
