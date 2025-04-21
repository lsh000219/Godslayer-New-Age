using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    internal class Monster : Unit
    {
        public Monster(string name, float hp, float mp, float damage, float defence,
       int gold, float critRate, float critDmg, float dodgeRate)
       : base(name, hp, mp, damage, defence, gold, critRate, critDmg, dodgeRate)
        {
           
        }

        //    몬스터 예시
        //    몬스터가 생길 때 마다 추가로 만든 후 객채로 생성하여 사용
        //    주의!
        //    이 데이터를 가져다 그대로 사용하게 될 경우 전체 데이터가 뒤틀려
        //    체력 0짜리 몬스터가 계속 나타날 수 있음!
        public Monster monsterUnit = new Monster("슬라임", 50f, 0f, 10f, 2f, 0, 0.05f, 1.2f, 0.1f);
    }
}
