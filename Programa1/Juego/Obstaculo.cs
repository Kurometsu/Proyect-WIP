using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Obstaculo
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
        public void setChar(char ch)
        {
            Skin = ch;

        }
        public void setPos(int X , int Y)
        {
            posX = X;
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
        public void Show()
        {
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Skin);


        }
    }
}
