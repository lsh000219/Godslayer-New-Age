
using System;
using System.IO;
using System.Media;
using Godslayer_New_Age.Kiahn;

/*
bgm 시작 == BGM_Player.Instance().Play_Victory();

bgm 끝(루프 종료) == BGM_Player.Instance().Music_Exit();
*/

namespace Godslayer_New_Age
{
	internal class BGM_Player
	{
        private static BGM_Player bgm_player;
        public static BGM_Player Instance()
        {
            if (bgm_player == null)
            {
                bgm_player = new BGM_Player();
            }
            return bgm_player;
        }

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

        public void Music_Exit()
        {
            currentPlayer?.Stop();
        }

        public void Play_Intro_Loop()
        {
            Music_Start("intro.wav", true);
        }

        public void Play_Victory()
        {
            Music_Start("Victory.wav", false);
        }

        public void Play_Lose()
        {
            Music_Start("Victory.wav", false);
        }

        public void Play_Maple_Easy_Loop()
        {
            Music_Start("Maple_Easy.wav");
        }

        public void Play_Maple_Gang_Loop()
        {
            Music_Start("Maple_Gang.wav");
        }

        public void Play_Maple_SinChangSup_Loop()
        {
            Music_Start("Maple_SinChangSup.wav");
        }

        public void Play_Stock_Easy_Loop()
        {
            Music_Start("Stock_Easy.wav", true);
        }
        public void Play_Stock_Doge_Loop()
        {
            Music_Start("Stock_Doge.wav", true);
        }

        public void Play_Stock_Musk_Loop()
        {
            Music_Start("Stock_Musk1.wav", false);
            Music_Start("Stock_Musk2.wav", true);
        }

        public void Play_Gaming_Easy_Loop()
        {
            Music_Start("Gaming_Easy.wav", loop: true);
        }

        public void Play_Gaming_Kkoma_Loop()
        {
            Music_Start("Gaming_Kkoma.wav", loop: true);
        }

        public void Play_Gaming_Faker_Loop()
        {
            Music_Start("Gaming_Faker1.wav", loop: false);
            Music_Start("Gaming_Faker2.wav", loop: true);
        }

    }
}

