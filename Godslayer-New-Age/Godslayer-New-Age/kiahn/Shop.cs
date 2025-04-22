using Godslayer_New_Age;
using System;
using System.Collections.Generic;
using System.Linq;
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
        static List<ItemData> shopItemList = new List<ItemData>();

        public void SetShopItemList()
        {
            SetWeapon();
            SetArmor();
            SetAccessory();
            Console.WriteLine("*신들의 아이템 목록이 설정되었습니다*");
        }

        // 무기 데이터 설정
        private void SetWeapon()
        {
            ItemData Sword = new ItemData("Sword", eItemType.Weapon, 10, 0, "", 1000);
            shopItemList.Add(Sword);
        }

        // 방어구 데이터 설정
        private void SetArmor()
        {
            ItemData Armor = new ItemData("Armor", eItemType.Armor, 0, 10, "", 1000);
            shopItemList.Add(Armor);
        }

        // 장신구 데이터 설정
        private void SetAccessory()
        {
            ItemData Accessory = new ItemData("Accessory", eItemType.accessory, 0, 0, "", 1000);

            shopItemList.Add(Accessory);
        }


        public void Display()
        {

        }

        public void Buy()
        {

        }

        public void Sell()
        {

        }
    }
}