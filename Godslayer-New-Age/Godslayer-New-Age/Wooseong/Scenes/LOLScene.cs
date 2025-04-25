using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Godslayer_New_Age.Wooseong.Scenes
{
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
                "리그오브 레전드 게임에서 전무후무한 대기록을 세우며 '롤의 신'이라고 칭송받는 자 페이커",
                "롤의 신을 넘어 E-sports의 신이 되어 당신의 커리어를 위협한다",
                "우승이 없는 커리어를 만들지 않으려면 그를 죽여야한다"
            };

            box3Text[0] = new List<string>()
            {
                "아무 키나 눌러 던전을 나아간다"
            };
            //1
            box1Text[1] = new List<string>()
            {
              ""
            };

            box3Text[1] = new List<string>()
            {
                "원하시는 행동을 선택해 주세요",
                "1. 앞으로 나아간다   0. 마을로 돌아간다"
            };
            //2
            box1Text[2] = new List<string>()
            {
                "Stage 1",
                " ",
                "슬라임과 주황버섯이 공격해온다!"
            };

            box3Text[2] = new List<string>()
            {
                "원하시는 공격을 선택해주세요"
                //$"1.{Player.Instance.PlayerSkills[0].SkillName} 2.{Player.Instance.PlayerSkills[1].SkillName} 3.{Player.Instance.PlayerSkills[2].SkillName} 4.{Player.Instance.PlayerSkills[3].SkillName}"
            };
            //3
            box1Text[3] = new List<string>()
            {
               "Stage 5",
               
            };

            box3Text[3] = new List<string>()
            {
                "원하시는 공격을 선택해주세요"
                //$"1.{Player.Instance.PlayerSkills[0].SkillName} 2.{Player.Instance.PlayerSkills[1].SkillName} 3.{Player.Instance.PlayerSkills[2].SkillName} 4.{Player.Instance.PlayerSkills[3].SkillName}"
            };
            //4
            box1Text[4] = new List<string>()
            {
                "Stage 10",
                
            };

            box3Text[4] = new List<string>()
            {
                "원하시는 공격을 선택해주세요"
                //$"1.{Player.Instance.PlayerSkills[0].SkillName} 2.{Player.Instance.PlayerSkills[1].SkillName} 3.{Player.Instance.PlayerSkills[2].SkillName} 4.{Player.Instance.PlayerSkills[3].SkillName}"
            };
            //5
            box1Text[5] = new List<string>()
            {
                
            };

            box3Text[5] = new List<string>()
            {
                "키보드를 눌러 마을로 귀환"
            };
        }
    }
}
