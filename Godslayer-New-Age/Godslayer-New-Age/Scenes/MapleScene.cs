using Core;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;
using Godslayer_New_Age.LJM;
using Godslayer_New_Age.Kiahn;

namespace Godslayer_New_Age.Wooseong.Scenes
{
    class MapleScene : IScene
    {
        Random random = new Random();
        public GameState SceneType => GameState.Maple;

        private int room;
        private int turn;
        private int randnum1;
        private int randnum2;
        private int life_point = 5;

        private bool[] isClear = { false, false };

        private Monster _monster;
        public MapleScene(Monster monster)
        {
            _monster = monster;
        }

        List<Monster> monsters = new List<Monster>();
        public void AddMonster()//다른 곳에서바꾸기
        {
            room = 1;
            //monsters.Add(_monster.slime);
            //monsters.Add(_monster.orangeMushroom);
            //monsters.Add(_monster.kangWunky);
            //monsters.Add(_monster.godChangseop);
        }
        public void StartBattle(Monster monster1, Monster monster2, string skill, string target)//일반몹(2명씩 나올 예정)
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

            turnList.Sort((a, b) => b.speed.CompareTo(a.speed));//순서 정렬

            foreach (var entry in turnList)//순서에 따라 하나씩 실행
            {
                if (entry.character is Player)
                {
                    //PlayerTurn(input2,input3);
                }
                else if (entry.character is Monster monster)
                {
                    //MonsterTurn(monster);
                }
            }
            if (monster1.HP == 0)
            {
                Player.Instance.EXP += monster1.EXP;
                box1Text[2].Add($"{monster1.Name}을(를) 쓰러뜨렸습니다.");
                box1Text[2].Add($"{monster1.EXP} 경험치를 획득하였습니다.");
            }
            if (monster2.HP == 0)
            {
                Player.Instance.EXP += monster2.EXP;
                box1Text[2].Add($"{monster2.Name}을(를) 쓰러뜨렸습니다.");
                box1Text[2].Add($"{monster2.EXP} 경험치를 획득하였습니다.");
            }
            turn++;
        }

        public void StartBattle(Monster boss, string skill)//보스전
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
                    //PlayerTurn(); // 또는 ((Player)entry.character).어쩌고
                }
                else if (entry.character is Monster monster)
                {
                    //MonsterTurn(monster);
                }
            }
            if (boss.HP == 0)
            {
                Player.Instance.EXP += boss.EXP;
                box1Text[3].Add($"{boss.Name}을(를) 쓰러뜨렸습니다.");
                box1Text[3].Add($"{boss.EXP} 경험치를 획득하였습니다.");
            }
            turn++;
        }
        public bool HasPlusGold()
        {
            string[] namesToCheck = { "솜크빈", "자석펫", "테슬라 기어봉", "화성인 가면", "그랜드 마스터 딱지", "챌린저 딱지" };

            return Inventory.equippedList.Any(item => namesToCheck.Contains(item.Name));
        }
        public void CheckLife()
        {
            if (life_point > 0)
            {
                box1Text[2].Add($"기회가 {life_point}번 남았습니다...");
            }
            else if (life_point == 0)
            {
                box1Text[2].Add("You Die...");
                //강종 및 데이터 삭제 함수
            }
        }
        public void BossDrop()
        {
            if (Player.Instance.PlayerJob == Player.Job.RiceMonkey)
            {
                ItemData absolcalibur = new ItemData("앱솔칼리버", eItemType.Weapon, 100, 0, "신창섭의 가호를 받은 기간제 무기", "", 8500);
                Inventory.inventoryList.Add(absolcalibur);
                ItemData challengerArmor = new ItemData("도전자의_갑옷", eItemType.Armor, 0, 80, "신창섭의 가호를 받은 기간제 갑옷", "", 9000);
                Inventory.inventoryList.Add(challengerArmor);
                box1Text[5].Add($"{Player.Instance.Name}은(는) {monsters[3].Name}을(를) 꺾고 {absolcalibur.Name}와 {challengerArmor.Name}을 획득하였다!!");
            }
        }

        public GameState Run(int phase)
        {
            PrintDB.box1Data = box1Text.ContainsKey(phase) ? box1Text[phase] : new List<string>();
            PrintDB.box3Data = box3Text.ContainsKey(phase) ? box3Text[phase] : new List<string>();

            PrintUtil.CreateBox();
            AddMonster();
            switch (phase)
            {
                case 0:
                    SceneManager.SetPhase(1);
                    return GameState.Retry;
                case 1:
                    string input = Console.ReadLine();
                    if (input == "0")
                    {
                        monsters.Clear();
                        return GameState.Pop;
                    }
                    switch (input)
                    {
                        case "1":
                            turn = 1;
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
                                    BGM_Player.Instance().Play_Maple_Easy_Loop();
                                    randnum1 = random.Next(0, 2);
                                    randnum2 = random.Next(0, 2);
                                    SceneManager.SetPhase(2);
                                    return GameState.Retry;
                                case 5:
                                    BGM_Player.Instance().Play_Maple_Gang_Loop();
                                    SceneManager.SetPhase(3);
                                    return GameState.Retry;
                                case 10:
                                    BGM_Player.Instance().Play_Maple_SinChangSup_Loop();
                                    SceneManager.SetPhase(4);
                                    return GameState.Retry;
                                default:
                                    return GameState.Main;
                            }
                        default:
                            return GameState.Retry;
                    }
                case 2:
                    while (Player.Instance.HP != 0 && (monsters[randnum1].HP != 0 || monsters[randnum2].HP != 0))
                    {
                        string input2 = Console.ReadLine();
                        box3Text[2].Clear();
                        box3Text[2].Add("공격 대상을 선택해주세요");
                        box3Text[2].Add($"1. {monsters[randnum1].Name}   2.{monsters[randnum2].Name}");
                        string input3 = Console.ReadLine();
                        if (box1Text[2].Count > 19)
                        {
                            box1Text[2].RemoveRange(2, box1Text.Count - 2);
                        }
                        StartBattle(monsters[randnum1], monsters[randnum2], input2, input3);
                    }

                    if (Player.Instance.HP == 0)
                    {
                        BGM_Player.Instance().Play_Lose();
                        box1Text[2].RemoveRange(2, box1Text.Count - 2);
                        box1Text[2].Add("신살을 실패하였습니다");
                        life_point--;
                        CheckLife();
                        box1Text[2].Add("당신은 의식을 잃고 무엇인가의 힘에 의해 집으로 복귀했습니다.");
                        box1Text[2].Add($"돈의 절반을 잃어버렸습니다(-{Player.Instance.Gold - Player.Instance.Gold / 2})gold");
                        Player.Instance.Gold = Player.Instance.Gold / 2;
                        return GameState.Main;
                    }
                    else
                    {
                        BGM_Player.Instance().Play_Victory();
                        box1Text[2].RemoveRange(2, box1Text.Count - 2);
                        box1Text[2].Add("승리하였습니다");
                        if (HasPlusGold())
                        {
                            box1Text[2].Add($"+{(monsters[randnum1].Gold + monsters[randnum2].Gold) * 2}gold");
                            Player.Instance.Gold += (monsters[randnum1].Gold + monsters[randnum2].Gold) * 2;
                        }
                        else
                        {
                            box1Text[2].Add($"+{monsters[randnum1].Gold + monsters[randnum2].Gold}gold");
                            Player.Instance.Gold += monsters[randnum1].Gold + monsters[randnum2].Gold;
                        }
                        room++;
                        SceneManager.SetPhase(1);
                        return GameState.Retry;
                    }
                case 3:
                    if (isClear[0]==true)
                    {
                        box1Text[3].Clear();
                        box1Text[3].Add($"Stage {room}");
                        box1Text[3].Add("");
                        box1Text[3].Add("텅 빈 던전을 지나간다");
                        Thread.Sleep(1000);
                        room++;
                        SceneManager.SetPhase(1);
                        return GameState.Retry;
                    }
                    while (Player.Instance.HP != 0 && monsters[2].HP != 0)
                    {
                        string input2 = Console.ReadLine();
                        box1Text[3].RemoveRange(19, box1Text.Count - 19);
                        StartBattle(monsters[2],input2);
                    }

                    if (Player.Instance.HP == 0)
                    {
                        BGM_Player.Instance().Play_Lose();
                        box1Text[3].RemoveRange(19, box1Text.Count - 19);
                        box1Text[3].Add("신살을 실패하였습니다");
                        life_point--;
                        CheckLife();
                        box1Text[3].Add("당신은 의식을 잃고 무엇인가의 힘에 의해 집으로 복귀했습니다.");
                        box1Text[3].Add($"돈의 절반을 잃어버렸습니다(-{Player.Instance.Gold - Player.Instance.Gold / 2})gold");
                        Player.Instance.Gold = Player.Instance.Gold / 2;
                        return GameState.Main;
                    }
                    else
                    {
                        BGM_Player.Instance().Play_Victory();
                        box1Text[3].Clear();
                        box1Text[3].Add($"Stage {room}");
                        box1Text[3].Add("");
                        box1Text[3].Add("승리하였습니다");
                        isClear[0] = true;
                        if (HasPlusGold())
                        {
                            box1Text[3].Add($"+{(monsters[2].Gold) * 2}gold");
                            Player.Instance.Gold += (monsters[2].Gold) * 2;
                        }
                        else
                        {
                            box1Text[3].Add($"+{(monsters[2].Gold) * 2}gold");
                            Player.Instance.Gold += (monsters[2].Gold) * 2;
                        }
                        room++;
                        SceneManager.SetPhase(1);
                        return GameState.Retry;
                    }
                case 4:
                    if (isClear[1] == true)
                    {
                        box1Text[4].Clear();
                        box1Text[4].Add($"Stage {room}");
                        box1Text[4].Add("");
                        box1Text[4].Add("텅 빈 던전을 나와 마을로 돌아간다");
                        Thread.Sleep(1000);
                        return GameState.Main;
                    }
                    while (Player.Instance.HP != 0 && monsters[3].HP != 0)
                    {
                        string input2 = Console.ReadLine();
                        box1Text[4].RemoveRange(19, box1Text.Count - 19);
                        StartBattle(monsters[3],input2);
                    }

                    if (Player.Instance.HP == 0)
                    {
                        BGM_Player.Instance().Play_Lose();
                        box1Text[4].RemoveRange(19, box1Text.Count - 19);
                        box1Text[4].Add("신살을 실패하였습니다");
                        life_point--;
                        CheckLife();
                        box1Text[4].Add("당신은 의식을 잃고 무엇인가의 힘에 의해 집으로 복귀했습니다.");
                        box1Text[4].Add($"돈의 절반을 잃어버렸습니다(-{Player.Instance.Gold - Player.Instance.Gold / 2})gold");
                        Player.Instance.Gold = Player.Instance.Gold / 2;
                        return GameState.Main;
                    }
                    else
                    {
                        BGM_Player.Instance().Play_Victory();
                        box1Text[4].Clear();
                        box1Text[4].Add($"Stage {room}");
                        box1Text[4].Add("");
                        box1Text[4].Add("승리하였습니다");
                        isClear[1] = true;
                        if (HasPlusGold())
                        {
                            box1Text[4].Add($"+{(monsters[3].Gold) * 2}gold");
                            Player.Instance.Gold += (monsters[2].Gold) * 2;
                        }
                        else
                        {
                            box1Text[4].Add($"+{(monsters[3].Gold) * 2}gold");
                            Player.Instance.Gold += (monsters[2].Gold) * 2;
                        }   
                        SceneManager.SetPhase(5);
                        return GameState.Retry;
                    }
                case 5:
                    BossDrop();
                    if (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                        return GameState.Main;
                    }
                    return GameState.Main;
                default:
                    return GameState.Main;
            }
        }

        public Dictionary<int, List<string>> box1Text = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> box3Text = new Dictionary<int, List<string>>();

        public MapleScene()
        {
            //0
            box1Text[0] = new List<string>()
            {
                "본섭의 눈물을 듣고 신이 되기로 결정한 신창섭",
                "리슝좍 10만명을 척결하고 신이 된 그는 이번에는 쌀숭이들 정상화시키려고 한다",
                "당신과 얼마 안남은 동료들의 생계를 위해 그를 죽여야만 한다... "
            };

            box3Text[0] = new List<string>()
            {
                " "
            };
            //1
            box1Text[1] = new List<string>()
            {
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡶⢶⡲⣖⡲⢒⣶⣒⡖⣒⣒⢲⣒⠲⣰⣖⡒⣖⢲⡒⡒⣶⢦⠳⣞⢹⣏⢞⡹⣜⡹⣏⢎⡳⣙⢮⡹⣹⢣⡼⡹⢎⣽⠏⡱⢲⠶⣒⡖⡒⢦⡱⣒⢖⡲⣷⡖⢢⢣⠖⣜⣶⡶⢒⣖⡲⢶⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣯⣗⣻⢶⣹⣌⣿⣳⣞⣥⣛⡶⣩⣳⣹⢶⣹⣬⣧⢝⢻⡶⣩⢳⢎⢧⢻⣌⡳⣌⣳⣿⣬⣳⣭⣲⣵⣻⣔⣣⣛⡵⡾⣨⣕⢫⡝⣣⡿⢫⢶⡹⣜⢮⣵⣻⣏⠼⣣⡟⣼⢾⡽⣘⢮⣝⣯⡷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣒⣖⣲⣒⣖⣪⠛⣿⢛⣛⣋⡟⡙⣷⢛⣣⢛⡿⣙⢳⣋⢏⡷⢻⣦⣋⠶⡹⣧⣋⣞⣮⡿⣟⣿⣿⣿⣷⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣷⣵⣎⡳⣞⡟⣥⢛⠶⡿⢏⣛⡞⣱⢋⡟⣷⡛⣋⣛⣛⢏⣛⡿⣷⢓⣲⣒⢶⣲⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⢺⣿⣜⣧⣏⠾⣭⣓⣮⣟⣬⣳⣞⣵⣾⣙⢦⣯⣿⣵⣳⡞⡭⢞⡥⡚⣽⣺⣵⣿⣻⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣯⣜⡮⣽⢛⡴⢫⡞⢮⣵⣯⢾⣽⣗⣽⣜⣮⣽⡾⣽⣿⣰⣧⣻⣮⣷⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⢀⣤⡤⡤⢤⢼⡛⢿⣛⣞⣻⢛⣛⢻⣭⢯⡭⣭⠭⣭⢙⣯⠭⡭⢭⢧⡙⢿⣭⢺⣙⣶⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣵⣫⢞⢧⡽⣛⠽⣌⢯⢥⡏⢾⣽⠩⡥⢯⡭⣭⢭⡽⣿⢩⡭⣭⢟⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⢸⣷⣻⢽⡻⢮⣝⣻⣞⡼⣣⡟⣼⢺⣏⢶⡹⣎⢷⡹⣆⣿⢣⣿⡹⢮⡝⡧⢞⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡝⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣋⢶⡭⢻⡜⣷⢎⣽⣻⢾⣅⣛⢧⡝⣮⢳⣞⣿⣸⢳⣭⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⢘⡿⢿⠷⡿⢿⠾⠿⠿⠿⣷⠿⠾⠿⠻⢯⠿⠽⣾⠿⠷⠿⣷⡙⠿⣷⡽⣞⣽⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣑⡟⡹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢦⣽⡷⢟⡋⣟⢳⡛⡟⣞⢻⡟⢻⠛⠿⡹⢗⡻⣟⢯⡿⢭⢤⡤⣤⡤⣤⣄⠀⠀⠀",
                "⠀⠀⠀⠀⢸⣟⣯⢻⡝⣯⢻⣝⡻⡜⣷⢯⣛⢯⣛⠷⣚⢧⢾⣏⢿⣹⢧⣛⢷⡲⣝⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⢜⠦⣍⣯⠳⣌⢻⣿⣿⣿⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢩⡖⣯⢞⡭⣷⠹⣎⡽⢎⣿⢢⣟⡹⡝⣏⠷⣎⣿⡧⣋⣾⡹⢧⡻⣽⣿⠀⠀⠀",
                "⠀⠀⠀⢀⣸⣿⣾⢯⣿⣾⣷⡾⣟⡷⣿⣟⣯⢷⣯⡿⣽⢾⡿⣾⢳⡿⣾⣝⣮⡳⣽⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡷⣝⠿⡟⣎⠹⢦⣧⡻⣌⢻⠿⡟⡵⣺⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⢻⣜⣮⣷⢿⣻⢾⣞⡿⣽⣳⣾⣳⣽⣮⣿⣼⣽⡷⣽⣶⣻⣭⣷⣿⣻⢀⣀⠀",
                "⠀⠀⢸⣟⡶⣳⢞⡶⡲⣼⢶⣱⢞⡶⣱⠶⣜⡖⣸⡗⣶⢲⡖⢶⣫⢵⢦⣭⣙⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣿⡜⡳⣝⠼⣩⣓⡏⢶⣩⠞⡼⣱⣻⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⡛⣭⡱⢆⣞⣧⢖⡮⢶⡱⡖⣾⡗⣦⢻⡔⢶⡲⡞⣶⢣⢿⣧⡒⣶⣣⠿⣼⡇",
                "⠀⠀⢸⣟⣞⣧⢿⣱⢷⣹⣯⣞⡽⣺⡵⣻⣜⣳⣽⣟⡼⣣⣛⢧⣻⣽⣺⢶⣹⢶⣿⣿⣿⣿⣿⢮⣛⡿⠿⣟⣯⣏⢿⣿⣿⡕⣎⢳⡥⢞⣯⡳⣥⢛⡴⣳⣿⣿⢏⣿⣿⡿⣽⢿⣹⢞⣿⣿⣿⣿⣿⣝⢶⡹⣏⣾⡼⣭⢞⡧⣝⣳⢾⡟⣼⣻⡜⣧⢻⡵⣭⣿⣿⣳⡽⣖⢯⣟⣿⡇",
                "⠀⠀⢸⠿⡻⢟⠿⣿⢛⡟⠿⡛⢿⠻⣽⢛⠻⣛⢛⡛⣛⣛⣛⣛⣻⠛⣛⢛⡛⣛⣿⣿⣿⣿⣿⣯⠷⣭⢷⡩⢖⣹⢎⡻⣿⣿⡌⢷⡹⣧⣯⠱⣎⠻⣼⣿⣿⡹⢞⡬⣣⢗⢮⡷⣫⣾⣿⣿⣿⣿⣿⡛⣛⢛⣛⣛⣛⢻⡟⣛⣛⡛⡛⢟⢳⡛⢿⣿⠛⠿⡛⢷⠻⢷⣿⠻⡟⠿⢿⡃",
                "⠀⠀⢾⣟⣽⡻⣎⣿⡽⣺⢽⡹⣏⠧⣟⢯⡻⣵⢫⣝⡳⣎⠷⣭⣞⢯⡳⢯⣞⣭⣿⣿⣿⣿⣿⣿⡞⣼⣳⣝⣣⢞⣥⢛⡽⢿⢻⢦⠳⣭⣗⡿⣩⢟⡼⣟⢧⣙⣏⠶⣩⡿⣮⠷⣽⣿⣿⣿⣿⣿⣿⡓⣮⢷⡹⣜⣯⢻⣧⢻⡴⢫⣝⢮⢧⣛⢧⣿⠹⣯⡝⣮⣛⢧⣿⢯⡽⣫⢟⡇",
                "⠀⠀⣹⣿⣶⣛⣶⣿⣿⣱⣏⢷⣹⣳⣿⣧⣟⣼⣳⣎⡷⣭⣻⣶⣹⣯⣽⣳⣏⣞⣿⣿⣿⣿⣿⣿⣿⢦⡹⣎⢷⣎⢧⣛⡜⣧⢫⡞⣟⡶⣯⡜⣣⢾⡱⢭⢲⡽⣜⣯⢛⣜⢶⣹⣾⣿⣿⣿⣿⣿⣿⡽⣎⣷⣫⣽⢯⣻⣧⣻⣜⣯⡞⡽⣎⣷⣯⣿⡹⣶⣹⣖⣻⢮⣿⣫⢷⣹⣻⡇",
                "⢠⣤⣚⢟⣿⣛⣏⢯⣙⣛⢻⣟⣛⡛⣝⡫⣝⢛⣋⢿⡻⣭⢭⡹⣽⣛⣛⣛⣛⣛⣿⣿⣿⣿⣿⡿⣟⡳⣝⢮⡻⢞⡿⣮⣕⢯⠶⣹⢬⡽⣗⡿⢭⢳⡽⣎⢷⡟⡿⢺⡹⢞⡮⣻⢿⣿⣿⣿⣿⣿⣿⣛⣛⣛⣟⣻⣻⣉⢯⣙⣹⡟⢫⡝⣋⡛⣞⣛⣛⣟⣏⣻⣙⣏⣛⣛⣿⣟⣻⡅",
                "⢸⣷⡻⣞⣷⡽⢮⣻⡝⣮⢽⣮⡳⢯⣳⠽⣎⢯⣆⣿⡿⣜⡳⣝⣾⣵⣫⣝⣮⡽⣿⣿⣿⣿⣿⣿⣿⣽⣽⡲⣭⣏⡶⡽⣾⣯⡗⣭⢶⣹⡿⣜⡭⣞⣷⣽⣫⣝⡾⣵⣛⢯⣽⣽⣿⣾⣿⣿⣿⣿⣿⢧⣯⣝⣮⢶⡿⡜⣧⣛⣼⡟⣧⡝⣧⣛⢶⡹⣎⣿⡇⣧⢻⡜⣧⢟⣼⡯⣼⡇",
                "⢸⣿⣿⣵⣿⣽⣯⣷⣻⣽⣞⣿⣽⣳⣭⣟⣾⣷⣾⣼⣿⣾⣵⣿⡼⣍⣏⢯⡹⣝⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣎⣳⡝⡵⢮⣟⣧⣿⣱⣯⢷⣹⡟⣧⢻⡜⣭⡝⣶⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣋⣏⣏⣛⣏⣿⣽⣶⢿⣻⣟⣶⣽⣶⣹⣮⣷⣿⣽⣧⣏⣷⣻⣼⣯⣾⣿⣷⡇",
                "⢰⡿⣭⢯⣭⢯⡭⢽⣯⣭⡽⣭⢎⣵⣩⡟⡶⣜⢦⡳⢦⣖⣲⢦⣽⣻⢼⣫⢷⣫⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣧⣣⣟⣽⣞⣾⣼⣻⢷⣿⣻⢷⢿⣞⡷⡾⣧⡽⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣝⡞⣮⢗⡾⣷⢦⡜⣶⢣⣞⡴⣭⣷⡍⢯⡭⣭⣭⢯⡽⣿⡭⣭⢭⡽⣬⢟⣳",
                "⢸⡿⣵⢻⢮⡷⣝⢻⣞⡮⢷⡽⣚⠷⣬⡿⣹⢞⡭⣟⡳⢮⡗⣯⢞⣛⣏⣟⣫⢟⣿⣿⣿⣿⣿⣿⣿⢿⣻⡼⣿⢞⣻⢏⡷⣹⢯⣗⣿⣿⣾⣿⣮⡟⣾⡝⣟⣿⣳⢿⣧⢯⣟⣿⣿⣿⣿⣿⣿⣿⣿⣛⣛⣛⣛⣛⣻⢮⡽⣚⢯⡞⣽⢶⣿⡙⣮⢗⡯⣞⢧⢿⣿⢖⣯⢻⡼⣳⣏⣿",
                "⢸⣿⣷⣏⡿⣼⣽⣻⣿⣽⣧⣻⣝⣯⣷⣿⣷⣯⣽⣾⣹⢧⣻⣼⣻⡽⣞⡾⣭⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣿⣷⣯⣽⣫⣷⣿⣿⣿⣽⣿⣿⣿⣧⣿⣳⢞⣷⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣳⢯⡽⣺⢽⣻⣎⣷⣫⢟⣼⣏⣾⣿⣳⠽⣞⣳⡽⣞⣿⡿⣾⣜⣯⢷⣯⣾⣟",
                "⢸⣟⣛⣻⢻⣟⣻⣛⣛⣛⣛⢻⣛⣛⣛⡛⣏⣛⡛⣻⢟⣛⣛⣛⣻⢿⠾⣽⢾⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⡷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡷⣿⡽⣷⣯⣟⠻⡹⣿⢛⡟⣞⠻⡽⣛⠿⣿⢛⡛⣟⠻⣟⣻⣛⡿⣟⣛⡻⣇",
                "⢸⣽⢺⣧⢻⣞⣳⡽⣚⣧⢯⣽⣿⢎⡷⣻⣜⣳⢻⡼⣟⣼⣣⢯⣻⢞⡽⣞⣳⣞⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⢿⣿⣿⣽⣿⣿⣟⣿⣿⣾⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢶⡳⣞⡶⢶⣺⢟⣵⣿⢎⡾⣭⢟⣵⣫⢾⣿⢮⢽⣺⢻⣵⢳⣏⣿⡷⣭⢷⣻",
                "⢸⣿⣳⣭⣿⣿⣞⣽⣳⢾⣝⣾⣿⣽⣞⡵⣯⣽⣳⣿⣟⡶⣭⣗⣿⣾⣽⣫⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣷⣯⣽⣯⣟⣾⣞⣿⣽⣺⣵⣛⣮⣷⡿⣿⢮⣗⢯⡷⣞⣯⣾⣿⡳⣞⣯⣿",
                "⢨⣿⡛⣟⢻⠻⣿⡽⢻⣟⡻⣟⡻⣛⠿⢿⡷⢻⢟⡻⢟⡻⣛⠟⣯⣭⡽⣭⣭⡽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣭⢯⡽⣭⢯⡿⢯⠟⡿⢻⠿⡽⢿⡿⢻⠟⡿⠿⠾⡿⢻⣿⠿⡽⠿⡟⣿⠿⣇",
                "⢸⣷⣻⢭⣯⢹⣷⣟⣳⣭⢷⣫⢷⢯⣛⢾⣟⡯⢯⣝⣯⡳⣯⢻⣽⡾⣽⣳⣛⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡽⢯⣟⡾⣯⣿⢎⣟⣞⣧⢷⡻⣽⣷⢫⠽⣭⡻⣟⡽⣯⣿⡇⢿⣹⡽⣞⣻⣿",
                "⢸⣷⢯⣻⣼⣹⣿⣿⣳⢞⣯⢳⢯⡾⣭⢿⣟⡾⣻⡼⢶⡻⣵⢻⢾⣻⣟⣟⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⡿⢾⠿⡿⣯⡟⣞⢾⡼⣳⣻⣽⡷⣫⢟⣳⡽⣽⢺⣽⣿⡞⣽⣣⣟⣳⢯⣿",
                "⢸⣿⣿⣷⣿⣼⣿⣽⣿⣿⣾⣿⣷⢿⣾⣿⣿⣷⣯⣿⣷⡿⣾⣿⣿⣳⣟⣾⣳⢯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⡽⣯⢿⣽⣿⣽⣭⡷⣏⣷⣳⣿⣿⣹⣏⣷⣻⣼⣿⢿⣻⣾⣧⣟⣾⣽⣿⣿"
            };
            box3Text[1] = new List<string>()
            {
                "원하시는 행동을 선택해 주세요",
                "1. 앞으로 나아간다   0. 마을로 돌아간다"
            };
            //2
            box1Text[2] = new List<string>()
            {
                $"Stage {room}",
                " ",
                $"{monsters[randnum1].Name}와(과) {monsters[randnum2].Name}이(가) 공격해온다!"
            };
            box3Text[2] = new List<string>()
            {
                "원하시는 공격을 선택해주세요",
                "1.    2. 3. 4. "
            };
            //3
            box1Text[3] = new List<string>()
            {
               $"Stage {room}⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀               {monsters[2].Name} HP {monsters[2].HP}/{monsters[2].MaxHP}⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⣄⣀⣀⡔⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡯⠉⠀⠀⠀⢈⣙⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣟⣒⡒⣲⣊⡙⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣶⣏⢛⡕⣏⠛⡹⣿⣿⣿⡿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⠈⣝⣶⣚⡍⢠⣿⡿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡤⢬⣶⠁⠉⠁⣱⣾⣿⡃⣠⠴⢖⣒⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠏⣴⣿⣿⠁⠛⠉⢛⣿⣿⢟⣽⣾⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⢇⣾⠟⢉⡀⠀⠀⣴⣿⡟⣵⡿⠛⠹⣿⣿⣿⣿⠴⠒⠦⣄⡀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠖⠉⢩⠏⡾⣼⠋⠀⠀⢈⠇⣼⣿⣏⣾⡇⠀⠀⠀⣿⣿⣿⡿⠀⠀⠀⠀⠙⢦⡀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠞⠁⠀⢠⠎⢠⣧⡇⠀⢀⣀⣞⣠⣿⣿⡿⠁⠀⠀⠀⠀⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠙⢦⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣃⣤⣤⣴⠃⣀⣿⢿⡗⢚⣿⠟⠋⠉⠁⠀⠈⠁⠀⠀⠀⣰⣿⣿⣿⣿⡀⠀⠀⡀⢰⣦⣀⠈⢧",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡇⠀⠈⠁⢺⠀⢸⡏⠀⠀⠀⠀⠀⠀⠀⠀⢢⣴⣿⣿⣿⣿⣿⣿⣼⠶⠟⠶⠇⠈⠛⠚⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠈⠣⣴⣳⣤⣄⣀⣀⣀⣤⣴⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠳⣦⣤⣶⣶⣶⣿⣿⣿⣿⣿⣭⣭⣭⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠉⠉⢻⡿⠻⠿⠿⠿⠿⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⠀⡀⠀⠀⠉⠈⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡙⠧⢤⣀⣀⡀⠀⠀⠀⠀⠀⣠⣿⣿⣿⣿⠿⠿⠟⢛⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                " ",
                $"{monsters[2].Name}이(가) 공격해온다!"
            };
            box3Text[3] = new List<string>()
            {
                "원하시는 공격을 선택해주세요",
                "1.    2. 3. 4. "
            };
            //4
            box1Text[4] = new List<string>()
            {
                $"Stage {room}⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀         {monsters[3].Name} HP {monsters[3].HP}/{monsters[3].MaxHP}⠀⠀",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠟⠛⠛⠿⠛⠛⠛⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⣀⣤⣤⣶⣾⣷⣶⣦⣄⠀⠀⠀⠈⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠸⢿⣿⣿⣿⣿⠋⠉⢀⣠⣾⣿⢟⣻⣇⠀⠀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⢉⡅⠀⠀⠉⢛⣻⣿⣿⣿⣿⣆⢸⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣀⠀⠀⠀⠀⠀⠀⢸⣿⣤⣀⣀⣴⣿⣿⣿⣿⣿⣿⣿⣷⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⣠⡄⠀⣿⣿⣿⣿⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠈⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⣭⠂⠀⠸⠿⠟⢛⣥⣌⣿⣿⣿⣿⣿⣿⣿⡏⠁⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡀⠈⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠴⢿⣿⣿⣿⣿⣿⢿⣇⡀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⡿⠋⠁⣼⣿⣿⣿⣦⣄⣀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⠟⠛⠋⠀⢀⣼⣿⡟⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ⣿⣿⣿⣿⡿⠟⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⡿⠁⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿",
                "                                     ",
                $"{monsters[3].Name}이(가) 공격해온다!"
            };
            box3Text[4] = new List<string>()
            {
                "원하시는 공격을 선택해주세요",
                "1.    2. 3. 4. "
            };
            //5
            box1Text[5] = new List<string>()
            {
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣍⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⣿⡍⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠛⢿⣿⣦⡀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣧⠽⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   ⠀⠀⢻⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡤⡼⠚⣅⠙⢶⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   ⠀⠀⢻⣿⣷⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡀⠀⣻⣴⣤⣯⣔⣼⣄⣠⣴⣆⣀⣀⣀⣀⣀⣀⣀⣀⣀⣸⣿⣿⡄⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                                                      ",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⢿⣿⣿⠃⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠛⠛⠻⣿⣟⣉⣉⣉⡹⠟⢯⡉⠹⡏⡉⠻⢍⣹⡩⠿⠉⢹⣇⡴⡿⠻⢲⢟⣙⡟⠀⠀⠀⢸⣿⣿⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠹⣷⠡⣄⣰⠐⠈⢧⠸⠲⠃⠀⡀⠀⢹⠀⠀⡀⠘⣫⣄⠋⢀⣷⣉⡿⠁⠀⠀⠀  ⢸⣿⣿⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠘⣷⠠⠽⠷⣄⡘⡧⠀⢀⠀⠈⠓⢾⡶⠚⠀⠀⣿⡸⠟⠁⢀⣸⠧⠀⠀⠀   ⠀⣼⣿⣿⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⢘⡯⠀⠴⠾⠛⠳⢦⣼⡄⠀⠀⢸⡁⢀⣤⠖⠛⠳⢶⣶⠟⠁⠀⠀⠀  ⠀ ⠀⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠘⠻⠿⣤⣀⠶⠖⠚⠋⠉⠟⠻⢶⣬⣖⡋⠉⠛⣂⢠⡟⠁⠀⠀⠀⠀⠀   ⠀⠀⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠉⠓⡆⠀⢀⣀⡤⢶⣿⣿⡿⠿⣟⣙⣷⣾⣻⣦⡤⠀⠀⠀⠀  ⠀  ⠀⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⢩⣛⣋⣙⡴⠋⠀⣿⡇⠀⠀⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀     ⠀⠀⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠁⠀⠁⠀⠀ ⠀⡿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀     ⠀⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠐⠷⠇⠀⠀⣀⣀⣀⣀⣠⣤⣤⣤⣤⣶⣶⣶⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⣀⣀⣀⣀⣠⣤⣤⣤⣤⣶⣶⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠿⠿⠿⠛⠛⠛⠁⠀⠀⠀⠀⠀⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⠟⠛⠛⠛⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                " ",
                " "
            };
            box3Text[5] = new List<string>()
            {
                "키보드를 눌러 마을로 귀환"
            };
        }
    }
}
