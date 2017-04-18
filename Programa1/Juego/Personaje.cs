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
        private int vidas;
        private int checkDirec; //sirve para checkear la direccion del disparo. no funciona.

        
        public void Start(int _x , int _y , char pj)
        {
            posX = _x;
            posY = _y;
            Skin = pj;
            vidas = 3;

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
        public int getVidas() //sirve para setear el game over de la clase Juego
        {
            return vidas;
        }
        public int getCheckDirec()
        {
            return checkDirec;
        }

        public void Damage()
        {
            vidas -= 1;
        }

        public void ShowVidas()
        {
            Console.SetCursorPosition(100, 1);
            Console.WriteLine("Vidas restantes : " + vidas);
        }

        public void MoveUp()
        {
            if(posY!=4)
                posY -= 1;
            checkDirec = 1;
        }
        public void MoveDown()
        {
            if (posY != 30)
                posY += 1;
            checkDirec = 2;
        }
        public void MoveLeft()
        {
            if (posX != 0)
                posX -= 1;
            checkDirec = 3;
        }
        public void MoveRight()
        {
            if (posX != 119)
                posX += 1;
            checkDirec = 4;
        }

    }
}
