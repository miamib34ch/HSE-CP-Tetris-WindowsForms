using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    [Serializable]
    public class Player : ICloneable
    {
        public string Name { get; set; }
        public int Score;
        public string Mode { get; set; }

        public Player()
        {

        }

        public Player(string n, int s, string m)
        {
            Name = n;
            Score = s;
            Mode = m;
        }

        public override string ToString()
        {
            return this.Name + this.Score + this.Mode;
        }

        public override bool Equals(object obj)
        {
            Player p = (Player)obj;
            return (this.Name == p.Name) && (this.Score == p.Score) && (this.Mode == p.Mode);
        }

        public object Clone()
        {
            return new Player { Name = this.Name, Score = this.Score, Mode = this.Mode };
        }
    }
}
