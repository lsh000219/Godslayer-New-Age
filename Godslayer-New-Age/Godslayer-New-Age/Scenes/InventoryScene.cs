using System;
using System.Collections.Generic;

internal class InventoryScene : IScene
{
    private Item priorItem = null;
    private Item newItem = null;
    private int selectedIndex = -1;
    private List<string> text = new List<string>();
    List<Item> inventoryItems = new List<Item>();


    public GameState SceneType => GameState.Inventory;

    public GameState Run(int phase)
    {
        AppendItemList();
        SetBox3Text(priorItem, newItem);
        PrintDB.box2Data = PrintDB.GetPlayerStatus();
        PrintDB.box3Data = text;

        PrintUtil.CreateBox();

        // 입력에 따라 다음 상태 반환
        string input = Console.ReadLine();
        if (input == "0") return GameState.Pop;

        if (int.TryParse(input, out int index))
        {
            if (index >= 1 && index <= PlayerInventory.Items.Count)
            {
                newItem = PlayerInventory.Items[index - 1];
                ItemType type = newItem.Type;

                priorItem = PlayerInventory.GetEquipped(type);

                SetBox3Text(priorItem, newItem);
                PlayerInventory.Equip(priorItem, newItem);

                PrintUtil.CreateBox();
                Console.ReadKey();

                priorItem = null;
                newItem = null;

                return GameState.Retry;
            }
        }

        return GameState.Retry; // 다시 실행
    }

    public void SetBox3Text(Item _priorItem, Item _newItem)
    {
        text.Clear();

        if (_priorItem == null && _newItem == null)
        {
            text.Add($"아이템의 번호를 입력해 착용/해제할 수 있습니다. (0. 돌아가기)");
            return;
        }
        if (_priorItem != null && _newItem != null && _priorItem.Name == _newItem.Name)
        {
            text.Add($"`cyan,black`{_newItem.Name}`gray,black`을(를) 해제했습니다.");
            return;
        }
        if (_priorItem != null)
        {
            text.Add($"`cyan,black`{_priorItem.Name}`gray,black`을(를) 해제했습니다.");
        }
        if (_newItem != null)
        {
            text.Add($"`cyan,black`{_newItem.Name}`gray,black`을(를) 착용했습니다.");
        }

    }

    public void AppendItemList()
    {
        List<string> tempitems = new List<string>();
        PlayerInventory.Display(ref tempitems);
        PrintDB.box1Data = tempitems;
    }
}