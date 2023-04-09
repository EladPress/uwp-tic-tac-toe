using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class Player
    {
            private string name;
            private int score;

            public Player(string name, int score)
            {
                this.name = name;
                this.score = score;
            }
            public Player()
            {
                this.name = "";
                this.score = 0;
            }
            public void win()
            {
                score = score + 1;
            }
            public int GetScore()
            {
                return score;
            }
            public string GetName()
            {
                return name;
            }
        public Boolean IsExist()
        {
            if (name != "")
                return true;
            else
                return false;
        }
    }
}
