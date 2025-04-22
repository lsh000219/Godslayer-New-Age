using System;
using System.Text;
using System.Collections.Generic;
using static Utils.Constants;

namespace Utils
{
    public static class PrintDB
    {
        public static List<string> box1Data = new List<string>();
        /* How to Use
         * using Utils;
         * 
         * List<string> aaa = new List<string> { "`red,blue`a1", "a2", "`null,green`a3" }; << maximum 25lines
         * PrintDB.box1Data = aaa;
         *
         * element) "`red,blue`a1" << print "a1", font color: red, background color: blue
         * ` << backtick
         */
        
        public static List<string> box2Data = new List<string>
        {
            PrintUtil.AlignLeft($" `red,white`aaa `blue,gray`(쌀숭이)`null,black`", BOX2_WIDTH),
            PrintUtil.AlignLeft($" Lv 01 (50/100)", BOX2_WIDTH),
            GaugeViewer(50,100,"yellow"),   //view exp percentage
            PrintUtil.AlignCenter(new string('-', BOX2_WIDTH - 2), BOX2_WIDTH),
            "",
            PrintUtil.AlignLeft($" HP 70 / 100", BOX2_WIDTH),
            GaugeViewer(70,100,"red"),      //view hp percentage
            PrintUtil.AlignLeft($" MP 90 / 100", BOX2_WIDTH),
            GaugeViewer(70,100,"blue"),     //view mp percentage
            "",
            PrintUtil.AlignCenter(new string('-', BOX2_WIDTH - 2), BOX2_WIDTH),
            PrintUtil.AlignLeft($" ATK {null} {null}", BOX2_WIDTH),
            PrintUtil.AlignLeft($" DEF {null} {null}", BOX2_WIDTH),
            PrintUtil.AlignLeft($" CRT {null} {null}", BOX2_WIDTH),
            PrintUtil.AlignLeft($" EVA {null} {null}", BOX2_WIDTH),
            PrintUtil.AlignLeft($" SPD {null} {null}", BOX2_WIDTH),
            "",
            PrintUtil.AlignCenter(new string('-', BOX2_WIDTH - 2), BOX2_WIDTH),
            PrintUtil.AlignLeft(" [장비]", BOX2_WIDTH),
            PrintUtil.AlignLeft($" {null}", BOX2_WIDTH),
            PrintUtil.AlignLeft($" {null}", BOX2_WIDTH),
            PrintUtil.AlignLeft($" {null}", BOX2_WIDTH),
            "",
            PrintUtil.AlignCenter(new string('-', BOX2_WIDTH - 2), BOX2_WIDTH),
            " Gold) " + PrintUtil.AlignRight($"{null} G", BOX2_WIDTH-8)
        };
        
        //2 lines
        public static List<string> box3Data = new List<string>
        {
            PrintUtil.AlignLeft("하고 싶은 행동을 고르시오.", BOX3_WIDTH),
            PrintUtil.AlignLeft("1. 자기     4. 저장     5. 불러오기     0. 게임종료", BOX3_WIDTH),
        };

        
        private static string GaugeViewer(int nowStat, int maxStat, string color)
        {
            int gaugeLength = (int)Math.Floor((double)nowStat / maxStat * (BOX2_WIDTH - 2));
            int emptyLength = (BOX2_WIDTH - 2) - gaugeLength;

            string gauge = new string(' ', gaugeLength);
            string empty = new string(' ', emptyLength);

            return $" `null,{color}`{gauge}`null,gray`{empty}`null,black` ";
        }
    }
}