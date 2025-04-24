using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class ItemDB
    {
        public static Item[] riceMonkeyItems = new Item[]
        {
            //name ,type, option, desc, passiveDesc, price
            new Item("고성능확성기", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 10 } }, "쌀을 팔 때 사용하는 고성능 확성기", "", 1000),
        };

        public static Item[] juGallerItems = new Item[]
        {
            //name ,type, option, desc, passiveDesc, price
            new Item("고성능확성기", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 10 } }, "쌀을 팔 때 사용하는 고성능 확성기", "", 1000),
        };

        public static Item[] ProGamerItems = new Item[]
        {
            //name ,type, option, desc, passiveDesc, price
            new Item("고성능확성기", ItemType.Weapon, new Dictionary<StatType, float>{{ StatType.ATK, 10 } }, "쌀을 팔 때 사용하는 고성능 확성기", "", 1000),
        };
    }
}