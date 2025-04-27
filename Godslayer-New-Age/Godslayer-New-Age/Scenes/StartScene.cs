using System;
using System.Collections.Generic;

internal class StartScene : IScene
{
    public GameState SceneType => GameState.Start;

    public GameState Run(int phase)
    {
        PrintDB.box1Data = box1Text.ContainsKey(phase) ? box1Text[phase] : new List<string>();
        PrintDB.box3Data = box3Text.ContainsKey(phase) ? box3Text[phase] : new List<string>();

        PrintUtil.CreateBox();

        // 입력에 따라 다음 상태 반환
        string input = Console.ReadLine();
        if (input == "1") return GameState.CreateCharacter;
        if (input == "2") return GameState.Load;
        if (input == "0") return GameState.Exit;

        return GameState.Retry; // 다시 실행
    }

    public Dictionary<int, List<string>> box1Text = new Dictionary<int, List<string>>();
    public Dictionary<int, List<string>> box3Text = new Dictionary<int, List<string>>();

    public StartScene()
    {
        box1Text[0] = new List<string>()
        {
            "",
            "신....종교의 대상으로 초인간적, 초자연적 위력을 가지고 인간에게 화와 복을 내린다고 믿어지는 존재",
            "주로 인간보다 우월하여 전지전능에 가깝거나 그러한 힘을 지닌 존재를 의미한다.",
            "",
            "",
            "이런 신을 죽인 자들이 있었으니... 그들이 `red,black`God Slayer(신살자)`gray,black`이다.",
            "처음으로 불을 피우는 법을 밝혀내 불이라는 신을 죽인 고대의 누군가,",
            "가장 유명한 신(예수)을 죽인 병사 롱기누스, ",
            "그리고 가장 현대의 신살자이며 현대까지 남아있는 모든 신을 죽인 철학자 니케",
            "",
            "",
            "이로써 완전한 인간의 시대를 맞이한 인류는 우주 여행, AI와 같은 고도의 과학 발전을 이룩한다",
            "하지만 신은 현대에도 다시 태어나는 법",
            "그 신들은  `Yellow,red`신창섭`null,black`, `white,darkblue`일론머스크`null,black`, `red,white`페이커`null,black`",
            "",
            "",
            "",
            "",
            "그리고 당신은 현대의 신들을 죽일 새로운 시대의 `red,black`God Slayer(신살자)`gray,black`이다...",


        };

        box3Text[0] = new List<string>()
            {
                "하고 싶은 행동을 선택해주세요.",
                "1. 새로시작     2. 이어하기     0. 게임종료"
            };
    }
}