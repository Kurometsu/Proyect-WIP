using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Juego
{
    class Bienvenida
    {
        private string msj;
        public Bienvenida()
        {
            msj = ":b";
        }
        public void InsertarMsj()
        {
            if(!(File.Exists("MensajeBienvenida.txt")))
            {
                Console.SetCursorPosition(50, 5);
                Console.Write("Bienvenido \n\ningrese el mensaje de inicio: ");
                msj = Console.ReadLine();
                FileStream fs = new FileStream("MensajeBienvenida.txt", FileMode.Create, FileAccess.Write);
                if(fs.CanWrite)
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(msj);
                    fs.Write(buffer, 0, buffer.Length);

                }
                fs.Flush();
                fs.Close();
                Console.Clear();
             }

        }
        public string Leer()
        {
            try
            {
                FileStream fs = new FileStream("MensajeBienvenida.txt", FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[1024];
                int bytesread = fs.Read(buffer, 0, buffer.Length);
                return Encoding.ASCII.GetString(buffer, 0, bytesread);
            }
            catch(Exception e)
            {
                Console.WriteLine("Nada introducido");
                return "NOPE";

            }



        }

    }
}
