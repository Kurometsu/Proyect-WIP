using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Soul
    {
        private int posX;
        private int posY;
        private char Skin;


        public void Start(int _x, int _y, char pj)
        {
            posX = _x;
            posY = _y;
            Skin = pj;

        }
        public void Show()
        {
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Skin);


        }
        public void setChar(char ch)
        {
            Skin = ch;

        }
        public void setPosX(int X)
        {
            posX = X;
        }
        public void setPosY( int Y)
        {
            
            posY = Y;
        }

        public int getPosX()
        {
            return posX;
        }
        public int getPosY()
        {

            return posY;
        }
        public void MoveLeft()
        {
            if (posX== 0)
            {
                posX=118;
            }
            else
            {
                posX -= 1;
            }
        }
        public void MoveRight()
        {
            if (posX == 118)
            {
                posX = 1;
            }
            else
            {
                posX += 1;
            }
        }
        public void MoveUp()
        {
            if (posY == 0)
            {
                posY = 29;
            }
            posY -= 1;
        }
        public void MoveDown()
        {
            if (posY == 30)
            {
                posY = 0;
            }
            posY += 1;
        }
        
        



    }
}

