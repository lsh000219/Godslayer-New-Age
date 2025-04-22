using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.LJM
{
    //    플레이어 생성자 - 후에 장비 추가가 된다면 적용 시키기
    internal class Player : Unit
    {

        //    장비 - 무기
        //    장비 - 방어구
        //    장비 - 장신구

        public List<Skill> PlayerSkills = new List<Skill>();

        public float RequiredExp => (float)(50 * Math.Pow(1.15, Level - 1));

        public Player(string name, int level, float exp, float maxHP, float hp, float maxMP, float mp, float damage,
            float defence, int gold, float critRate, float critDmg, float speed, float dodgeRate, bool canMove)
        : base(name, level, exp, maxHP, hp, maxMP, mp, damage, defence, gold, critRate, critDmg, speed, dodgeRate, canMove)
        {
            //    장비 - 무기
            //    장비 - 방어구
            //    장비 - 장신구

        }

        //    플레이어 생성자 예시. 만약 처음 이름이나 다른 선택지가 있다면 다른곳에서 관리
        //    현재는 장비가 장착이 안되어 있음
        public Player playerUnit = new Player(
            "플레이어",
            1,
            0f,
            100f,
            100f,
            50f,
            50f,
            20f,
            5f,
            100,
            0.1f,
            1.5f,
            1f,
            0.05f,
            true
            //    장비 - 무기
            //    장비 - 방어구
            //    장비 - 장신구
            //    위에는 초기에는 빈칸이거나 기초 장비를 끼고 있어야 함
            );

        //    플레이어 레벨 업
        public void LevelUp()
        {
            Level++;

            HP += 10f;
            MP += 5f;
            Damage += 0.5f;
            Defence += 1f;
            Console.WriteLine($"{Name}이 레벨업! HP, MP, Damage 증가!");
        }


    }
}