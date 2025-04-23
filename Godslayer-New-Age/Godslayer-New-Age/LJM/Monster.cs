using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    internal class Monster : Unit
    {
        //    아이템 - 만약 드롭 아이템을 만든다 하면 추가
        
        public Skill MonsterSkill { get; set; }

        public List<Skill> MonsterSkills { get; set; }

        public Monster(string name, float hp, float damage, float defence,
       int gold, float critRate, float critDmg, float speed, float dodgeRate, bool canMove, List<Skill> monsterSkills)
       : base(name, hp, damage, defence, gold, critRate, critDmg, speed, dodgeRate, canMove)
        {
            //    아이템
            MonsterSkills = monsterSkills;
        }


        //    몬스터 예시
        //    몬스터가 생길 때 마다 추가로 만든 후 객채로 생성하여 사용

        //    주의!
        //    이 데이터를 가져다 그대로 사용하게 될 경우 전체 데이터가 뒤틀려
        //    체력 0짜리 몬스터가 계속 나타날 수 있음

        //    메이플
        public Monster slime = new Monster("슬라임", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });
        public Monster orangeMushroom = new Monster("주황버섯", 65f, 15f, 5f, 20, 10f, 1.5f, 1f, 5f, true, 
            new List<Skill> { Skill.jumpAtk });
        public Monster kangWunky = new Monster("강웡키", 200f, 20f, 20f, 500, 10f, 1.5f, 0f, 0f, true, 
            new List<Skill> { Skill.jumpAtk });
        public Monster godChangseop = new Monster("신창섭", 500f, 40f, 30f, 1000, 20f, 1.7f, 3f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });

        //    코인판
        public Monster stockInvestor = new Monster("코인충", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });
        public Monster yiLongMa = new Monster("이롱마", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });
        public Monster doge = new Monster("도지", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });
        public Monster elonMusk = new Monster("일론 머스크", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });

        //    프로게이머
        public Monster t1Fan = new Monster("T1 팬", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });
        public Monster minion = new Monster("슬라임", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });
        public Monster kkOma = new Monster("꼬마감독", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });
        public Monster GOD = new Monster("신", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });

    }
}