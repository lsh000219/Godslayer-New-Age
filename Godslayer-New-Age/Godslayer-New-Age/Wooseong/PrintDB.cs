using System;
using System.Text;
using System.Collections.Generic;
using static Utils.Constants;
using Godslayer_New_Age.LJM;
using Godslayer_New_Age.Kiahn;

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

        // TODO: introScene 비활성화
        public static List<string> box2Data = new List<string>();

        //2 lines
        public static List<string> box3Data = new List<string>();


        public static List<string> playerStatus = new List<string>
        {
            $" {Player.Instance.Name} ({Player.Instance.PlayerJob})",
            $" Lv {Player.Instance.Level:D2} ({Player.Instance.EXP}/{Player.Instance.RequiredExp})",
            GaugeViewer(Player.Instance.EXP, Player.Instance.RequiredExp, "yellow"),   //view exp percentage
            PrintUtil.AlignCenter(new string('-', BOX2_WIDTH - 2), BOX2_WIDTH),
            "",
            $" HP {Player.Instance.HP} / {Player.Instance.MaxHP}",
            GaugeViewer(Player.Instance.HP, Player.Instance.MaxHP, "red"),      //view hp percentage
            $" MP {Player.Instance.MP} / {Player.Instance.MaxMP}",
            GaugeViewer(Player.Instance.MP, Player.Instance.MaxMP, "blue"),     //view mp percentage
            "",
            PrintUtil.AlignCenter(new string('-', BOX2_WIDTH - 2), BOX2_WIDTH),
            $" ATK {Player.Instance.Damage} {null}",
            $" DEF {Player.Instance.Defence} {null}",
            $" CRT {Player.Instance.CritRate} {null}",
            $" EVA {Player.Instance.DodgeRate} {null}",
            $" SPD {Player.Instance.Speed} {null}",
            "",
            PrintUtil.AlignCenter(new string('-', BOX2_WIDTH - 2), BOX2_WIDTH),
            " [장비]",
            $" {null}",
            $" {null}",
            $" {null}",
            "",
            PrintUtil.AlignCenter(new string('-', BOX2_WIDTH - 2), BOX2_WIDTH),
            " Gold) " + PrintUtil.AlignRight($"{Player.Instance.Gold} G", BOX2_WIDTH-8)
        };

        private static string GaugeViewer(float nowStat, float maxStat, string color)
        {
            int gaugeLength = (int)Math.Floor(nowStat / maxStat * (BOX2_WIDTH - 2));
            int emptyLength = (BOX2_WIDTH - 2) - gaugeLength;

            string gauge = new string(' ', gaugeLength);
            string empty = new string(' ', emptyLength);

            return $" `null,{color}`{gauge}`null,gray`{empty}`null,black` ";
        }
    }
}