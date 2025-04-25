using System;
using System.Text;


public static class PrintUtil
{
    //NewWrite method (font, background color changer)
    public static void NewWrite(string text)
    {
        ConsoleColor? fgColor = null;
        ConsoleColor? bgColor = null;
        int index = 0;

        while (index < text.Length)
        {
            int backtickStart = text.IndexOf('`', index);

            // 백틱 없으면 남은 텍스트 출력하고 끝
            if (backtickStart == -1)
            {
                ApplyColors(fgColor, bgColor);
                Console.Write(text.Substring(index));
                break;
            }

            // 백틱 전까지 출력
            ApplyColors(fgColor, bgColor);
            Console.Write(text.Substring(index, backtickStart - index));
            index = backtickStart + 1;

            // 색상 정보 추출
            int backtickEnd = text.IndexOf('`', index);
            if (backtickEnd == -1) break;

            string[] colorInfo = text.Substring(index, backtickEnd - index).Split(',');
            fgColor = TryParseColor(colorInfo[0]);
            bgColor = TryParseColor(colorInfo[1]);

            index = backtickEnd + 1;
        }

        Console.ResetColor();
    }
    private static ConsoleColor? TryParseColor(string text)
    {
        if (string.IsNullOrWhiteSpace(text) || text.ToLower() == "null")
            return null;

        return Enum.TryParse<ConsoleColor>(text, true, out var colorObj)
            ? (ConsoleColor?)colorObj
            : null;
    }
    private static void ApplyColors(ConsoleColor? fg, ConsoleColor? bg)
    {
        if (fg.HasValue) Console.ForegroundColor = fg.Value;
        if (bg.HasValue) Console.BackgroundColor = bg.Value;
    }


    // Align methods
    public static string AlignLeft(string text, int width)
    {
        int textWidth = GetStringLength(text);
        int padding = Math.Max(0, width - textWidth);
        return text + new string(' ', padding);
    }
    public static string AlignRight(string text, int width)
    {
        int textWidth = GetStringLength(text);
        int padding = Math.Max(0, width - textWidth);
        return new string(' ', padding) + text;
    }
    public static string AlignCenter(string text, int width)
    {
        int textWidth = GetStringLength(text);
        int padding = Math.Max(0, width - textWidth);
        int leftPadding = padding / 2;
        int rightPadding = padding - leftPadding;
        return new string(' ', leftPadding) + text + new string(' ', rightPadding);
    }
    private static int GetStringLength(string text)
    {
        int width = 0;
        bool insideBacktick = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '`')
            {
                insideBacktick = !insideBacktick;
                continue;
            }

            if (insideBacktick) continue;

            width += (text[i] >= 0xAC00 && text[i] <= 0xD7A3) ? 2 : 1;
        }

        return width;
    }


    //CreateBox methods
    public static void CreateBox()
    {
        Console.Clear();
        Console.WriteLine();

        CreateBoxTop(Constants.BOX1_WIDTH, ConsoleColor.DarkGray);
        CreateBoxTop(Constants.BOX2_WIDTH, ConsoleColor.White);
        Console.WriteLine();

        for (int i = 0; i < Constants.UPSIDE_BOX_HEIGTH; i++)
        {
            string box1Content = (i < PrintDB.box1Data.Count) ?
                PrintUtil.AlignLeft(PrintDB.box1Data[i], Constants.BOX1_WIDTH) :
                PrintUtil.AlignLeft("", Constants.BOX1_WIDTH);
            CreateBoxSides(Constants.BOX1_WIDTH, ConsoleColor.DarkGray, box1Content);
            string box2Content = (i < PrintDB.box2Data.Count) ?
                PrintUtil.AlignLeft(PrintDB.box2Data[i], Constants.BOX2_WIDTH) :
                PrintUtil.AlignLeft("", Constants.BOX2_WIDTH);
            CreateBoxSides(Constants.BOX2_WIDTH, ConsoleColor.White, box2Content);
            Console.WriteLine();
        }

        CreateBoxBottom(Constants.BOX1_WIDTH, ConsoleColor.DarkGray);
        CreateBoxBottom(Constants.BOX2_WIDTH, ConsoleColor.White);
        Console.WriteLine();

        CreateBoxTop(Constants.BOX3_WIDTH, ConsoleColor.Gray);
        Console.WriteLine();
        for (int i = 0; i < Constants.DOWNSIDE_BOX_HEIGTH - 1; i++)
        {
            string content = (i < PrintDB.box3Data.Count) ?
                PrintUtil.AlignLeft(PrintDB.box3Data[i], Constants.BOX3_WIDTH) :
                PrintUtil.AlignLeft("", Constants.BOX3_WIDTH);
            CreateBoxSides(Constants.BOX3_WIDTH, ConsoleColor.Gray, content);
            Console.WriteLine();
        }
        CreateBoxSides(Constants.BOX3_WIDTH, ConsoleColor.Gray, PrintUtil.AlignLeft(">> ", Constants.BOX3_WIDTH));
        Console.WriteLine();
        CreateBoxBottom(Constants.BOX3_WIDTH, ConsoleColor.Gray);

        Console.SetCursorPosition(Constants.CURSOR_POS_X, Constants.CURSOR_POS_Y);
    }
    static void CreateBoxTop(int width, ConsoleColor color)
    {
        Console.Write(" ");
        Console.ForegroundColor = color;
        string line = "╔" + new string('═', width) + "╗";
        Console.Write(line);
        Console.ResetColor();
    }
    static void CreateBoxSides(int width, ConsoleColor color, string text)
    {
        Console.Write(" ");
        Console.ForegroundColor = color;
        Console.Write("║");
        Console.ResetColor();

        //TODO: Replace align method
        string blank = new string(' ', width);
        NewWrite(text);

        Console.ForegroundColor = color;
        Console.Write("║");
        Console.ResetColor();
    }
    static void CreateBoxBottom(int width, ConsoleColor color)
    {
        Console.Write(" ");
        Console.ForegroundColor = color;
        string line = "╚" + new string('═', width) + "╝";
        Console.Write(line);
        Console.ResetColor();
    }
}