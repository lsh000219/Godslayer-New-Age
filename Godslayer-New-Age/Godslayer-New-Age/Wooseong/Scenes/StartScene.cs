using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Core;
using Managers;

namespace Scenes
{
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
                "스토리",
                "  어쩌구",
                "    저쩌구",
                "",
                "보스는 `Yellow,red`신창섭`null,black`, `white,darkblue`일론머스크`null,black`, `red,white`페이커`null,black`",
            };

            box3Text[0] = new List<string>()
            {
                "하고 싶은 행동을 고르시오.",
                "1. 새로시작     2. 이어하기     0. 게임종료"
            };

            box1Text[1] = new List<string>()
            {
                ""
            };

            box3Text[1] = new List<string>()
            {
                ""
            };

            box1Text[2] = new List<string>()
            {
                ""
            };

            box3Text[2] = new List<string>()
            {
                ""
            };
        }
    }
}
