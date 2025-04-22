using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.juna
{
    class Battle
    {
        string playerName = "Bob";
        float playerMaxHp = 100;
        float playerMaxMp = 100;
        float playerHp = 100;
        float playerMp = 100;
        float playerAtk = 10;
        float playerDef = 10;
        int playerLv = 2;
        float playerSpd = 10;
        float playerCrt = 3.0f;
        float playerEva = 3.0f;
        int playerGold = 1000;
        

        string enemy1Name = "slime";
        float enemy1MaxHp = 100;
        float enemy1MaxMp = 100;
        float enemy1Hp = 100;
        float enemy1Mp = 100;
        float enemy1Atk = 10;
        float enemy1Def = 10;
        int enemy1Lv = 2;
        int enemy1Spd = 10;
        float enemy1Crt = 3.0f;
        float enemy1Eva = 3.0f;
        int enemy1Gold = 100;

        string enemy2Name = "주황버섯";
        float enemy2MaxHp = 100;
        float enemy2MaxMp = 100;
        float enemy2Hp = 100;
        float enemy2Mp = 100;
        float enemy2Atk = 10;
        float enemy2Def = 10;
        int enemy2Lv = 2;
        int enemy2Spd = 10;
        float enemy2Crt = 3.0f;
        float enemy2Eva = 3.0f;
        int enemy2Gold = 100;
        //위에 변수들은 나중에 Player클래스에서 받아오기

        //a *(100/100+d)데미지 주는 방식
        //Math.Round(value,1)

        public int CheckInput(int min,int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                   if(input>= min&& input <= max)
                   {
                        return input;
                   }
                }
                Console.WriteLine("잘못된 입력입니다");
            }
        }

        public void PlayerTurn()
        {
            Console.WriteLine("원하시는 행동을 선택해주세요");
            Console.WriteLine("1. 공격   2. ");
            int playerselect = CheckInput(1, 2);
            switch (playerselect)
            {
                case 1:
                    PlayerAtk();
                    break;
                case 2:

                    break;
            }
        }
        public void PlayerAtk()
        {
            Console.WriteLine("원하시는 공격을 선택해주세요");
            Console.WriteLine($"1.   2.   3.   4.   ");//스킬이나 평타 이름을 저장한 것을 넣기
            int playerselect = CheckInput(0, 4);
            switch (playerselect)
            {
                case 1:
                    //해당 스킬에 해당하는 함수 호출
                    break;
                case 2:
                    //해당 스킬에 해당하는 함수 호출
                    break;
                case 3:
                    //해당 스킬에 해당하는 함수 호출
                    break;
                case 4:
                    //해당 스킬에 해당하는 함수 호출
                    break;
                case 0:
                    PlayerAtk();
                    break;
            }
        }

        public void EnemyTurn(string enemyname)
        {
            Random random = new Random();
            if(enemyname == "신창섭")
            {

            }
            int randskill = random.Next();
        }


        public void StartBattle_1(string enemy1name, string enemy2name)//일반몹(2명씩 나올 예정)
        {
            while(playerHp != 0 && (enemy1Hp != 0))
            {
                int turn = 1; 
                Random random = new Random();
                float player_rand_Spd = random.Next(0, 4)+playerSpd;
                float enemy1_rand_Spd = random.Next(0, 4);
                float enemy2_rand_Spd = random.Next(0, 4);
                if (player_rand_Spd >= enemy1_rand_Spd && player_rand_Spd >= enemy2_rand_Spd)
                {
                    PlayerTurn();
                    if(enemy1_rand_Spd >= enemy2_rand_Spd)
                    {
                        EnemyTurn(enemy1name);
                        EnemyTurn(enemy2name);
                    }
                    else
                    {
                        EnemyTurn(enemy2name);
                        EnemyTurn(enemy1name);
                    }
                }
                else if (enemy1_rand_Spd >= player_rand_Spd && enemy1_rand_Spd >= enemy2_rand_Spd)
                {
                    EnemyTurn(enemy1name);
                    if (player_rand_Spd >= enemy2_rand_Spd)
                    {
                        PlayerTurn();
                        EnemyTurn(enemy2name);
                    }
                    else
                    {
                        EnemyTurn(enemy2name);
                        PlayerTurn();
                    }
                }
                else
                {
                    EnemyTurn(enemy2name);
                    if (player_rand_Spd >= enemy1_rand_Spd)
                    {
                        PlayerTurn();
                        EnemyTurn(enemy1name);
                    }
                    else
                    {
                        EnemyTurn(enemy1name);
                        PlayerTurn();
                    }
                }
                turn++;
            }
        }
        public void StartBattle_2(string bossname)//보스전
        {
            while (playerHp != 0 && enemy1Hp != 0)
            {
                Random random = new Random();
                int player_rand_num = random.Next(0, 4);
                int enemy_rand_num = random.Next(0, 4);
                if (playerSpd + player_rand_num >= enemy1Spd + enemy_rand_num)
                {
                    PlayerTurn();
                    EnemyTurn(bossname);//안에 적의 수 넣기
                }
                else
                {
                    EnemyTurn(bossname);
                    PlayerTurn();
                }
            }
        }
    }
}
