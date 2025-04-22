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
        public enum Job  
        {
            RiceMonkey = 0,
            CEO,
            ProGamer
        }


        //    장비 - 무기
        //    장비 - 방어구
        //    장비 - 장신구

        public List<Skill> PlayerSkills = new List<Skill>();

        public Job PlayerJob { get; set; }
        //    레벨업에 필요한 경험치로 레벨에 비례해 커짐
        public float RequiredExp => (float)(50 * Math.Pow(1.15, Level - 1));
        //    50 * (1.15 ^ 레벨 - 1)
         
        public Player(Job playerJob, string name, int level, float exp, float maxHP, float hp, float maxMP, float mp, float damage,
            float defence, int gold, float critRate, float critDmg, float speed, float dodgeRate, bool canMove)
        : base(name, level, exp, maxHP, hp, maxMP, mp, damage, defence, gold, critRate, critDmg, speed, dodgeRate, canMove)
        {
            PlayerJob = playerJob;

            //    장비 - 무기
            //    장비 - 방어구
            //    장비 - 장신구
        }

        //    플레이어 생성자 예시. 만약 처음 이름이나 다른 선택지가 있다면 다른곳에서 관리
        //    현재는 장비가 장착이 안되어 있음
        public static Player playerUnit = new Player(
            0,
            "플레이어",  //    이름
            1, //    레벨
            0f, //    경험치
            100f, //    최대 체력
            100f, //    현재 체력
            50f, //    최대 마나
            50f, //    현재 마나
            20f, //    공격력
            5f, //    방어력
            100, //    소지금
            0.1f, //    치명타 확률
            1.5f, //    치명타 대미지
            1f, //    속도
            50f, //    회피율
            true //    행동이 가능한지 파악하는 bool
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

        //    int값 만큼의 레벨이 되기 위해 필요한 누적 총 경험치
        float GetTotalExpForLevel(int level)
        {
            float total = 0;
            for(int i = 0; i < Level; i++)
            {
                //    토탈 경험치 = 최대 경험치 증가식
                total += 50f * (float)Math.Pow(1.15f, i - 1);
            }
            return total;
        }

        //    경험치를 얻었을 때 레벨업이 가능한지 확인하기
        void CheckLevelUp()
        {
            while(EXP >= GetTotalExpForLevel(Level + 1))
            {
                LevelUp();
            }
        }

        //    경험치를 얻는 함수로
        //    적을 죽일 시 적의 exp를 넣어서 경험치를 얻게 함
        public void GainEXP(float exp)
        {
            EXP += exp;
            CheckLevelUp();
        }

    }
}
