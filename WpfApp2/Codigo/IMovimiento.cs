using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Codigo
{
    public interface IMovimiento
    {
        void AddDirection(Direction direction);
        Direction Direction { get; }
    }
}
