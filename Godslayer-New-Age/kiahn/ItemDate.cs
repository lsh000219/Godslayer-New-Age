using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age
{
    //아이템 타입 열거형
    enum ItemType
    {
        Weapon, //0 : 무기
        Armor,  //1 : 방어구
        accessory //2 : 장신구
    }

    //아이템 데이터 클래스
    internal class ItemData
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }

        public ItemData(string name, ItemType type, int atk, int def, string desc, int price)
        {
            Name = name;
            Type = type;
            Atk = atk;
            Def = def;
            Desc = desc;
            Price = price;
        }
    }
}