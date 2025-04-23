
using System;
using System.IO;
using System.Media;


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
            Music_Start("Battle_SinChangSup.wav");
            WaitForExit("Battle_SinChangSup.wav 재생 중입니다.");
        }

        public void Battle_Musk()
        {
            Music_Start("Battle_Musk1.wav", false);
            Music_Start("Battle_Musk2.wav", true);
            WaitForExit("Battle_Musk2.wav 루프 재생 중입니다.");
        }

        public void Battle_Faker()
        {
            Music_Start("Battle_Faker1.wav", loop: false);
            Music_Start("Battle_Faker2.wav", loop: true);
            WaitForExit("Battle_Faker2.wav 루프 재생 중입니다.");
        }

    }
}

