using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Codigo
{
    public class Score
    {
        int score;

        public void Incrementar(int val)
        {
            score += val;
        }

        public override string ToString()
        {
            return score.ToString();
        }
    }
}
