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
        Random random = new Random();

        private Monster _monster;       
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

        public void MonsterTurn(Monster monster)
        {
            int randskill = random.Next();
        }

        public void StartBattle(Monster monster1, Monster monster2)//일반몹(2명씩 나올 예정)
        {
            int turn = 1;
            

            while (Player.Instance.HP != 0 && ( _monster.slime.HP!= 0))
            {
                float player_rand_Spd = random.Next(0, 5) + Player.Instance.Speed;
                float enemy1_rand_Spd = random.Next(0, 5) + monster1.Speed;
                float enemy2_rand_Spd = random.Next(0, 5) + monster2.Speed;
                var turnList = new List<(float speed, object character)>
                {
                     (player_rand_Spd, Player.Instance),
                     (enemy1_rand_Spd, monster1),
                     (enemy2_rand_Spd, monster2)
                };

                turnList.Sort((a, b) => b.speed.CompareTo(a.speed));

                foreach (var entry in turnList)
                {
                    if (entry.character is Player)
                    {
                        PlayerTurn(); // 또는 ((Player)entry.character).어쩌고
                    }
                    else if (entry.character is Monster monster)
                    {
                        MonsterTurn(monster);
                    }
                }
                turn++;
            }
        }
        public void StartBattle(Monster boss)//보스전
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