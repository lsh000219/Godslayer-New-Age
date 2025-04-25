using System;
using System.Collections.Generic;

internal class LOLScene : IScene
{
    public GameState SceneType => GameState.LOL;

    public GameState Run(int phase)
    {
        PrintDB.box1Data = box1Text.ContainsKey(phase) ? box1Text[phase] : new List<string>();
        PrintDB.box3Data = box3Text.ContainsKey(phase) ? box3Text[phase] : new List<string>();

        PrintUtil.CreateBox();

        // 입력에 따라 다음 상태 반환
        string input = Console.ReadLine();
        if (input == "1") return GameState.Shop;
        if (input == "0") return GameState.Pop;

        return GameState.Retry; // 다시 실행
    }

    public Dictionary<int, List<string>> box1Text = new Dictionary<int, List<string>>();
    public Dictionary<int, List<string>> box3Text = new Dictionary<int, List<string>>();

    public LOLScene()
    {
        box1Text[0] = new List<string>()
            {
                ""
            };

        box3Text[0] = new List<string>()
            {
                "하고 싶은 행동을 선택해주세요.",
                "1.      0. 돌아가기"
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