using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Juego
{
    class Juego
    {
        private bool inGame = true;
        private int eleccion = 1;
        private char pj = 'O';
        private char pj1 = '@';//agrego
        private char ob = '+';
        private char rv = '-';
        private char pickup = '7'; 
        private ConsoleKeyInfo userKey;

        private Random Gen = new Random();
        private Personaje playah = new Personaje();
        private Personaje playah1 = new Personaje();//agrego
        private Soul[] Rivals = new Soul[10];
        private Obstaculo[] Obst = new Obstaculo[20];
        private Score Points = new Score();
        private Pickup[] Items = new Pickup[10];


        //Creadores
        public void Iniciar()
        {
           for (int i = 0; i < Rivals.Length; i++)
            {
                    Rivals[i] = new Soul();
                    Rivals[i].Start(Gen.Next(1, 120), Gen.Next(4, 30), rv);
            }                       

            for (int i = 0; i < Obst.Length; i++)
            {
                    Obst[i] = new Obstaculo();
                    Obst[i].Start(Gen.Next(1, 120), Gen.Next(4, 30), ob);
            }
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = new Pickup();
                Items[i].ItemStart(Gen.Next(1, 120), Gen.Next(4, 30), pickup);
            }
        }
        public void Run()
        {
            //Menu

            while (eleccion != 4)
            {
                if (File.Exists("MensajeBienvenida.txt") == false)
                {
                    FileStream msg = File.Create("MensajeBienvenida.txt");
                    StreamWriter wrt = new StreamWriter(msg);
                    StreamReader rdr = new StreamReader(msg);
                    Console.SetCursorPosition(30, 4);
                    Console.Write("-------WELCOME!!------- \ningrese el mensaje de bienvenida : ");
                    wrt.WriteLine(Console.ReadLine());
                    wrt.Close();
                    msg.Close();
                    Console.Clear();
                    Console.SetCursorPosition(50, 5);
                    //Console.WriteLine(rdr.ReadLine());
                    //rdr.Close();

                }
                else
                
                Console.SetCursorPosition(50, 6);
                Console.WriteLine(" \n[1]Iniciar 1 jugador\n[2]Iniciar 2 jugadores\n[3]Creditos\n[4]Salir");
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
                    //Inicio Juego SinglePlayer
                    case 1:
                        Console.WriteLine("Flechas para moverse\nEsc para salir\n\n["+pj+"] Jugador\n["+pickup+ "] Objetivos\n[" + ob+"]=Obstaculo\n["+rv+"]=Enemigo\n\n\nObten "+Items.Length+" puntos para ganar\n(enter para continuar..) ");
                        Console.ReadLine();
                        Console.Clear();
                        inGame = true;
                        playah.Start(50, 20, pj);
                        while (inGame)
                        {

                            Points.Scoreboard();

                            for (int i = 0; i < Obst.Length; i++)
                            {
                                Obst[i].Show();
                            }
                            for (int i = 0; i < Rivals.Length; i++)
                            {

                                Rivals[i].MoveLeft();
                                Rivals[i].Show();

                            }
                            for (int i = 0; i < Items.Length; i++)
                            {
                                Items[i].Show();

                            }
                            playah.Show();

                            //cki = Console.ReadKey();
                            if (Console.KeyAvailable)
                            {
                                userKey = Console.ReadKey(true);

                                switch (userKey.Key)
                                {


                                    case ConsoleKey.Escape:
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
                            //Colisiones
                            for (int i = 0; i < Obst.Length; i++)
                            {

                                if (playah.getPosX() == Obst[i].getPosX() && playah.getPosY() == Obst[i].getPosY())
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(50, 5);
                                    Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                    Console.ReadLine();
                                    Console.Clear();
                                    inGame = false;

                                }

                            }
                            for (int i = 0; i < Rivals.Length; i++)
                            {

                                if (playah.getPosX() == Rivals[i].getPosX() && playah.getPosY() == Rivals[i].getPosY())
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(50, 5);
                                    Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                    Console.ReadLine();
                                    Console.Clear();
                                    inGame = false;

                                }

                            }
                            for (int i = 0; i < Items.Length; i++)
                            {
                                if (playah.getPosX() == Items[i].getposX() && playah.getPosY() == Items[i].getposY())
                                {
                                   
                                        if(Items[i].getSkin() == pickup)
                                        {
                                            Points.ScoreUp();
                                            Console.SetCursorPosition(20, 1);
                                            Console.WriteLine("+1 Points!");
                                            Items[i].setSkin('X');
                                        }
                                    else
                                    {
                                        Console.SetCursorPosition(20, 1);
                                        Console.WriteLine("+1 Points!");
                                    }

                                        
                                    
                                }
                            }
                            if (Points.getScore() == (Items.Length * 100))
                            {
                                Console.Clear();
                                inGame = false;
                                Console.SetCursorPosition(50, 5);
                                Console.WriteLine("YOU WIN !!!\n\n\n(presione enter para continuar)");
                                Console.ReadLine();
                                Console.Clear();

                            }
                        }
                       
                        break;
                    //aca te agrego para 2 jugadores
                    case 2:
                        Console.WriteLine("Esc para salir\n\n["+pj+"] Jugador 1 Flechas para moverse\n["+pj1+"] Jugador 2 WASD\n["+ob+"]=Obstaculo\n["+rv+"]=Enemigo\n\nHAVE FUN -(°A°)- \n(enter para continuar..) ");
                        Console.ReadLine();
                        Console.Clear();
                        inGame = true;
                        playah.Start(50, 20, pj);
                        playah1.Start(20, 10, pj1);//agrego
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


                                    case ConsoleKey.Escape:
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
                                    Console.Clear();
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
                                    Console.Clear();
                                    inGame = false;

                                }

                            }
                            /*te agrego colision entre jugadores
                            if (playah.getPosX() == playah1.getPosX() && playah.getPosY() == playah1.getPosY())
                            {
                                Console.Clear();
                                Console.SetCursorPosition(50, 5);
                                Console.WriteLine("GAME OVER\n\n\n(presione enter para continuar)");
                                Console.ReadLine();
                                Console.Clear();
                                inGame = false;
                            }*/

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

     
