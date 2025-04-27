using System.Collections.Generic;
using System.Linq;

public class PlayerInventory
{
    private static List<Item> inventory = new List<Item>();
    private static List<Item> equipped = new List<Item>();

    public static IReadOnlyList<Item> Items => inventory;
    public static IReadOnlyList<Item> EquippedItems => equipped;

    public static bool HasItem(Item item)
    {
        return inventory.Any(i => i.Name == item.Name);
    }

    public static Item GetEquipped(ItemType type)
    {
        return equipped.FirstOrDefault(i => i.Type == type);
    }

    public static void Add(Item item)
    {
        if (!inventory.Any(i => i.Name == item.Name))
            inventory.Add(item);
    }

    public static void Remove(Item item)
    {
        inventory.Remove(item);
        equipped.Remove(item);
    }

    public static void Equip(Item priorItem, Item nextItem)
    {
        if (priorItem == null && nextItem == null)
            return;

        if (priorItem != null && nextItem != null && priorItem.Name == nextItem.Name)
        {
            equipped.Remove(priorItem);
            return;
        }

        if (priorItem != null)
            equipped.Remove(priorItem);

        if (nextItem != null)
            equipped.Add(nextItem);
    }

    public static float GetStatBonus(StatType type)
    {
        return equipped.Where(i => i.Option.ContainsKey(type)).Sum(i => i.Option[type]);
    }


    public static string GetStatBonusToStr(StatType stat)
    {
        float bonus = GetStatBonus(stat);

        if (bonus > 0)
            return $"( +{bonus} )";
        else if (bonus < 0)
            return $"( {bonus} )";
        else
            return "";
    }


    public static void Display(ref List<string> list)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            var item = inventory[i];
            string name = equipped.Contains(item)
                ? "[E] " + item.Name
                : item.Name;
            name = PrintUtil.AlignLeft(name, 22);

            string options = string.Join(", ",
                item.Option.Select(o =>
                {
                    string colorTag = "";
                    switch (o.Key)
                    {
                        case StatType.HP: colorTag = "`darkred,black` "; break;
                        case StatType.ATK: colorTag = "`red,black` "; break;
                        case StatType.DEF: colorTag = "`blue,black` "; break;
                        case StatType.CRT: colorTag = "`magenta,black` "; break;
                        case StatType.EVA: colorTag = "`green,black` "; break;
                        case StatType.SPD: colorTag = "`cyan,black` "; break;
                    }

                    return $"{colorTag}{o.Key} {(o.Value >= 0 ? "+" : "")}{o.Value}";
                }));

            options = PrintUtil.AlignLeft(options, 30);
            string passiveDesc = PrintUtil.AlignLeft($"`darkyellow,black`{item.PassiveDesc}", 27);
            string desc = $"    `darkgray.blak`{item.Desc}";

            list.Add($"`darkGreen,black`[{i + 1,2}] `gray,black`{name}|{options}`gray,black`| {passiveDesc}");
        }
    }

    public static void DisplayForSell(ref List<string> list)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            var item = inventory[i];
            string name = equipped.Contains(item)
                ? "[E] " + item.Name
                : item.Name;
            name = PrintUtil.AlignLeft(name, 22);

            string options = string.Join(", ",
            item.Option.Select(o =>
            {
                string colorTag = "";
                switch (o.Key)
                {
                    case StatType.HP: colorTag = "`darkred,black` "; break;
                    case StatType.ATK: colorTag = "`red,black` "; break;
                    case StatType.DEF: colorTag = "`blue,black` "; break;
                    case StatType.CRT: colorTag = "`magenta,black` "; break;
                    case StatType.EVA: colorTag = "`green,black` "; break;
                    case StatType.SPD: colorTag = "`cyan,black` "; break;
                }

                return $"{colorTag}{o.Key} {(o.Value >= 0 ? "+" : "")}{o.Value}";
            }));

            options = PrintUtil.AlignLeft(options, 30);
            string passiveDesc = PrintUtil.AlignLeft($"`darkyellow,black`{item.PassiveDesc}", 27);
            string price = PrintUtil.AlignRight($"`yellow,black`{item.Price} G", 10);
            string desc = $"    `darkgray.blak`{item.Desc}";

            list.Add($"`darkGreen,black`[{i + 1,2}] `gray,black`{name}|{options}`gray,black`| {passiveDesc} `gray,black`|{price}");
        }
    }

    public static string GetEquippedName(ItemType type)
    {
        return equipped.FirstOrDefault(i => i.Type == type)?.Name ?? "";
    }
}