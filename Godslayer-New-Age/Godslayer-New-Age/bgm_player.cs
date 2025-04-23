
using System;
using System.IO;
using System.Media;

/*
 bgm_player bgm_Player = new bgm_player();
 * 
bgm 시작(한 번) == bgm_Player.Music_Start("Gaming_Faker1.wav", loop: false);
bgm 시작(루프) == bgm_Player.Music_Start("Gaming_Faker2.wav", loop: true);

bgm 끝(루프 종료) == bgm_Player.Music_Exit()
*/

namespace Godslayer_New_Age
{
	internal class bgm_player
	{

        private SoundPlayer currentPlayer = null;

        public string GetFullPath(string filename)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "bgm", filename));

            if (!File.Exists(fullPath))
            {
                Console.WriteLine($"파일을 찾을 수 없습니다: {fullPath}");
                return string.Empty;
            }

            return fullPath;
        }

        public void Music_Start(string filename, bool loop = true)
        {
            string path = GetFullPath(filename);
            if (string.IsNullOrEmpty(path)) return;

            currentPlayer = new SoundPlayer(path);

            if (loop)
                currentPlayer.PlayLooping();
            else
                currentPlayer.PlaySync();
        }

        public void WaitForExit(string displayMessage)
        {
            Console.WriteLine(displayMessage + " 종료하려면 Enter 키를 누르세요.");
            Console.ReadLine();
            currentPlayer?.Stop();
        }

        public void Music_Exit()
        {
            currentPlayer?.Stop();
        }

        public void Intro()
        {
            Music_Start("intro.wav");
            WaitForExit("intro.wav 재생 중입니다.");
        }

        public void Victory()
        {
            Music_Start("Victory.wav");
            WaitForExit("Victory.wav 재생 중입니다.");
        }

        public void Lose()
        {
            Music_Start("Victory.wav");
            WaitForExit("Victory.wav 재생 중입니다.");
        }

        public void Maple_Easy()
        {
            Music_Start("Maple_Easy.wav");
            WaitForExit("Maple_Easy.wav 재생 중입니다.");
        }

        public void Maple_Gang()
        {
            Music_Start("Maple_Gang.wav");
            WaitForExit("Maple_Gang.wav 재생 중입니다.");
        }

        public void Maple_SinChangSup()
        {
            Music_Start("Maple_SinChangSup.wav");
            WaitForExit("Maple_SinChangSup.wav 재생 중입니다.");
        }

        public void Stock_Easy()
        {
            Music_Start("Stock_Easy.wav", true);
            WaitForExit("Stock_Easy.wav 루프 재생 중입니다.");
        }
        public void Stock_Doge()
        {
            Music_Start("Stock_Doge.wav", true);
            WaitForExit("Stock_Doge.wav 루프 재생 중입니다.");
        }

        public void Stock_Musk()
        {
            Music_Start("Stock_Musk1.wav", false);
            Music_Start("Stock_Musk2.wav", true);
            WaitForExit("Stock_Musk2.wav 루프 재생 중입니다.");
        }

        public void Gaming_Easy()
        {
            Music_Start("Gaming_Easy.wav", loop: true);
            WaitForExit("Gaming_Easy.wav 루프 재생 중입니다.");
        }

        public void Gaming_Kkoma()
        {
            Music_Start("Gaming_Kkoma.wav", loop: true);
            WaitForExit("Gaming_Kkoma.wav 루프 재생 중입니다.");
        }

        public void Gaming_Faker()
        {
            Music_Start("Gaming_Faker1.wav", loop: false);
            Music_Start("Gaming_Faker2.wav", loop: true);
            WaitForExit("Gaming_Faker2.wav 루프 재생 중입니다.");
        }

    }
}

