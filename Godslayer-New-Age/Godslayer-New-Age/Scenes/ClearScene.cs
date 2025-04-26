using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godslayer_New_Age.Scenes
{
    internal class ClearScene : IScene
    {
        public GameState SceneType => GameState.Clear;

        public GameState Run(int phase)
        {
            PrintDB.box1Data = box1Text.ContainsKey(phase) ? box1Text[phase] : new List<string>();
            PrintDB.box2Data = PrintDB.GetPlayerStatus();
            PrintDB.box3Data = box3Text.ContainsKey(phase) ? box3Text[phase] : new List<string>();

            PrintUtil.CreateBox();

            // 입력에 따라 다음 상태 반환
            string input = Console.ReadLine();
            if (input == "q")
            {
                Player.Instance.HP -= 50;
                Player.Instance.Gold += 500;
            }
            if (input == "1")
            {
                Player.Instance.HP = Player.Instance.MaxHP;
                Player.Instance.Gold -= 500;
            }
            if (input == "0") return GameState.Pop;

            return GameState.Retry; // 다시 실행
        }

        public Dictionary<int, List<string>> box1Text = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> box3Text = new Dictionary<int, List<string>>();

        public ClearScene()
        {
            box1Text[0] = new List<string>()
            {
                
            };

            box3Text[0] = new List<string>()
            {
                "하고 싶은 행동을 선택해주세요.",
                "1. 회복하기(500G)          0. 돌아가기"
            };
        }
    }
}