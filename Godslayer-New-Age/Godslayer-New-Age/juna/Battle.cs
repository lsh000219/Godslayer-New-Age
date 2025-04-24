using Godslayer_New_Age.Kiahn;
using Godslayer_New_Age.LJM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Godslayer_New_Age.juna
{
    class Battle
    {
        private int life_point = 5;
        Random random = new Random();

        List<Monster> enemyMonster = new List<Monster>();
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
            enemyMonster.Add(monster1);
            enemyMonster.Add(monster2);

            Console.WriteLine($"{monster1.Name}와(과) {monster2.Name}이(가) 공격해온다!");

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

                turnList.Sort((a, b) => b.speed.CompareTo(a.speed));//순서 정렬

                foreach (var entry in turnList)//순서에 따라 하나씩 실행
                {
                    if (entry.character is Player)
                    {
                        PlayerTurn();
                    }
                    else if (entry.character is Monster monster)
                    {
                        MonsterTurn(monster);
                    }
                }
                if (monster1.HP == 0)
                {
                    Player.Instance.EXP += monster1.EXP;
                    Console.WriteLine($"{monster1.Name}을(를) 쓰러뜨렸습니다.");
                    Console.WriteLine($"{monster1.EXP} 경험치를 획득하였습니다.");
                }
                if (monster2.HP == 0)
                {
                    Player.Instance.EXP += monster2.EXP;
                    Console.WriteLine($"{monster2.Name}을(를) 쓰러뜨렸습니다.");
                    Console.WriteLine($"{monster2.EXP} 경험치를 획득하였습니다.");
                }
                turn++;
            }
            if (Player.Instance.HP == 0)
            {
                Console.WriteLine("신살을 실패하였습니다");
                life_point--;
                CheckLife();
                Console.WriteLine("당신은 의식을 잃고 무엇인가의 힘에 의해 집으로 복귀했습니다.");
                Console.WriteLine($"돈의 절반을 잃어버렸습니다(-{Player.Instance.Gold - Player.Instance.Gold / 2})gold");
                Player.Instance.Gold = Player.Instance.Gold / 2;
            }
            else
            {
                Console.WriteLine("승리하였습니다");
                if (HasPlusGold())
                {
                    Console.WriteLine($"+{(monster1.Gold + monster2.Gold) * 2}gold");
                    Player.Instance.Gold += (monster1.Gold + monster2.Gold) * 2;
                }
                else
                {
                    Console.WriteLine($"+{monster1.Gold + monster2.Gold}gold");
                    Player.Instance.Gold += monster1.Gold + monster2.Gold;
                }
            }
            enemyMonster.Clear();
        }
        public void StartBattle(Monster boss)//보스전
        {
            int turn = 1;
            enemyMonster.Add(boss);
            Console.WriteLine($"{boss.Name}이(가) 공격해온다!");

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
                if (boss.HP == 0)
                {
                    Player.Instance.EXP += boss.EXP;
                    Console.WriteLine($"{boss.Name}을(를) 쓰러뜨렸습니다.");
                    Console.WriteLine($"{boss.EXP} 경험치를 획득하였습니다.");
                }
                turn++;
            }
            if (Player.Instance.HP == 0)
            {
                Console.WriteLine("신살을 실패하였습니다");
                life_point--;
                CheckLife();
                Console.WriteLine("당신은 의식을 잃고 무엇인가의 힘에 의해 집으로 복귀했습니다.");
                Console.WriteLine($"돈의 절반을 잃어버렸습니다(-{Player.Instance.Gold - Player.Instance.Gold / 2})gold");
                Player.Instance.Gold = Player.Instance.Gold / 2;
            }
            else
            {
                Console.WriteLine("승리하였습니다");
                if (HasPlusGold())
                {
                    Console.WriteLine($"+{boss.Gold * 2}gold");
                    Player.Instance.Gold += boss.Gold * 2;
                }
                else
                {
                    Console.WriteLine($"+{boss.Gold}gold");
                    Player.Instance.Gold += boss.Gold;
                }
                BossDrop(boss.Name);
                enemyMonster.Clear();
            }
        }
        
        public void PlayerTurn()
        {
            if(Player.Instance.CanMove)
            {
                Console.WriteLine("원하시는 공격을 선택해주세요");
                Console.WriteLine($"1.   2.   3.   4.   ");//스킬이나 평타 이름을 저장한 것을 넣기
                int playerselect = CheckInput(1, 4);
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
                }
            }
            else
            {
                Console.WriteLine($"{Player.Instance.Name}은(는) 기절 상태입니다");
            }
        }

        public void MonsterTurn(Monster monster)
        {
            if(monster.CanMove)
            {
                int num = monster.MonsterSkills.Count;
                int skillnum = random.Next(0, num);
                //monster.MonsterSkills[skillnum]
            }
            else
            {
                Console.WriteLine($"{monster.Name}은(는) 기절 상태입니다");
            }
        }
        public bool HasPlusGold()
        {
            string[] namesToCheck = { "솜크빈", "자석펫", "테슬라 기어봉", "화성인 가면", "그랜드 마스터 딱지", "챌린저 딱지" };

            return Inventory.equippedList.Any(item => namesToCheck.Contains(item.Name));
        }
        public void BossDrop(string bossname)
        {
            if (bossname == "신창섭" && Player.Instance.PlayerJob == Player.Job.RiceMonkey)
            {
                ItemData absolcalibur = new ItemData("앱솔칼리버", eItemType.Weapon, 100, 0, "신창섭의 가호를 받은 기간제 무기", "", 8500);
                Inventory.inventoryList.Add(absolcalibur);
                ItemData challengerArmor = new ItemData("도전자의_갑옷", eItemType.Armor, 0, 80, "신창섭의 가호를 받은 기간제 갑옷", "", 9000);
                Inventory.inventoryList.Add(challengerArmor);
                Console.WriteLine($"{Player.Instance.Name}은(는) {bossname}을 꺾고 {absolcalibur.Name}와 {challengerArmor.Name}을 획득하였다!!");
            }
            else if (bossname == "일론 머스크" && Player.Instance.PlayerJob == Player.Job.CEO)
            {
                ItemData videoGame = new ItemData("일론의 비디오게임", eItemType.Weapon, 110, 0, "일론머스크가 베이직으로 개발한 비디오 게임", "", 12000);
                Inventory.inventoryList.Add(videoGame);
                ItemData titaniumSpacesuit = new ItemData("티타늄 우주복", eItemType.Armor, 0, 85, "티타늄을 제작된 전설의 우주복", "", 9000);
                Inventory.inventoryList.Add(titaniumSpacesuit);
                Console.WriteLine($"{Player.Instance.Name}은(는) {bossname}을 꺾고 {videoGame.Name}과 {titaniumSpacesuit.Name}을 획득하였다!!");
            }
            else if (bossname == "신" && Player.Instance.PlayerJob == Player.Job.ProGamer)
            {
                ItemData trophy = new ItemData("롤드컵 우승트로피", eItemType.Weapon, 110, 0, "대상혁의 월드 챔피언십 우승 트로피", "", 12000);
                Inventory.inventoryList.Add(trophy);
                ItemData costumePlay = new ItemData("롤드컵 우승 기념 챔피언 코스프레", eItemType.Armor, 0, 85, "대상혁이 언젠가 입었을지도...", "", 9000);
                Inventory.inventoryList.Add(costumePlay);
                Console.WriteLine($"{Player.Instance.Name}은(는) {bossname}을 꺾고 {trophy.Name}와 {costumePlay.Name}를 획득하였다!!");
            }
        }
        public void Target()
        {
            Console.WriteLine("공격 대상을 선택해주세요");
            Console.Write($"1.{enemyMonster[0].Name} ");//스킬이나 평타 이름을 저장한 것을 넣기
            if (enemyMonster[1] != null)
            {
                Console.WriteLine($"2.{enemyMonster[1].Name}");
            }
            int playerselect = CheckInput(1, enemyMonster.Count);
            switch (playerselect)
            {
                case 1:
                    
                    break;
                case 2:
                    
                    break;
            }
        }
        public void CheckLife()
        {
            if (life_point > 0)
            {
                Console.WriteLine($"기회가 {life_point}번 남았습니다...");//요 부분은 글자색을 빨강색으로 하면 좋을듯?
            }
            else if (life_point == 0)
            {
                Console.WriteLine("You Die...");
                //강종과 save데이터 삭제하는 함수 추가
            }
        }
    }
}