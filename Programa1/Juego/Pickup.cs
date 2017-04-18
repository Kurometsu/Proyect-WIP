using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Pickup
    {
        private int posX;
        private int posY;
        private char Skin;
        public void ItemStart(int _x, int _y, char p)
        {
            posX = _x;
            posY = _y;
            Skin = p;
            

        }
        public void Show()
        {
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Skin);

        }
        public void setposX(int _x)
        {
            posX = _x;
        }
        public int getposX()
        {
            return posX;
        }
        public void setposY(int _y)
        {
            posY = _y;
        }
        public int getposY()
        {
            return posY;
        }
        public void setSkin(char _s)
        {
            Skin = _s;
        }
        public char getSkin()
        {
            return Skin;

        }
        


    }
}
