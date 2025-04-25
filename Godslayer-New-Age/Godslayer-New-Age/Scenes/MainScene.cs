using Godslayer_New_Age;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class MainScene : IScene
{
    public GameState SceneType => GameState.Main;

    public GameState Run(int phase)
    {
        PrintDB.box1Data = box1Text.ContainsKey(phase) ? box1Text[phase] : new List<string>();
        PrintDB.box2Data = PrintDB.GetPlayerStatus();
        PrintDB.box3Data = box3Text.ContainsKey(phase) ? box3Text[phase] : new List<string>();

        PrintUtil.CreateBox();
        BGM_Player.Instance().Play_Main_Loop();

        // 입력에 따라 다음 상태 반환
        string input = Console.ReadLine();
        if (input == "1") return GameState.Inventory;
        if (input == "2") return GameState.Shop;
        if (input == "3") return GameState.Dungeon;
        if (input == "4") return GameState.Rest;
        if (input == "5") return GameState.Save;
        if (input == "6") return GameState.Load;
        if (input == "0") BGM_Player.Instance().Music_Exit(); return GameState.Exit;

        return GameState.Retry; // 다시 실행
    }

    public Dictionary<int, List<string>> box1Text = new Dictionary<int, List<string>>();
    public Dictionary<int, List<string>> box3Text = new Dictionary<int, List<string>>();

    public MainScene()
    {
        box1Text[0] = new List<string>()
            {
                "메인씬",
                "어쩌구저쩌구",
            };

        box3Text[0] = new List<string>()
            {
                "하고 싶은 행동을 선택해주세요.",
                "1. 인벤토리     2. 상점     3. 던전     4. 휴식     5. 저장     6. 불러오기     0. 게임종료"
            };

        box1Text[1] = new List<string>()
            {
                ""
            };

        box3Text[1] = new List<string>()
            {
                ""
            };
    }
}