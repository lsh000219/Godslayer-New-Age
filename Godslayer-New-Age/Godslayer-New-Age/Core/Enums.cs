using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public enum ItemType
    {
        [Description("무기")]
        Weapon,
        [Description("방어구")]
        Armor,
        [Description("장신구")]
        Accessory
    }

    public enum StatType
    {
        HP,
        ATK,
        DEF,
        CRT,
        EVA,
        SPD
    }

    public enum Job
    {
        RiceMonkey = 0,
        Jugaller = 1,
        ProGamer = 2
    }
}
