using Godslayer_New_Age.Kiahn;
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

        private Inventory _inventory;
        public Battle(Inventory inventory)
        {
            _inventory = inventory;
        }

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

        public void StartBattle(Monster monster1, Monster monster2)//일반몹(2명씩 나올 예정)
        {
            int turn = 1;

            while (Player.Instance.HP != 0 && (monster1.HP != 0 || monster2.HP != 0))
            {
                float player_rand_Spd = random.Next(0, 5) + Player.Instance.Speed;
                float monster1_rand_Spd = random.Next(0, 5) + monster1.Speed;
                float monster2_rand_Spd = random.Next(0, 5) + monster2.Speed;
                var turnList = new List<(float speed, object character)>
                {
                     (player_rand_Spd, Player.Instance),
                     (monster1_rand_Spd, monster1),
                     (monster2_rand_Spd, monster2)
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
            if (Player.Instance.HP == 0)
            {
                Console.WriteLine("패배하였습니다");
                Console.WriteLine("신살을 실패하였습니다");
                Console.WriteLine("당신은 의식만 간신히 유지한채 도망쳐나왔습니다.");
                Console.WriteLine($"돈의 절반을 잃어버렸습니다(-{Player.Instance.Gold - Player.Instance.Gold / 2})gold");
                Player.Instance.Gold = Player.Instance.Gold / 2;
            }
            else
            {
                Console.WriteLine("승리하였습니다");
                
                Console.WriteLine($"+{monster1.Gold + monster2.Gold}");
            }
        }
        public void StartBattle(Monster boss)//보스전
        {
            int turn = 1;

            while (Player.Instance.HP != 0 && (boss.HP != 0))
            {
                float player_rand_Spd = random.Next(0, 5) + Player.Instance.Speed;
                float boss_rand_Spd = random.Next(0, 5) + boss.Speed;
                var turnList = new List<(float speed, object character)>
                {
                     (player_rand_Spd, Player.Instance),
                     (boss_rand_Spd, boss)
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

    }
}