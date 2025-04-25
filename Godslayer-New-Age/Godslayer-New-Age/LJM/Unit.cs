using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    [Serializable]
    public class Unit
    {

        public string Name { get; set; }
        public int Level { get; set; }
        public float EXP { get; set; }
        public float MaxHP { get; set; }
        public float HP { get; set; }
        public float MaxMP { get; set; }
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


        //    버프 리스트
        public List<Buff> Buffs { get; set; } = new List<Buff>();


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
        public Unit(string name, float hp, float damage, float defence,
            int gold, float critRate, float critDmg, float speed, float dodgeRate, bool canMove)
        {
            Name = name;
            HP = hp;
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

        //    최대 갭 대미지
        public int GetMaxDamage()
        {
            int max = (int)(Damage + DamageGap);
            return max;
        }
        //    최소 갭 + 평타 대미지
        public int GetLowDamage()
        {
            int min = Math.Max(0, (int)(Damage - DamageGap));
            int max = (int)Damage;
            return RandomManager.Instance.Next(min, max + 1);
        }

        //    공격 회피하기 
        //    만약 아래의 bool을 거쳐 true가 나온다면 공격 회피
        public bool TryDodge()
        {
            return RandomManager.Instance.Next(0, 100) < DodgeRate;
        }

        //    크리티컬 구하기
        //    만약 아래의 bool을 거쳐 true가 나온다면 크리티컬 공격
        public bool GetCrit()
        {
            return RandomManager.Instance.Next(0, 100) < CritRate;
        }





        //    버프 작동시키기
        public void ProcessBuffs()
        {
            for (int i = Buffs.Count - 1; i >= 0; i--)
            {
                var buff = Buffs[i];
                buff.Apply(this); //    자기 자신에게 적용

                //    만약 버프가 끝났다면
                if (buff.IsExpired)
                {
                    //    원상복구 등 정리할 작업
                    buff.Remove(this);  //    이건 Buff클래스 내부의 기능
                    Buffs.RemoveAt(i); //    이건 List의 기능
                }
            }
        }

    }
}