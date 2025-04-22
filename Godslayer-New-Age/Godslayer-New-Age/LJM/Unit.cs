using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    internal class Unit
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public float EXP { get; set; }
        public float MaxHP { get; set; }
        public float HP { get; set; }
        public float MaxMP { get; set; }
        public float MP { get; set; }
        public float Damage { get; set; }
        public float Defence { get; set; }
        public int Gold { get; set; }
        public float CritRate { get; set; }
        public float CritDmg { get; set; }
        public float Speed { get; set; }
        public float DodgeRate { get; set; }
        public bool CanMove { get; set; }

        //    플레이어 생성자
        public Unit(string name, int level, float exp, float maxHP, float hp, float maxMP, float mp, float damage, float defence,
            int gold, float critRate, float critDmg, float speed, float dodgeRate, bool canMove)
        {
            Name = name;
            Level = level;
            EXP = exp;
            MaxHP = maxHP;
            HP = hp;
            MaxMP = maxMP;
            MP = mp;
            Damage = damage;
            Defence = defence;
            Gold = gold;
            CritRate = critRate;
            CritDmg = critDmg;
            Speed = speed;
            DodgeRate = dodgeRate;
            CanMove = canMove;
        }

        //    적 생성자
        public Unit(string name, float hp, float mp, float damage, float defence,
            int gold, float critRate, float critDmg, float speed, float dodgeRate, bool canMove)
        {
            Name = name;
            HP = hp;
            MP = mp;
            Damage = damage;
            Defence = defence;
            Gold = gold;
            CritRate = critRate;
            CritDmg = critDmg;
            Speed = speed;
            DodgeRate = dodgeRate;
            CanMove = canMove;
        }


    }
}