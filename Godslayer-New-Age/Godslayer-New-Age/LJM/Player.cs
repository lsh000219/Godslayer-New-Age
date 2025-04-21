using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    internal class Player : Unit
    {
        public Player(string name, int level, float exp, float hp, float mp, float damage,
            float defence, int gold, float critRate, float critDmg, float dodgeRate)
        : base(name, level, exp, hp, mp, damage, defence, gold, critRate, critDmg, dodgeRate)
        { 
           
        }
    }
}
