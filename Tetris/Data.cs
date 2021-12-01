using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Data
    {
        public static List<Player> list = new List<Player>();
        public static int ScoreTable = 0;
        public static int ScoreTable_Bastard = 0;
        public static int ScoreTable_TetColor = 0;
        public static string Name;
        public static string Gamemode;
        public static FileStream file;
    }
}
