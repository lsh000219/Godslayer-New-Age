using Godslayer_New_Age.LJM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.juna
{
    class Battle
    {
        private Player _player;
        private Monster _monster;

        public Battle(Player player)
        {
            _player = player;
        }
        public Battle(Monster monster)
        {
            _monster = monster;
        }


        //위에 변수들은 나중에 Player클래스에서 받아오기

        //a *(100/100+d)데미지 주는 방식
        //Math.Round(value,1)

        public int CheckInput(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input >= min && input <= max)
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

        public void EnemyTurn(string enemyname, int turn)
        {
            Random random = new Random();
            if (enemyname == "신창섭" && turn == 1)
            {
                //정상화 실행
            }
            int randskill = random.Next();
        }


        public void StartBattle_1(string enemy1name, string enemy2name)//일반몹(2명씩 나올 예정)
        {
            int turn = 1;
            while (_player.HP != 0 && ( _monster.monsterUnit.HP!= 0))
            {
                Random random = new Random();
                float player_rand_Spd = random.Next(0, 4) + _player.HP;
                float enemy1_rand_Spd = random.Next(0, 4) + _monster.HP;
                float enemy2_rand_Spd = random.Next(0, 4) + _monster.HP;
                if (player_rand_Spd >= enemy1_rand_Spd && player_rand_Spd >= enemy2_rand_Spd)
                {
                    PlayerTurn();
                    if (enemy1_rand_Spd >= enemy2_rand_Spd)
                    {
                        EnemyTurn(enemy1name, turn);
                        EnemyTurn(enemy2name, turn);
                    }
                    else
                    {
                        EnemyTurn(enemy2name, turn);
                        EnemyTurn(enemy1name, turn);
                    }
                }
                else if (enemy1_rand_Spd >= player_rand_Spd && enemy1_rand_Spd >= enemy2_rand_Spd)
                {
                    EnemyTurn(enemy1name, turn);
                    if (player_rand_Spd >= enemy2_rand_Spd)
                    {
                        PlayerTurn();
                        EnemyTurn(enemy2name, turn);
                    }
                    else
                    {
                        EnemyTurn(enemy2name, turn);
                        PlayerTurn();
                    }
                }
                else
                {
                    EnemyTurn(enemy2name, turn);
                    if (player_rand_Spd >= enemy1_rand_Spd)
                    {
                        PlayerTurn();
                        EnemyTurn(enemy1name, turn);
                    }
                    else
                    {
                        EnemyTurn(enemy1name, turn);
                        PlayerTurn();
                    }
                }
                turn++;
            }
        }
        public void StartBattle_2(string bossname)//보스전
        {
            int turn = 1;
            while (_player.HP != 0 && _monster.monsterUnit.HP != 0)
            {
                Random random = new Random();
                int player_rand_num = random.Next(0, 4);
                int enemy_rand_num = random.Next(0, 4);
                if (_monster.monsterUnit.HP + player_rand_num >= _monster.monsterUnit.HP + enemy_rand_num)
                {
                    PlayerTurn();
                    EnemyTurn(bossname, turn);//안에 적의 수 넣기
                }
                else
                {
                    EnemyTurn(bossname, turn);
                    PlayerTurn();
                }
                turn++;
            }
        }
    }
}