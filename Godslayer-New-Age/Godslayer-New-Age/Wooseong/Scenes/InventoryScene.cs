using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Godslayer_New_Age.Wooseong.Scenes
{
    internal class InventoryScene : IScene
    {
        public GameState SceneType => GameState.Inventory;

        public GameState Run(int phase)
        {
            PrintDB.box1Data = box1Text.ContainsKey(phase) ? box1Text[phase] : new List<string>();
            PrintDB.box3Data = box3Text.ContainsKey(phase) ? box3Text[phase] : new List<string>();

            PrintUtil.CreateBox();

            // 입력에 따라 다음 상태 반환
            string input = Console.ReadLine();
            if (input == "0") return GameState.Pop;

            return GameState.Retry; // 다시 실행
        }

        public Dictionary<int, List<string>> box1Text = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> box3Text = new Dictionary<int, List<string>>();

        public InventoryScene()
        {
            box1Text[0] = new List<string>()
            {
                "인벤토리씬",
                "어쩌구저쩌구"
            };

            box3Text[0] = new List<string>()
            {
                "아이템의 번호를 입력해 착용/해제할 수 있습니다. (0. 돌아가기)",
                
            };

            box1Text[1] = new List<string>()
            {
                "장착관리"                
            };

            box3Text[1] = new List<string>()
            {
                ""
            };
        }
    }
}