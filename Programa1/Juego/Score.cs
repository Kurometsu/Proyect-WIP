using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Score
    {
        
        private int score;
        public void Scoreboard()
        {
            
            Console.SetCursorPosition(0, 2);
            for (int i = 0; i < 120; i++)
            {
                Console.Write("-");

            }
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("Score : "+ score);


        }
        public void setScore(int scr)
        {
            score = scr;
        }
        public int getScore()
        {
            return score;
        }
        public void ScoreUp()
        {
            score +=1;
        }


    }
}
