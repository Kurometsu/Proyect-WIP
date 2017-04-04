using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Personaje
    {
        private int posX;
        private int posY;
        private char Skin;

        
        public void Start(int _x , int _y , char pj)
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
        public int getPosX()
        {
            return posX;
        }
        public int getPosY()
        {

            return posY;
        }
        public void MoveUp()
        {
            if(posY!=0)
                posY -= 1;
        }
        public void MoveDown()
        {
            if (posY != 30)
                posY += 1;
        }
        public void MoveLeft()
        {
            if (posX != 0)
                posX -= 1;
        }
        public void MoveRight()
        {
            if (posX != 119)
                posX += 1;
        }

    }
}
