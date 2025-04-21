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
        public float HP { get; set; }
        public float MP { get; set; }
        public float Damage { get; set; }
        public float Defence { get; set; }
        public int Gold { get; set; }
        public float CritRate { get; set; }
        public float CritDmg { get; set; }
        public float DodgeRate { get; set; }

        //    장비 - 무기
        //    장비 - 방어구
        //    장비 - 장신구


        //    플레이어 생성자 - 후에 장비 추가가 된다면 적용 시키기
        public Unit(string name, int level, float exp, float hp, float mp, float damage, float defence, 
            int gold, float critRate, float critDmg, float dodgeRate) 
        {
            Name = name;
            Level = level;
            EXP = exp;
            HP = hp;
            MP = mp;
            Damage = damage;
            Defence = defence;
            Gold = gold;
            CritRate = critRate;
            CritDmg = critDmg;
            DodgeRate = dodgeRate;
        }

        //    적 생성자
        public Unit(string name, float hp, float mp, float damage, float defence,
            int gold, float critRate, float critDmg, float dodgeRate)
        {
            Name = name;
            HP = hp;
            MP = mp;
            Damage = damage;
            Defence = defence;
            Gold = gold;
            CritRate = critRate;
            CritDmg = critDmg;
            DodgeRate = dodgeRate;
        }

        //    플레이어 생성자 예시. 만약 처음 이름이나 다른 선택지가 있다면 다른곳에서 관리
        public Player playerUnit = new Player("플레이어", 1, 0f, 100f, 50f, 20f, 5f, 100, 0.1f, 1.5f, 0.05f);
        

        //    몬스터 예시
        //    몬스터가 생길 때 마다 추가로 만든 후 객채로 생성하여 사용
        //    주의!
        //    이 데이터를 가져다 그대로 사용하게 될 경우 전체 데이터가 뒤틀려
        //    체력 0짜리 몬스터가 계속 나타날 수 있음!
        public Monster monsterUnit = new Monster("슬라임", 50f, 0f, 10f, 2f, 0, 0.05f, 1.2f, 0.1f);
    }
}
