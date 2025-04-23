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

namespace Godslayer_New_Age.Kiahn
{
    internal static class Inventory
    {
        // 인벤토리 리스트
        public static List<ItemData> inventoryList = new List<ItemData>();
        // 장착된 아이템 리스트
        public static List<ItemData> equippedList = new List<ItemData>();

        public static List<string> inventoryText = new List<string>() { };

        public static void Display()
        {
            int i = 0;
            inventoryText.Add($"`darkGreen,black`[번호] `darkGray,black`[분류] `white,black`[아이템명] " +
                    $"`red,black`[공격력] `cyan,black`[방어력] `white,black`[설명......................] `yellow,black`[가격]");
            inventoryText.Add($"`white,black`----------------------------------------------------------------------------------------------------");
            foreach (var item in inventoryList)
            {
                i++;
                inventoryText.Add($"`darkGreen,black`[{i}] `darkGray,black`[{item.TypeName}] `white,black`{item.Name} `yellow,black`{item.PassiveDesc} " +
                    $"`red,black`ATK: {item.Atk} `cyan,black`DEF: {item.Def} `white,black`{item.Desc} `yellow,black`{item.Price} G");
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