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
        public float MaxHP { get;set; }
        public float HP { get; set; }
        public float MaxMP { get;set; }
        public float MP { get; set; }
        public float Damage { get; set; }
        public int DamageGap { get; set; } = 3;
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

        //    대미지 갭에 따른 대미지 계산하기
        public int GetRandomDamage()
        {
            //    min은 공격력이 0 이하로 내려가지 않게 해준다
            int min = Math.Max(0, (int)(Damage - DamageGap));
            int max = (int)(Damage + DamageGap);
            return RandomManager.Instance.Next(min, max + 1);
        }

        //    공격 회피하기 
        public bool TryDodge()
        {
            return RandomManager.Instance.Next(0, 100) < DodgeRate;
        }
        
    }
}
