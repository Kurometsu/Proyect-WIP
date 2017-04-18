using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Disparo
    {
        private char skin = '*';
        private int posX;
        private int posY;

        public void ShowDisparo(int _x, int _y)
        {
            posX = _x;
            posY = _y;
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(skin);
        }

        public void Recorrido(int direc)
        {
            switch(direc) //recibe un numero como parametro para setear la direccion.
            {
                case 1:
                    posY -= 1;
                    break;

                case 2:
                    posY += 1;
                    break;

                case 3:
                    posX -= 1;
                    break;

                case 4:
                    posX += 1;
                    break;
            }
        }

        public bool Death()
        {
            if (posY != 4 || posY != 30 || posX != 0 || posX != 119)
                return false;
            else return true;
        }
    }
}
