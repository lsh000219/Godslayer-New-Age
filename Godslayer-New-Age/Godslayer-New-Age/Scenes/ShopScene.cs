using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

public class ShopScene : IScene
{
    Item[] shopItems;
    Item[] inventoryItems;
    int choice = 0;
    string tempDesc;
    bool canBuy = true;

    public GameState SceneType => GameState.Shop;

    public GameState Run(int phase)
    {
        AppendItemList();

        PrintDB.box1Data = box1Text.ContainsKey(phase) ? box1Text[phase] : new List<string>();
        PrintDB.box2Data = PrintDB.GetPlayerStatus();
        PrintDB.box3Data = box3Text.ContainsKey(phase) ? box3Text[phase] : new List<string>();
        PrintUtil.CreateBox();

        string input = Console.ReadLine();
        int.TryParse(input, out int numInput);

        switch (phase)
        {
            case 0: // 구매 페이즈
                if (numInput == 0) return GameState.Pop;
                if (numInput >= 1 && numInput <= shopItems.Length)
                {
                    Item selectedItem = shopItems[numInput - 1];

                    if (PlayerInventory.HasItem(selectedItem))
                    {
                        box3Text[1] = new List<string>
                            {
                                "이 아이템을 이미 가지고 있습니다.",
                                "구매 창으로 돌아갑니다."
                            };
                        PrintDB.box3Data = box3Text[1];
                        canBuy = false;
                    }
                    else if (Player.Instance.Gold < selectedItem.Price)
                    {
                        box3Text[1] = new List<string>
                            {
                                "골드가 부족합니다.",
                                "구매 창으로 돌아갑니다."
                            };
                        PrintDB.box3Data = box3Text[1];
                        canBuy = false;
                    }
                    else
                    {
                        choice = numInput - 1;
                        tempDesc = shopItems[choice].Desc;
                        RenewBox3(phase, tempDesc);
                        canBuy = true;
                    }
                    return Run(1);
                }
                if (numInput == 100) return Run(2); // 판매 페이즈로 이동
                break;

            case 1: // 구매 확정 페이즈
                if (!canBuy)
                    return Run(0); // 구매 불가 상태면 바로 돌아가기
                if (numInput == 1)
                {
                    Item selectedItem = shopItems[choice];
                    Player.Instance.Gold -= selectedItem.Price;
                    PlayerInventory.Add(selectedItem);
                    return Run(0);
                }
                if (numInput == 0)
                    return Run(0);
                break;

            case 2: // 판매 페이즈
                if (numInput == 0) return GameState.Pop;
                if (numInput >= 1 && numInput <= inventoryItems.Length)
                {
                    choice = numInput - 1;
                    tempDesc = inventoryItems[choice].Desc;
                    RenewBox3(phase, tempDesc);
                    return Run(3); // 판매 확정 페이즈로 이동
                }
                if (numInput == 100) return Run(0); // 구매 페이즈로 이동
                break;

            case 3: // 판매 확정 페이즈
                if (numInput == 1)
                {
                    Item selectedItem = inventoryItems[choice];
                    int sellPrice = (int)(selectedItem.Price * 0.8f);

                    Player.Instance.Gold += sellPrice;
                    PlayerInventory.Remove(selectedItem);
                    return Run(2);
                }

                if (numInput == 0)
                    return Run(2);
                break;

        }

        return GameState.Retry;
    }

    public Dictionary<int, List<string>> box1Text = new Dictionary<int, List<string>>();
    public Dictionary<int, List<string>> box3Text = new Dictionary<int, List<string>>();


    public ShopScene()
    {

        //구매창 기본 인터페이스
        box1Text[0] = new List<string>();

        box3Text[0] = new List<string>()
            {
                "아이템의 번호를 입력해 구매할 수 있습니다.",
                "100. 아이템판매          0. 돌아가기"
            };

        //구매창 확인 인터페이스(플레이버 텍스트, 가격 출력)
        box1Text[1] = new List<string>();

        box3Text[1] = new List<string>();

        //판매창 기본 인터페이스
        box1Text[2] = new List<string>();

        box3Text[2] = new List<string>()
            {
                "아이템의 번호를 입력해 판매할 수 있습니다.",
                "100. 아이템구매          0. 돌아가기"
            };

        //판매창 확인 인터페이스(플레이버 텍스트, 가격 출력)
        box1Text[3] = new List<string>();

        box3Text[3] = new List<string>();
    }

    public void RenewBox3(int phase, string tempDesc)
    {
        List<string> tempList = new List<string>();
        switch (phase)
        {
            case 0:
                tempList.Add($"이 아이템은 \"`cyan,black`{tempDesc}`gray,black`\"라고 하네요. 구매하시겠습니까?");
                break;
            case 2:
                tempList.Add($"이 아이템은 \"`cyan,black`{tempDesc}`gray,black`\"라고 하네요. 판매하시겠습니까?");
                break;
        }
        tempList.Add("1. 예          2. 아니오");
        box3Text[phase + 1] = tempList;
    }

    public void AppendItemList()
    {
        switch (Player.Instance.PlayerJob)
        {
            case Player.Job.RiceMonkey:
                shopItems = ItemDB.riceMonkeyItems;
                break;
            case Player.Job.CEO:
                shopItems = ItemDB.jugallerItems;
                break;
            case Player.Job.ProGamer:
                shopItems = ItemDB.proGamerItems;
                break;
            default:
                shopItems = new Item[0];
                break;
        }

        List<string> list = new List<string>();

        list.Add("`darkgray,black`               ⠀⠀⠀⠀⠀⣴⢴⣲⢤⢶⣲⢿⡽⣯⢯⡯⣟⣷⣳⣖⣗⣷⡀⠀⠀⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠀⠀⢀⡾⣯⢿⣺⢽⢽⣺⢽⡽⡽⡽⣽⣳⣳⣳⣳⣗⣗⡿⡄⠀⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠀⠀⣞⣯⢿⡽⡾⣽⣻⢾⡽⡽⡽⣽⣳⣳⣳⣳⣳⣳⣳⢯⢿⡀⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠀⣼⣻⣞⣯⢿⡽⣽⣞⣯⢿⣽⢽⣳⣳⣳⣳⣳⣳⣳⢯⢯⢯⢿⡀⠀⠀");
        list.Add("`darkgray,black`               ⠀⢰⣯⢷⣻⣞⣯⣟⣷⢟⢮⡣⡣⡫⡳⡳⡷⣳⣳⣳⢯⢯⢯⢯⡯⣷⠀⠀⠀⠀⠀               `gray,black`지르라냥");
        list.Add("`darkgray,black`               ⠀⣿⣞⣯⢷⣻⡾⡳⡕⣕⠕⢍⠪⡘⡘⠜⢜⢜⢝⢾⢯⡯⡯⡯⣯⣟⡇⠀                         `gray,black`지르라냥");
        list.Add("`darkgray,black`               ⠘⣷⣟⡾⣯⡏⡎⡎⡌⡺⣌⣢⣱⢮⣨⣪⢼⢐⢅⢇⢗⣝⣯⡯⣗⣯⠇⠀⠀⠀⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠹⣾⣻⣿⣿⣾⣮⣮⣮⣲⣕⢵⡱⣜⣦⣧⣧⣷⣵⣷⣿⣿⢿⡽⠃⠀⠀⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠀⠈⠙⠚⠯⠯⠯⣿⣽⣽⣽⣳⣽⣺⡷⣷⢷⣿⡽⠝⠗⠛⠉⠀⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠀⠀⠀⠀⠀⠀⢰⣿⣺⣗⣟⣾⣳⡯⡯⡯⣟⣾⣳⡀⠀⡀⠀⠀⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠀⠀⠀⠀⠀⢠⣿⣳⣟⣾⣺⣺⣗⡯⡯⡯⣗⣟⡾⣧⠘⢌⢳⡀⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠀⠀⠀⠀⠀⣾⣗⣿⣺⣞⣾⣺⣗⣯⢯⢯⣗⡷⡯⣿⡆⢨⢪⡢⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠀⠀⠀⠀⢸⣷⣻⣞⣷⣳⣗⣿⣺⣞⡯⣟⣾⣻⡽⡷⣷⣕⠕⠁⠀⠀⠀");
        list.Add("`darkgray,black`               ⠀⠀⠀⠀⠀⠿⢷⣻⣗⣿⣺⣗⣿⣗⣯⣟⣗⣿⣺⣟⡯⡿⠀⠀⠀⠀⠀⠀");
        list.Add(new string('═', Constants.BOX1_WIDTH));

        for (int i = 0; i < shopItems.Length; i++)
        {
            var item = shopItems[i];
            string name = PrintUtil.AlignLeft(item.Name, 22);

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
            string _price = PlayerInventory.HasItem(item) ? "[구매완료]" : $"{item.Price} G";
            string price = PrintUtil.AlignRight($"`yellow,black`{_price}", 10);

            string desc = $"    `darkgray.blak`{item.Desc}";

            list.Add($"`darkGreen,black`[{i + 1,2}] `gray,black`{name}|{options}`gray,black`| {passiveDesc} `gray,black`|{price}");
        }

        box1Text[0] = list;
        box1Text[1] = list;


        inventoryItems = PlayerInventory.Items.ToArray();
        List<string> tempitems = new List<string>();
        PlayerInventory.DisplayForSell(ref tempitems);
        box1Text[2] = tempitems;
        box1Text[3] = tempitems;
    }
}