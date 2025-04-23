using Godslayer_New_Age;
using Godslayer_New_Age.Kiahn;
using Godslayer_New_Age.LJM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Utils;

//인벤토리 장착 관리
//장착 중인 아이템은 [장착 중] 표시
//장착관리 선택 -> 아이템 선택 -> 우측 UI에 아이템 추가 -> 장착 문구 출력
//장착관리 선택 -> 장착 중인 아이템 선택 -> 우측 UI에 아이템 제거 -> 장착 해제 문구 출력

//UI 우성님과 진행
//플레이어 공격력, 방어력 추가 기능은 종민님과 진행

namespace Godslayer_New_Age.Kiahn
{
    internal class Inventory
    {
        //싱글톤
        private static Inventory inventory;
        public static Inventory Instance()
        {
            if (inventory == null)
            {
                inventory = new Inventory();
            }
            return inventory;
        }

        // 인벤토리 리스트
        public static List<ItemData> inventoryList = new List<ItemData>();
        // 장착된 아이템 리스트
        public static List<ItemData> equippedList = new List<ItemData>();

        public static List<string> inventoryText = new List<string>() { };

        public static void Display()
        {
            int i = 0;
            foreach (var item in inventoryList)
            {
                i++;
                string isEquipped = equippedList.Contains(item) ? "[장착 중]" : "";
                inventoryText.Add($"`darkGreen,black`[{i}] `darkGray,black`[{item.TypeName}] `white,black`{item.Name} `yellow,black`{item.PassiveDesc}");
                inventoryText.Add($"           `red,black`ATK: {item.Atk} `cyan,black`DEF: {item.Def} `white,black`{item.Desc} `yellow,black`{isEquipped}");
                inventoryText.Add($"`white,black`----------------------------------------------------------------------------------------------------");
            }

            PrintDB.box1Data = inventoryText;
        }

        // 인벤토리에서 아이템 장착
        public static void Equip()
        {
            int input = int.Parse(Console.ReadLine());
            int num = input - 1;
            equippedList.Add(inventoryList[num]);
            //장비 UI 뜨게
        }
    }
}