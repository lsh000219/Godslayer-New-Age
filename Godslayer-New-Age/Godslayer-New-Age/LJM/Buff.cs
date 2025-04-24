using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{



    public class Buff
    {
        public string _Name { get; set; }
        public Effect _Effect { get; set; }
        public int RemainingTurn { get; set; }

        public Buff(string name, Effect effect, int duration)
        {
            _Name = name;
            _Effect = effect;
            RemainingTurn = duration;
        }

        //    이름, 버프 타입, 지속 턴
        public Buff poison = new Buff("독", new Effect(EffectType.DrainHP, 30), 5);

        public void Apply(Unit target)
        {
            _Effect.Apply(target);
            RemainingTurn--;
        }

        public bool IsExpired => RemainingTurn <= 0;
    }
}
