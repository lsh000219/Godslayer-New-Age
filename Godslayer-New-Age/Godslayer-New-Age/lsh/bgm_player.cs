
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

        public void Music_Start(string filename, int i)
        {
            string path = GetFullPath(filename);
            if (string.IsNullOrEmpty(path)) return;

            currentPlayer = new SoundPlayer(path);

            if (i == 0)
                currentPlayer.PlayLooping();
            else if (i == 1)
                currentPlayer.Play();
        }

        public void Music_Exit()
        {
            currentPlayer?.Stop();
        }

        public void Play_Intro_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("intro.wav", 0);
        }

        public void Play_Finally_Awake()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Finally_Awake.wav", 1);
        }

        public void Play_Job_Select_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Job_Select.wav", 0);
        }

        public void Play_Main_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Main.wav", 0);
        }

        public void Play_Victory()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Victory.wav", 1);
        }

        public void Play_Lose()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Victory.wav", 1);
        }

        public void Play_Maple_Easy_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Maple_Easy.wav", 0);
        }

        public void Play_Maple_Gang_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Maple_Gang.wav", 0);
        }

        public void Play_Maple_SinChangSup_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Maple_SinChangSup.wav", 0);
        }

        public void Play_Stock_Easy_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Stock_Easy.wav", 0);
        }
        public void Play_Stock_Doge_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Stock_Doge.wav", 0);
        }

        public void Play_Stock_Musk_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Stock_Musk.wav", 0);
        }

        public void Play_Gaming_Easy_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Gaming_Easy.wav", 0);
        }

        public void Play_Gaming_Kkoma_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Gaming_Kkoma.wav", 0);
        }

        public void Play_Gaming_Faker_Loop()
        {
            BGM_Player.Instance().Music_Exit();
            Music_Start("Gaming_Faker.wav", 0);
        }

    }

}

