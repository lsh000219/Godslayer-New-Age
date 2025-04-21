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
            float defence, int gold, float critRate, float critDmg, float speed, float dodgeRate)
        : base(name, level, exp, hp, mp, damage, defence, gold, critRate, critDmg, speed, dodgeRate)
        { 
           
        }

        //    플레이어 생성자 예시. 만약 처음 이름이나 다른 선택지가 있다면 다른곳에서 관리
        public Player playerUnit = new Player(
            "플레이어", 
            1, 
            0f, 
            100f, 
            50f, 
            20f, 
            5f, 
            100, 
            0.1f, 
            1.5f, 
            1f, 
            0.05f
            );
    }
}
