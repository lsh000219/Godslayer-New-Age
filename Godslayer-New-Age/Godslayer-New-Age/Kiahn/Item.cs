using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Godslayer_New_Age
{
    //아이템 리스트
    internal class Item
    {
        public static List<ItemData> itemList = new List<ItemData>();

        //아이템 세팅
        public void SetItem()
        {
            itemList.Add(new ItemData("나무검", ItemType.Weapon, 5, 0, "나무로 만들어진 검", 100));
            itemList.Add(new ItemData("철검", ItemType.Weapon, 10, 0, "철로 만들어진 검", 200));
            //수정 예정
        }
    }
}
