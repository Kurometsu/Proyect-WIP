using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Juego
    {
        private bool inGame = true;
        private int eleccion = 1;
        private char pj = 'O';
        private char pj1 = '@';//agrego
        private char ob = '+';
        private char rv = '$';

        private ConsoleKeyInfo userKey;

        private Random Gen = new Random();
        private Personaje playah = new Personaje();
        private Personaje playah1 = new Personaje();//agrego
        private Soul[] Rivals = new Soul[5];
        private Obstaculo[] Obst = new Obstaculo[20];

        //Creadores
        public void Iniciar()
        { 
            for (int i = 0; i<Rivals.Length; i++)
                    Rivals[i] = new Soul();
                    
    
            for (int i = 0; i<Rivals.Length; i++)
            
                Rivals[i].Start(Gen.Next(1, 120), Gen.Next(1, 30), rv);
            

            for (int i = 0; i<Obst.Length; i++)
            
                Obst[i] = new Obstaculo();
            
            for (int i = 0; i<Obst.Length; i++)
            
                Obst[i].Start(Gen.Next(1, 120), Gen.Next(1, 30), ob);
           }
        public void Run()
        {
            //Menu
            while (eleccion != 3 || inGame == true) {
                Console.SetCursorPosition(50, 5);
            Console.WriteLine("-------Bienvenido------- \n[1]Iniciar 1 jugador\n[2]Iniciar 2 jugadores\n[3]Creditos\n[4]Salir");
                //Chequeo de error
                
                try
                {
                    eleccion = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingresa algun numero e.e");
                    try
                    {
                        eleccion = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Me has cansado , te meto en el juego igual");
                        System.Threading.Thread.Sleep(1000);
                        //Console.ReadLine();
                    }


                }
                System.Threading.Thread.Sleep(0);
                Console.Clear();
                //Elecciones
                switch (eleccion)
                {
                    //Inicio Juego
                    case 1:
                        Console.WriteLine("Flechas para moverse\n Backspace para salir\n\n[0] Jugador\n[+]=Obstaculo\n[$]=Enemigo\n\n(enter para continuar..) ");
                        Console.ReadLine();
                        Console.Clear();
                        inGame = true;
                        playah.Start(50, 20, pj);
                        while (inGame)
                        {

                            for (int i = 0; i < Obst.Length; i++)
                            {
                                Obst[i].Show();
                            }
                            for (int i = 0; i < Rivals.Length; i++)
                            {

                                Rivals[i].MoveLeft();
                                Rivals[i].Show();

                            }
                            playah.Show();

                            //cki = Console.ReadKey();
                            if (Console.KeyAvailable)
                            {
                                userKey = Console.ReadKey(true);

                                switch (userKey.Key)
                                {


                                    case ConsoleKey.Backspace:
                                        Console.Clear();
                                        inGame = false;
                                        break;

                                    case ConsoleKey.UpArrow:
                                        playah.MoveUp();

                                        break;
                                    case ConsoleKey.DownArrow:

                                        playah.MoveDown();

                                        break;
                                    case ConsoleKey.RightArrow:
                                        playah.MoveRight();

                                        break;
                                    case ConsoleKey.LeftArrow:
                                        playah.MoveLeft();
                                        break;
                                }
                            }

                            System.Threading.Thread.Sleep(50);
                            Console.Clear();
                        }
                        break;
                        //aca te agrego para 2 jugadores
                    case 2:
                        Console.WriteLine("Flechas para moverse\n Backspace para salir\n\n[0] Jugador\n[@] Jugador\n[+]=Obstaculo\n[$]=Enemigo\n\n(enter para continuar..) ");
                        Console.ReadLine();
                        Console.Clear();
                        inGame = true;
                        playah.Start(50, 20, pj);
                        playah1.Start(0, 0, pj1);//agrego
                        while (inGame)
                        {

                            for (int i = 0; i < Obst.Length; i++)
                            {
                                Obst[i].Show();
                            }
                            for (int i = 0; i < Rivals.Length; i++)
                            {

                                Rivals[i].MoveLeft();
                                Rivals[i].Show();

                            }
                            playah.Show();
                            playah1.Show();//agrego

                            //cki = Console.ReadKey();
                            if (Console.KeyAvailable)
                            {
                                userKey = Console.ReadKey(true);

                                switch (userKey.Key)
                                {


                                    case ConsoleKey.Backspace:
                                        Console.Clear();
                                        inGame = false;
                                        break;

                                    case ConsoleKey.UpArrow:
                                        playah.MoveUp();

                                        break;
                                    case ConsoleKey.DownArrow:

                                        playah.MoveDown();

                                        break;
                                    case ConsoleKey.RightArrow:
                                        playah.MoveRight();

                                        break;
                                    case ConsoleKey.LeftArrow:
                                        playah.MoveLeft();
                                        break;
                                    //aca te agrego para el otro pj
                                    case ConsoleKey.W:
                                        playah1.MoveUp();

                                        break;
                                    case ConsoleKey.S:

                                        playah1.MoveDown();

                                        break;
                                    case ConsoleKey.D:
                                        playah1.MoveRight();

                                        break;
                                    case ConsoleKey.A:
                                        playah1.MoveLeft();
                                        break;
                                }
                            }

                            for (int i = 0; i < Obst.Length; i++)
                            {
                                //aca te agrego el ||
                                if (playah.getPosX() == Obst[i].getPosX() && playah.getPosY() == Obst[i].getPosY()
                                    || playah1.getPosX() == Obst[i].getPosX() && playah1.getPosY() == Obst[i].getPosY())
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(50, 5);
                                    Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                    Console.ReadLine();
                                    inGame = false;

                                }

                            }
                            for (int i = 0; i < Rivals.Length; i++)
                            {
                                //aca te agrego el ||
                                if (playah.getPosX() == Rivals[i].getPosX() && playah.getPosY() == Rivals[i].getPosY()
                                    || playah1.getPosX() == Rivals[i].getPosX() && playah1.getPosY() == Rivals[i].getPosY())
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(50, 5);
                                    Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                    Console.ReadLine();
                                    inGame = false;

                                }

                            }
                            //te agrego colision entre jugadores
                            if (playah.getPosX() == playah1.getPosX() && playah.getPosY() == playah1.getPosY())
                            {
                                Console.Clear();
                                Console.SetCursorPosition(50, 5);
                                Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                Console.ReadLine();
                                inGame = false;
                            }

                            System.Threading.Thread.Sleep(50);
                            Console.Clear();
                        }
                        break;
                    //Creditos
                    case 3:
                        Console.SetCursorPosition(50, 5);
                        Console.WriteLine("By : Alejo Perez Loguzzo");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                        //Salida
                    case 4:
                        Console.Clear();
                        inGame = false;
                        break;
                        

                }
                
            
            }
        }
    }


     
}