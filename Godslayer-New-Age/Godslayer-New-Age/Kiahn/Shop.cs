using Godslayer_New_Age;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Program.cs에 추가할 것
//
//Shop shop = new Shop();
//shop.SetShopItemList();

namespace Godslayer_New_Age
{
    internal class Shop
    {
        public List<ItemData> shopItemList = new List<ItemData>();

        public void SetItemList()
        {
            //직업 : 쌀숭이
            //무기
            ItemData megaphone = new ItemData("고성능확성기", eItemType.Weapon, 10, 0, "쌀을 팔 때 사용하는 고성능 확성기", "", 1000);
            ItemData grapeWeapon = new ItemData("포도무기", eItemType.Weapon, 30, 0, "포도색 무기", "", 2500);
            ItemData picane = new ItemData("피케인", eItemType.Weapon, 50, 0, "피씨방에 가서 200시간 메이플을 했다는 증거", "", 4500);
            //ItemData absolcalibur = new ItemData("앱솔칼리버", eItemType.Weapon, 100, 0, "신창섭의 가호를 받은 기간제 무기", "", 8500);
            //방어구
            ItemData droppedArmor = new ItemData("드랍된 갑옷", eItemType.Armor, 0, 10, "언젠가 어떤 몬스터가 드랍했던 갑옷이다", "", 1500);
            ItemData grapeArmor = new ItemData("포도갑옷", eItemType.Armor, 0, 30, "포도색 갑옷", "", 3000);
            ItemData dirtCane = new ItemData("흙케인", eItemType.Armor, 0, 50, "싼 값으로 만든 가성비 갑옷", "", 6000);
            //ItemData challengerArmor = new ItemData("도전자의_갑옷", eItemType.Armor, 0, 80, "신창섭의 가호를 받은 기간제 갑옷", "", 9000);
            //장신구
            ItemData droppedAccessory = new ItemData("드랍된 장신구", eItemType.accessory, 5, 3, "언젠가 어떤 몬스터가 드랍했던 장신구다", "", 1500);
            ItemData grapeAccessory = new ItemData("포도장신구", eItemType.accessory, 10, 5, "포도색 장신구", "", 2500);
            ItemData somkbean = new ItemData("솜크빈", eItemType.accessory, 0, 0, "신창섭의 대표 사료", "(골드 추가보상 100%)", 5000);
            ItemData magnetPet = new ItemData("자석펫", eItemType.accessory, 40, 0, "프펫공을 전부 5를 띄운 전설의 자석펫", "(골드 추가보상 100%)", 6000);

            //무기
            shopItemList.Add(megaphone);
            shopItemList.Add(grapeWeapon);
            shopItemList.Add(picane);
            //shopItemList.Add(absolcalibur);
            //방어구
            shopItemList.Add(droppedArmor);
            shopItemList.Add(grapeArmor);
            shopItemList.Add(dirtCane);
            //shopItemList.Add(challengerArmor);
            //장신구
            shopItemList.Add(droppedAccessory);
            shopItemList.Add(grapeAccessory);
            shopItemList.Add(somkbean);
            shopItemList.Add(magnetPet);


            //직업 : CEO
            ItemData blueStick = new ItemData("푸른색 막대기", eItemType.Weapon, 20, 0, "계속 떨어지는 당신의 주식 차트 색깔", "", 1500);
            ItemData redStick = new ItemData("빨간색 막대기", eItemType.Weapon, 35, 0, "이런 일은 일어나지 않아요", "", 2500);
            ItemData commodore = new ItemData("코모도어 컴퓨터", eItemType.Weapon, 65, 0, "일론이 어렸을 적, 이 컴퓨터로 개발을 시작했다", "", 5500);
            //ItemData videoGame = new ItemData("일론의 비디오게임", eItemType.Weapon, 110, 0, "일론머스크가 베이직으로 개발한 비디오 게임", "", 12000);
            //방어구
            ItemData engineerPants = new ItemData("공대생 바지", eItemType.Armor, 0, 10, "아무도 나랑 안 놀아줄 것 같은 바지", "", 1500);
            ItemData elonSuit = new ItemData("일론의 정장", eItemType.Armor, 0, 25, "일론의 성공이 묻은 정장", "", 3000);
            ItemData spaceSuit = new ItemData("최첨단 우주복", eItemType.Armor, 0, 50, "입고 화상갈끄니까앗", "", 6000);
            //ItemData titaniumSpacesuit = new ItemData("티타늄 우주복", eItemType.Armor, 0, 85, "티타늄을 제작된 전설의 우주복", "", 9000);
            //장신구
            ItemData dogeCoin = new ItemData("빛바랜 도지코인", eItemType.accessory, 5, 3, "결국, 곤두박질친 도지코인", "", 1500);
            ItemData spacexWreck = new ItemData("스페이스X의 잔해", eItemType.accessory, 10, 5, "가지면 마스터를 갈 것만 같지만 너의 착각이다", "", 2500);
            ItemData teslaGearKnob = new ItemData("테슬라 기어봉", eItemType.accessory, 0, 0, "맨들맨들한 기어봉", "(골드 추가보상 100%)", 5000);
            ItemData marsMask = new ItemData("화성인 가면", eItemType.accessory, 40, 0, "이거 쓰고 화성갈꺼니까앗", "(골드 추가보상 100%)", 6000);

            //무기
            shopItemList.Add(blueStick);
            shopItemList.Add(redStick);
            shopItemList.Add(commodore);
            //shopItemList.Add(videoGame);
            //방어구
            shopItemList.Add(engineerPants);
            shopItemList.Add(elonSuit);
            shopItemList.Add(spaceSuit);
            //shopItemList.Add(titaniumSpacesuit);
            //장신구
            shopItemList.Add(dogeCoin);
            shopItemList.Add(spacexWreck);
            shopItemList.Add(teslaGearKnob);
            shopItemList.Add(marsMask);




            //직업 : 프로게이머
            ItemData gamingMouse = new ItemData("게이밍 마우스", eItemType.Weapon, 20, 0, "어디선가 주워온 싸구려 마우스", "", 1500);
            ItemData rgbKeyboard = new ItemData("RGB 키보드", eItemType.Weapon, 35, 0, "컬러풀한 보급형 키보드", "", 2500);
            ItemData monitor = new ItemData("1000Hz 모니터", eItemType.Weapon, 65, 0, "신들만이 쓸 수 있다는 전설의 모니터", "", 5500);
            //ItemData trophy = new ItemData("롤드컵 우승트로피", eItemType.Weapon, 110, 0, "대상혁의 월드 챔피언십 우승 트로피", "", 12000);
            //방어구
            ItemData gamingGlasses = new ItemData("게이밍 안경", eItemType.Armor, 0, 10, "평범한 게이밍 안경", "", 1500);
            ItemData gamingUniform = new ItemData("게이밍 유니폼", eItemType.Armor, 0, 25, "저렴한 게이밍 유니폼", "", 3000);
            ItemData sponsoredUniform = new ItemData("협찬받은 유니폼", eItemType.Armor, 0, 50, "대상혁의 피땀눈물이 묻은 유니폼", "", 6000);
            //ItemData costumePlay = new ItemData("롤드컵 우승 기념 챔피언 코스프레", eItemType.Armor, 0, 85, "신창섭의 가호를 받은 기간제 갑옷", "", 9000);
            //장신구
            ItemData diamondSticker = new ItemData("다이아 딱지", eItemType.accessory, 5, 3, "다이아몬드가 박힌 딱지다", "", 1500);
            ItemData masterSticker = new ItemData("마스터 딱지", eItemType.accessory, 10, 5, "가지면 마스터를 갈 것만 같지만 너의 착각이다", "", 2500);
            ItemData grandMasterSticker = new ItemData("그랜드 마스터 딱지", eItemType.accessory, 0, 0, "아무나 범접할 수 없는 딱지", "(골드 추가보상 100%)", 5000);
            ItemData challengerSticker = new ItemData("챌린저 딱지", eItemType.accessory, 40, 0, "대상혁만이 이룰 수 있다는 챌린저", "(골드 추가보상 100%)", 6000);

            //무기
            shopItemList.Add(gamingMouse);
            shopItemList.Add(rgbKeyboard);
            shopItemList.Add(monitor);
            //shopItemList.Add(trophy);
            //방어구
            shopItemList.Add(gamingGlasses);
            shopItemList.Add(gamingUniform);
            shopItemList.Add(sponsoredUniform);
            //shopItemList.Add(costumePlay);
            //장신구
            shopItemList.Add(diamondSticker);
            shopItemList.Add(masterSticker);
            shopItemList.Add(grandMasterSticker);
            shopItemList.Add(challengerSticker);

            Console.WriteLine("*신들의 아이템 목록이 설정되었습니다*");
        }

        public void Display()
        {
            foreach (var item in shopItemList)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[{item.TypeName}] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{item.Name}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  {item.PassiveDesc}");
                if (item.TypeName == "무기")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"ATK: {item.Atk}  ".PadRight(3));
                }
                else if (item.TypeName == "방어구")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"DEF: {item.Def}  ".PadRight(3));
                }
                else if (item.TypeName == "장신구")
                {
                    if (item.Atk == 0 && item.Def == 0) { Console.Write("".PadRight(15)); }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"ATK: {item.Atk}  ".PadRight(3));
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"DEF: {item.Def}  ".PadRight(3));
                    }
                }
                
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{item.Desc}  ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{item.Price} G");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------------------------------");
            }
        }

        public void Buy()
        {

        }

        public void Sell()
        {

        }
    }
}
