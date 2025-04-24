using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    public class Buff
    {
        public Effect _Effect { get; set; }
        public int RemainingTurn { get; set; }

        public Buff(Effect effect, int duration)
        {
            _Effect = effect;
            RemainingTurn = duration;
        }

        public void Apply(Unit target)
        {
            _Effect.Apply(target);
            RemainingTurn--;
        }

        public bool IsExpired => RemainingTurn <= 0;
    }
}
