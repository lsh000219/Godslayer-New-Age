using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.Kiahn
{
    internal class Inventory
    {
        // 인벤토리 리스트
        static List<ItemData> inventoryList = new List<ItemData>();
        // 장착된 아이템 리스트
        static List<ItemData> equippedList = new List<ItemData>();


        public void Display()
        {

        }

        // 인벤토리에서 아이템 장착
        public void Equip(ItemData item)
        {
            equippedList.Add(item);
        }

        // 인벤토리에 아이템 추가
        public void GetItem(ItemData item)
        {
            inventoryList.Add(item);
            Console.WriteLine($"{item.Name}이(가) 인벤토리에 추가되었습니다.");
        }

        // 인벤토리에서 아이템 버리기
        public void DropItem(ItemData item)
        {
            if (inventoryList.Contains(item))
            {
                inventoryList.Remove(item);
                Console.WriteLine($"{item.Name}이(가) 인벤토리에서 제거되었습니다.");
            }
            else
            {
                Console.WriteLine($"{item.Name}은(는) 인벤토리에 없습니다.");
            }
        }
    }
}