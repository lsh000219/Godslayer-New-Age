using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Scenes
{
    internal class LoadScene : IScene
    {
        public GameState SceneType => GameState.Load;

        public GameState Run(int phase)
        {
            PrintDB.box1Data = box1Text.ContainsKey(phase) ? box1Text[phase] : new List<string>();
            PrintDB.box3Data = box3Text.ContainsKey(phase) ? box3Text[phase] : new List<string>();

            PrintUtil.CreateBox();

            // 입력에 따라 다음 상태 반환
            string input = Console.ReadLine();
            if (input == "1") return GameState.Main;
            if (input == "2") return GameState.Main;
            if (input == "3") return GameState.Main;
            if (input == "0") return GameState.Pop;

            return GameState.Retry; // 다시 실행
        }

        public Dictionary<int, List<string>> box1Text = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> box3Text = new Dictionary<int, List<string>>();

        public LoadScene()
        {
            box1Text[0] = new List<string>()
            {
                "",
                "",
                "",
                "⠀    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡠⡤⡲⡲⡲⡲⡲⡲⢦⢤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                "⠀    ⠀⠀⠀⠀⠀⣀⢄⡄⡄⡄⡄⡄⡄⡄⣄⡠⣀⢄⡠⣀⢄⡠⣀⢄⡠⣀⢄⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢔⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢻⣢⢄⠀⠀⠀⠀⠀⠀⠀⠀⡠⠄⠤⠄⡄⣀⣀⣀⢀⢀⢀⢀⢀⠀⠀⠀⠀⠀⢀⢀⢀⢀⢀⣀⣀⡀⠀⠀⠀   ",
                "⠀    ⠀⠀⠀⠀⠀⡮⣳⢵⢹⢜⢕⡝⣜⢮⢲⢱⢣⢳⢹⢸⢪⢺⢸⡱⡹⣸⢱⢽⠀⠀⠀⠀⠀⠀⠀⡠⡣⡣⡣⡣⡣⡣⡣⡣⡣⡣⡣⡣⡣⡣⡣⡣⡳⡫⣗⡄⠀⠀⠀⠀⠀⢰⠁⡐⢀⠡⠀⠂⠄⢐⠀⠅⠡⠈⠄⠡⠉⠌⠡⠡⠑⠠⢁⠡⢁⢰⠬⡹⡂⠀⠀",
                "⠀    ⠀⠀⠀⠀⢐⢝⢮⡪⡳⠓⠓⠓⠑⠓⠓⠙⠊⠓⠙⠊⠓⠓⠓⠑⡏⣎⢞⢾⢝⡆⠀⠀⠀⣠⢪⢪⢪⢪⠪⡪⡪⡪⡪⡪⡪⡪⡪⡪⡪⡪⡪⡪⡪⡪⡳⣝⢶⡄⠀⠀⠀⢸⠠⢐⢀⢂⠡⢈⢐⢀⠂⠡⠈⠄⠡⠈⠄⠡⠈⠄⠡⠈⠄⢂⠐⢜⢝⡎⡇⠀⠀",
                "⠀    ⠀⠀⠀⠀⢸⢕⣗⢝⡎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣏⢎⢮⢯⣳⠃⠀⠀⠈⡖⡕⡕⡕⠕⠱⠑⠕⠱⠑⠕⠕⠕⠕⠕⠕⠕⠕⠕⢕⢕⢕⢜⢵⣻⠀⠀⠀⠀⠣⢣⠲⡰⠱⡢⠲⡰⡡⠥⠥⠥⠥⡡⡡⡅⡅⣅⡅⢅⢕⠄⠅⣇⢗⡕⡇⠀⠀",
                "⠀    ⠀⠀⠀⠀⡪⡳⡕⡧⡇" + PrintUtil.AlignLeft($"레벨변수자리",14) + "⢀⢗⢕⣳⡳⣵⠁⠀⠀⢈⢮⢪⠪⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢸⢨⢪⢺⣺⠀⠀⠀⠀⠀⢸⠐⡈⠈⠈⠈⠐⠈⠈⠈⠈⠈⠂⠑⠐⠑⠐⠨⠘⠌⠪⠩⡊⡣⢪⠃⠀⠀",
                "⠀    ⠀⠀⠀⠀⡯⣺⢕⣳⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢱⢣⡳⣝⠾⠀⠀⠀⢀⢇⢇⢇⡇" + PrintUtil.AlignCenter($"이름변수자리",14) + "⠀⢸⢸⢸⢨⡳⣵⠀⠀⠀⠀⠀⠸⢀⠐⠀" + PrintUtil.AlignLeft($"날짜변수자리",14) + "⠀⠀⠀⠐⠠⠈⠼⠀⠀⠀",
                "⠀    ⠀⠀⠀⢠⢫⢮⡣⣳⠀" + PrintUtil.AlignRight($"이름변수자리",14) + "⢸⢱⢣⣻⡪⡇⠀⠀⠀⠠⡣⡣⡣⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢸⠸⡸⡺⣺⠀⠀⠀⠀⠀⡣⠀⢂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠂⠡⡃⠀⠀⠀",
                "⠀    ⠀⠀⠀⢸⢕⡗⣝⡜⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⣎⢧⡳⣝⡇⠀⠀⠀⢐⢕⢕⢕⠇" + PrintUtil.AlignLeft($"레벨변수자리",14) + "⠀⢸⢸⢸⢘⢮⣫⠀⠀⠀⠀⠀⡇⠈⠄⠀" + PrintUtil.AlignLeft($"레벨변수자리",14) + "⠀⠀⠀⠂⠄⢡⠃⠀⠀⠀",
                "    ⠀⠀⠀⠀⣜⢵⢝⡲⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⡮⣪⢾⢵⠁⠀⠀⠀⢐⡕⡕⡕⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢸⠸⡸⣱⢽⠀⠀⠀⠀⢨⠂⡁⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠐⡈⢸⠀⠀⠀⠀",
                "    ⠀⠀⠀⠀⣗⢵⢳⢭⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⢣⡳⣕⡟⣞⠀⠀⠀⠀⠠⡣⡣⡪⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢸⢸⢸⣪⣻⠀⠀⠀⠀⡘⠠⠐⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠐⡌⠀⠀⠀⠀",
                "    ⠀⠀⠀⢠⡳⣹⢕⢽⠀" + PrintUtil.AlignRight($"날짜변수자리",14) + "⢸⢱⡱⡵⣝⢞⠀⠀⠀⠀⢈⡇⡇⡇⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢸⢸⢰⢕⢷⠀⠀⠀⠀⡎⠀⠅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠈⠄⡇⠀⠀⠀⠀",
                "    ⠀⠀⠀⢸⡪⣳⢹⡌              ⠀⡪⣣⢳⢽⣪⠇⠀⠀⠀⠀⠠⡇⡇⡇⡇⠀" + PrintUtil.AlignCenter($"날짜변수자리",14) + "⢸⢸⢘⢬⢫⢯⠀⠀⠀⠠⡡⠈⠄⠀⠀" + PrintUtil.AlignRight($"이름변수자리",14) + "⠀⠀⢂⠐⠸⡀⠀⠀⠀⠀",
                "    ⠀⠀⠀⡼⣸⡕⣕⢧⢳⢪⡲⡕⡮⡲⡕⣎⢖⡕⡮⡲⡪⣲⢱⢝⢜⢎⣗⢵⠇⠀⠀⠀⠀⢐⢇⢇⢇⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢸⢸⢨⡳⣻⠀⠀⠀⢠⠁⡂⡁⢀⠀⡀⢀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⡂⢱⠀⠀⠀⠀⠀",
                "    ⠀⠀⠀⡯⣪⡺⣜⣜⣎⢧⣣⡳⣱⡣⣳⡱⣕⣕⢇⣏⢞⣜⢎⡮⣳⡹⣎⢯⠂⠀⠀⠀⠀⠐⡇⡇⡇⡭⠭⠭⠭⠭⠭⠭⠭⠭⠭⠭⠭⢭⢩⠭⡍⡇⡇⡇⡇⡯⣺⣀⡀⡰⠊⠒⢒⠐⡒⠢⠤⠴⠬⠤⠬⠬⠌⠬⠬⠤⠥⠬⠤⠥⠢⠥⠥⡬⡺⡰⡄⠀⠀⠀",
                "    ⠀⠀⠀⡯⡎⠍⠌⠌⢌⠅⡅⢍⠅⡍⢕⢙⢚⢚⢛⢚⢓⢓⠫⡚⢕⠫⡺⡽⠀⠀⠀⡴⡪⢫⢓⡓⡓⣓⠫⡫⡙⡎⡏⠧⠯⡭⠽⢼⢹⢬⠣⢧⠣⡇⢧⠣⡇⡯⡳⣕⡇⡇⢈⠈⠄⢂⠐⠐⢐⠀⠅⢂⠨⠀⠅⠨⠀⠅⠨⠀⠅⠨⢈⠨⢐⠵⡕⡕⡇⠀⠀⠀",
                "    ⠀⠀⠀⢫⢞⡬⡬⡬⡤⢥⢌⢆⢕⢌⣂⢢⡑⡄⡕⣌⢢⣑⢅⢇⡕⣝⢞⡝⠀⠀⠀⡧⡣⡣⡣⡣⡣⡣⡣⡣⡣⡣⠭⡍⡇⡇⡏⡎⡖⡕⡝⡜⡜⡜⡜⡜⡜⡮⣫⢞⡎⢇⣂⢢⢡⢐⠌⡌⢄⢢⠡⣐⢠⢡⠨⠠⠡⡈⢄⠡⡈⡐⡀⡂⢘⢕⢕⢕⠇⠀⠀⠀",
                "    ⠀⠀⠀⠀⠉⠊⠑⠉⠊⠉⠊⠉⠑⠙⠘⠑⠋⠋⠛⠊⠓⠓⠋⠓⠙⠚⠙⠀⠀⠀⠀⠳⠵⠵⠵⠵⠵⠵⠕⠵⠵⠭⡣⠧⠧⠧⠧⠧⠧⠧⠧⡧⢧⢧⣳⣝⣜⠽⠚⠁⠀⠀⠀⠁⠁⠁⠁⠀⠁⠀⠁⠈⠀⠁⠉⠉⠉⠈⠘⠈⠒⠊⠒⠪⠆⢗⠵⠉⠀⠀⠀⠀",
                "",
                "",
                "",
                "",
            };

            box3Text[0] = new List<string>()
            {
                "데이터를 불러올 슬롯을 선택해주세요(1~3) (0. 돌아가기)"
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
}