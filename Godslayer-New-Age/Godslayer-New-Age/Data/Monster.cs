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
        
        public static Monster slime = new Monster("슬라임", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.jumpAtk });
        public static Monster orangeMushroom = new Monster("주황버섯", 65f, 15f, 5f, 20, 10f, 1.5f, 1f, 5f, true, 
            new List<Skill> { Skill.Headbut });
        public static Monster kangWunky = new Monster("강웡키", 200f, 20f, 20f, 500, 10f, 1.5f, 0f, 0f, true, 
            new List<Skill> 
            { 
                Skill.LuckHack, 
                Skill.Mukbang 
            });
        public static Monster godChangseop = new Monster("신창섭", 500f, 40f, 30f, 1000, 20f, 1.7f, 3f, 10f, true, 
            new List<Skill> 
            { 
                Skill.Normalize, 
                Skill.ChangFu, 
                Skill.EradicateRiceMonkey0, 
                Skill.EradicateRiceMonkey1, 
                Skill.ChangPOP 
            });


        //    코인판
        public static Monster stockInvestor = new Monster("코인충", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> 
            { 
                Skill.AllIn0, 
                Skill.AllIn1 
            });
        public static Monster yiLongMa = new Monster("이롱마", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { Skill.LOVE });
        public static Monster doge = new Monster("도지", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill>
            { 
                Skill.VeryHeal0, 
                Skill.VeryHeal1, 
                Skill.MuchDamage0, 
                Skill.MuchDamage1, 
                Skill.Wow 
            });
        public static Monster elonMusk = new Monster("일론 머스크", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> { 
                Skill.SpaceXLaunchFail, 
                Skill.CybertruckCrash, 
                Skill.PumpIt, 
                Skill.DumpIt, 
                Skill.Tweeting 
            });


        //    프로게이머
        public static Monster t1Fan = new Monster("T1 팬", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> 
            {
                Skill.Worship0,
                Skill.Worship1,
                Skill.Worship2
            });
        public static Monster minion = new Monster("미니언", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> 
            { 
                Skill.WeaknessAtk 
            });
        public static Monster kkOma = new Monster("꼬마감독", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill>
            { 
                Skill.AngryFeedback,
                Skill.Warding
            });
        public static Monster GOD = new Monster("신", 50f, 10f, 2f, 10, 5f, 1.5f, 1f, 10f, true, 
            new List<Skill> 
            { 
                Skill.Gotya,
                Skill.IDodgeThat0,
                Skill.IDodgeThat1,
                Skill.God,
            });
        
    }
}