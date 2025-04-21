
using System;
using System.IO;
using System.Media;


namespace Godslayer_New_Age
{
	internal class bgm_player
	{

		public void intro()
		{
			string baseDir = AppDomain.CurrentDomain.BaseDirectory;

			string bgmPath = Path.Combine(baseDir, "..", "..", "bgm", "intro.wav");

			bgmPath = Path.GetFullPath(bgmPath);

			if (!File.Exists(bgmPath))
			{
				Console.WriteLine("파일을 찾을 수 없습니다: " + bgmPath);
				return;
			}

			SoundPlayer player = new SoundPlayer(bgmPath);
			player.PlayLooping();

			Console.WriteLine("intro.wav 재생 중입니다. 종료하려면 Enter 키를 누르세요.");
			Console.ReadLine();

			player.Stop();
		}

		public void Battle_SinChangSup()
		{
			string baseDir = AppDomain.CurrentDomain.BaseDirectory;

			string bgmPath = Path.Combine(baseDir, "..", "..", "bgm", "Battle_SinChangSup.wav");

			bgmPath = Path.GetFullPath(bgmPath);

			if (!File.Exists(bgmPath))
			{
				Console.WriteLine("파일을 찾을 수 없습니다: " + bgmPath);
				return;
			}

			SoundPlayer player = new SoundPlayer(bgmPath);
			player.PlayLooping();

			Console.WriteLine("intro.wav 재생 중입니다. 종료하려면 Enter 키를 누르세요.");
			Console.ReadLine();

			player.Stop();
		}

		public void Battle_Musk()
		{
			string baseDir = AppDomain.CurrentDomain.BaseDirectory;

			string bgmPath = Path.Combine(baseDir, "..", "..", "bgm", "Battle_Musk.wav");

			bgmPath = Path.GetFullPath(bgmPath);

			SoundPlayer player = new SoundPlayer(bgmPath);
			player.PlayLooping();

			Console.WriteLine("intro.wav 재생 중입니다. 종료하려면 Enter 키를 누르세요.");
			Console.ReadLine();

			player.Stop();
		}

		public void Battle_Faker()
		{
			string baseDir = AppDomain.CurrentDomain.BaseDirectory;

			string bgmPath1 = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "bgm", "Battle_Faker1.wav"));
			string bgmPath2 = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "bgm", "Battle_Faker2.wav"));

			SoundPlayer player = new SoundPlayer(bgmPath1);
			player.PlaySync();

			player = new SoundPlayer(bgmPath2);
			player.PlayLooping();

			Console.WriteLine("Battle_Faker2.wav 루프 재생 중입니다. 종료하려면 Enter 키를 누르세요.");
			Console.ReadLine();

			player.Stop();
		}

	}
}

