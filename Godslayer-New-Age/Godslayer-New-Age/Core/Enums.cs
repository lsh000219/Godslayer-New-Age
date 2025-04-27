using System.ComponentModel;

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