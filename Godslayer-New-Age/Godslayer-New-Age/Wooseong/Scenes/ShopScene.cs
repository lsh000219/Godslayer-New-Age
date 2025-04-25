using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Core;
using Data;
using System.ComponentModel;

namespace Scenes
{
    public class ShopScene : IScene
    {
        public GameState SceneType => GameState.Shop;

        public GameState Run(int phase)
        {
            PrintDB.box1Data = box1Text.ContainsKey(phase) ? box1Text[phase] : new List<string>();
            PrintDB.box3Data = box3Text.ContainsKey(phase) ? box3Text[phase] : new List<string>();
            PrintUtil.CreateBox();

            Console.Write(">> ");
            string input = Console.ReadLine();
            int.TryParse(input, out int numInput);

            // 임시 아이템 배열
            string[] dummyItems = { "회복 포션", "화염의 검", "방어의 망토" };

            switch (phase)
            {
                case 0: // 구매 페이즈
                    if (numInput == 0) return GameState.Pop;
                    if (numInput >= 1 && numInput <= dummyItems.Length)
                    {
                        return Run(1); // 구매 확정 페이즈로 이동
                    }
                    if (numInput == 100) return Run(2); // 판매 페이즈로 이동
                    break;

                case 1: // 구매 확정 페이즈
                    if (numInput == 1)
                    {
                        // 구매 처리 로직
                        return GameState.Retry; // 다시 상점 진입
                    }
                    if (numInput == 0) return Run(0); // 다시 구매 목록으로
                    break;

                case 2: // 판매 페이즈
                    if (numInput == 0) return GameState.Pop;
                    if (numInput >= 1 && numInput <= dummyItems.Length)
                    {
                        return Run(3); // 판매 확정 페이즈로 이동
                    }
                    if (numInput == 100) return Run(0); // 구매 페이즈로 이동
                    break;

                case 3: // 판매 확정 페이즈
                    if (numInput == 1)
                    {
                        //TODO: 판매 처리 로직
                        return GameState.Retry;
                    }
                    if (numInput == 0) return Run(2); // 다시 판매 목록으로
                    break;
            }

            return GameState.Retry;
        }

        public Dictionary<int, List<string>> box1Text = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> box3Text = new Dictionary<int, List<string>>();

        
        public ShopScene()
        {

            //구매창 기본 인터페이스
            box1Text[0] = new List<string>()
            {
                ""
            };

            box3Text[0] = new List<string>()
            {
                "아이템의 번호를 입력해 구매할 수 있습니다. (0. 돌아가기)"
            };

            //구매창 확인 인터페이스(플레이버 텍스트, 가격 출력)
            box1Text[1] = new List<string>()
            {
                ""
            };

            box3Text[1] = new List<string>()
            {
                ""
            };

            //판매창 기본 인터페이스
            box1Text[2] = new List<string>()
            {
                ""
            };

            box3Text[2] = new List<string>()
            {
                "아이템의 번호를 입력해 판매할 수 있습니다. (0. 돌아가기)"
            };

            //판매창 확인 인터페이스(플레이버 텍스트, 가격 출력)
            box1Text[3] = new List<string>()
            {
                ""
            };

            box3Text[3] = new List<string>()
            {
                ""
            };
        }
    }
}
