using Godslayer_New_Age.LJM;
using Godslayer_New_Age.Kiahn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.juna
{
    class Dungeon
    {
        List<Monster> monsters = new List<Monster>();

        Random random = new Random();

        private Monster _monster;
        private Battle _battle;
        public Dungeon(Monster monster, Battle battle)
        {
            _monster = monster;
            _battle = battle;
        }

        private int dungeontype;
        private bool[] dungeonclear = { false, false, false, false};
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
        public void SelectDungeon(int min, int max)
        {
            Console.WriteLine("가고싶은 장소를 선택해 주세요");
            Console.Write("1. 단풍향이 피어나는 곳");
            if (dungeonclear[0] == true)
            {
                Console.Write("(Clear)");
            }
            else
            {
                Console.Write("       ");
            }
            Console.Write("2. 강아지와 우주선이 오르락내리락하는 곳");
            if (dungeonclear[1] == true)
            {
                Console.Write("(Clear)");
            }
            else
            {
                Console.Write("       ");
            }
            Console.Write("3. 협곡");
            if (dungeonclear[2] == true)
            {
                Console.Write("(Clear)");
            }
            else
            {
                Console.Write("       ");
            }
            if (dungeonclear[0] == true && dungeonclear[1] == true && dungeonclear[2] == true)
            {
                Console.Write("4. 이탈리아어가 들리는 곳");
                if (dungeonclear[3] == true)
                {
                    Console.Write("(Clear)");
                }
                else
                {
                    Console.Write("       ");
                }
            }
            Console.WriteLine("0. 나가기");

            dungeontype = CheckInput(0, 4);
            switch (dungeontype)
            {
                case 1:
                    Console.WriteLine("본섭의 눈물을 듣고 신이 되기로 결정한 신창섭");
                    Console.WriteLine("리슝좍 10만명을 척결하고 신이 된 그는 이번에는 쌀숭이들 정상화시키려고 한다");
                    Console.WriteLine("당신과 얼마 안남은 동료들의 생계를 위해 그를 죽여야만 한다... ");
                    AddMonster(1);
                    Dungeon_Select(1);
                    break;
                case 2:
                    Console.WriteLine("화성과 코인에 의한 여러 밈으로 인해 신이된 자 일론 머스크");
                    Console.WriteLine("여러분의 주식을 사주는 개미들이 코인을 하러 떠나는 것을 막기 위해 그를 죽여야만 한다");
                    AddMonster(2);
                    Dungeon_Select(2);
                    break;
                case 3:
                    Console.WriteLine("리그오브 레전드 게임에서 전무후무한 대기록을 세우며 '롤의 신'이라고 칭송받는 자 페이커");
                    Console.WriteLine("롤의 신을 넘어 E-sports의 신이 되어 당신의 커리어를 위협한다");
                    Console.WriteLine("우승이 없는 커리어를 만들지 않으려면 그를 죽여야한다");
                    AddMonster(3);
                    Dungeon_Select(3);
                    break;
                case 4:
                    Console.WriteLine("잘못된 입력입니다");
                    break;
                case 0:
                    break;
            }
        }
        public void Dungeon_Select(int num)
        {
            int room = 1;
            while (true)
            {
                Console.WriteLine("원하시는 행동을 선택해 주세요");
                Console.WriteLine("1. 앞으로 나아간다   0. 마을로 돌아간다");
                int playerselect = CheckInput(0, 1);
                switch (playerselect)
                {
                    case 1:
                        ShowMonster(room);
                        if (dungeonclear[num] == true && (room == 4 || room == 9))
                        {
                            room++;
                        }
                        room++;
                        break;
                    case 0:
                        break;
                }
                if (playerselect == 0 || Player.Instance.HP == 0)
                {
                    if (Player.Instance.HP == 0)
                    {
                        Player.Instance.HP = 1.0f;
                    }
                    monsters.Clear();
                    break;
                }
                if (room==11)
                {
                    dungeonclear[num-1] = true;
                    monsters.Clear();
                    break;
                }
            }
        }
        public void ShowMonster(int room)
        {
            switch (room)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 6:
                case 7:
                case 8:
                case 9:
                    int randnum1 = random.Next(0, 2);
                    int randnum2 = random.Next(0, 2);
                    _battle.StartBattle(monsters[randnum1], monsters[randnum2]);
                    break;
                case 5:
                    _battle.StartBattle(monsters[2]);
                    break;
                case 10:
                    _battle.StartBattle(monsters[3]);
                    break;
                default:
                    break;
            }

        }
        public void AddMonster(int num)
        {
            switch (num)
            {
                case 1:
                    monsters.Add(_monster.slime);
                    monsters.Add(_monster.orangeMushroom);
                    monsters.Add(_monster.kangWunky);
                    monsters.Add(_monster.godChangseop);
                    break;
                case 2:
                    monsters.Add(_monster.stockInvestor);
                    monsters.Add(_monster.yiLongMa);
                    monsters.Add(_monster.doge);
                    monsters.Add(_monster.elonMusk);
                    break;
                case 3:
                    monsters.Add(_monster.t1Fan);
                    monsters.Add(_monster.minion);
                    monsters.Add(_monster.kkOma);
                    monsters.Add(_monster.GOD);
                    break;
            }
        }
    }
}