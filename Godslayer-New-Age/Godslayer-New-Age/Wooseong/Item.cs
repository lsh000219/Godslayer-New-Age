using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Data
{
    public class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public Dictionary<StatType, float> Option { get; set; }
        public string Desc {  get; set; }
        public string PassiveDesc { get; set; }
        public int Price {  get; set; }


        public Item(string name, ItemType type, Dictionary<StatType, float> option, string desc, string passiveDesc, int price)
        {
            Name = name;
            Type = type;
            Option = option;
            Desc = desc;
            PassiveDesc = passiveDesc;
            Price = price;
        }
    }
}
