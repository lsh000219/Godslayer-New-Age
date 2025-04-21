using System;
using System.Text;
using static Utils.Constants;


namespace Utils
{
    public static class PrintUtil
    {
        // TODO: Implement NewWrite method
        
        
        
        
        
        // TODO: Implement InvalidInput method
        
        
        
        
        
        // TODO: Implement AlignLeft method
        
        
        // TODO: Implement AlignCenter method
        
        
        // TODO: Implement AlignRight method
        
        
        
        
        
        
        public static void CreateBox()
        {
            Console.WriteLine();
            
            CreateBoxTop(BOX1_WIDTH, ConsoleColor.DarkGray);
            CreateBoxTop(BOX2_WIDTH, ConsoleColor.White);
            Console.WriteLine();
            
            for (int i = 0; i < UPSIDE_BOX_HEIGTH; i++)
            {
                CreateBoxSides(BOX1_WIDTH,ConsoleColor.DarkGray, "");
                string content = (i < PrintTest.test.Count) ? PrintTest.test[i] : "";
                CreateBoxSides(BOX2_WIDTH,ConsoleColor.White, content);
                Console.WriteLine();
            }

            CreateBoxBottom(BOX1_WIDTH, ConsoleColor.DarkGray);
            CreateBoxBottom(BOX2_WIDTH, ConsoleColor.White);
            Console.WriteLine();
            
            CreateBoxTop(BOX3_WIDTH, ConsoleColor.Gray);
            Console.WriteLine();
            for (int i = 0; i < DOWNSIDE_BOX_HEIGTH; i++)
            {
                CreateBoxSides(BOX3_WIDTH,ConsoleColor.Gray, "" );
                Console.WriteLine();
            }
            CreateBoxBottom(BOX3_WIDTH, ConsoleColor.Gray);

            Console.SetCursorPosition(CURSOR_POS_X, CURSOR_POS_Y);
        }
        
        static void CreateBoxTop(int width, ConsoleColor color)
        {
            Console.Write(" ");
            Console.ForegroundColor = color;
            string line = "╔" + new string('═', width - 2) + "╗";
            Console.Write(line);
            Console.ResetColor();
        }
        
        static void CreateBoxSides(int width, ConsoleColor color, string status)
        {
            Console.Write(" ");
            Console.ForegroundColor = color;
            Console.Write("║");
            Console.ResetColor();
            
            //TODO: Replace align method
            string blank = new string(' ', width - 2); 
            Console.Write(status);
            
            Console.ForegroundColor = color;
            Console.Write("║");
            Console.ResetColor();
        }
        
        static void CreateBoxBottom(int width, ConsoleColor color)
        {
            Console.Write(" ");
            Console.ForegroundColor = color;
            string line = "╚" + new string('═', width - 2) + "╝";
            Console.Write(line);
            Console.ResetColor();
        }
    }
}