using System;
using System.IO;
using System.Threading;

namespace infrastructure
{
    public partial class LogAplication
    {
        public void registro(string mensaje)
        {
            if (_archivo.Length == 0)
                _archivo = "logAplicaciones.txt";
            if (_ruta.Length == 0)
                _ruta = @"c:\transer\logs\";
            if (!File.Exists(_ruta + _archivo))
                Directory.CreateDirectory(_ruta);
            using (StreamWriter writer = new StreamWriter(_ruta + _archivo, true))
            {
                writer.WriteLine("");
                writer.WriteLine("*");
                writer.WriteLine("**");
                writer.WriteLine("***");
                writer.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(mensaje);
                writer.WriteLine("");
            }
        }
        internal void ReadKey(string v1, bool v2)
        {

        }
        public void consoleTitle(string mensaje)
        {
            posX = 25;//Fila maximo 80
            posY = 1;//Columnas maximo 24

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine("ENVIO MINISTERIO DE TRANSPORTE");
            Console.WriteLine();
        }
        public void console(string mensaje)
        {
            /*for (int i = 0; i < 80; i++)
            {
                posX = i;
                //posY = i;
                Console.Write("X");
            }
            Console.ReadKey();
            */
            posX = 5;//Fila maximo 80
            posY = 3;//Columnas maximo 24
            Console.SetCursorPosition(posX, posY);
            Console.Write(mensaje);
        }
        public void procesando(string titulo, string mensaje)
        {
            clearColumn(0);
            clearColumn(1);
            clearColumn(2);
            clearColumn(3);
            clearColumn(4);
            clearColumn(5);
            clearColumn(6);
            clearColumn(7);
            clearColumn(8);
            clearColumn(9);
            clearColumn(10);
            clearColumn(11);
            clearColumn(12);
            clearColumn(13);
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 80; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(titulo);
            posY = 2;//Fila maximo 80
            posX = 0;//Fila maximo 80
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(posX, posY);
            Console.Write(mensaje);
        }
        public void avance(string titulo, string cabecera, string cuerpo, string resumen, string color)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            clearColumn(0);
            clearColumn(1);
            clearColumn(2);
            clearColumn(3);
            clearColumn(4);
            clearColumn(5);
            clearColumn(6);
            clearColumn(7);
            clearColumn(8);
            clearColumn(9);
            clearColumn(10);
            clearColumn(11);
            clearColumn(12);
            clearColumn(13);
            clearColumn(14);
            clearColumn(15);
            clearColumn(16);
            clearColumn(17);
            clearColumn(18);
            clearColumn(19);
            clearColumn(20);
            clearColumn(21);
            clearColumn(22);
            clearColumn(23);
            clearColumn(24);
            clearColumn(25);
            clearColumn(26);
            clearColumn(27);
            clearColumn(28);
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 80; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(titulo);
            posX = 0;//Fila maximo 80
            posY = 2;//Columnas maximo 24
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 80; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            posX = 0;//Fila maximo 80
            posY = 2;//Columnas maximo 24
            Console.SetCursorPosition(posX, posY);
            Console.Write(cabecera);


            posY = 12;//Fila maximo 80
            posX = 0;//Fila maximo 80
            Console.SetCursorPosition(posX, posY);
            switch (color)
            {
                case "Rojo":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i < 80; i++)
                        {
                            Console.Write(" ");
                        }

                        break;
                    }
                case "Verde":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < 80; i++)
                        {
                            Console.Write(" ");
                        }
                        break;
                    }
                case "Azul":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int i = 0; i < 80; i++)
                        {
                            Console.Write(" ");
                        }

                        break;
                    }
                case "Azul-Blanco":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int i = 9; i < 21; i++)
                        {
                            for (int j = 0; j < 80; j++)
                            {
                                Console.Write(" ");
                            }                            
                        }

                        break;
                    }
                case "Rojo-Blanco":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 9; i < 21; i++)
                        {
                            for (int j = 0; j < 80; j++)
                            {
                                Console.Write(" ");
                            }
                        }

                        break;
                    }
                default:
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        for (int i = 0; i < 80; i++)
                        {
                            Console.Write(" ");
                        }
                        break;
                    }
            }
            posY = 12;//Fila maximo 80
            posX = 0;//Fila maximo 80
            Console.SetCursorPosition(posX, posY);
            Console.Write(cuerpo);

            posY = 23;//Fila maximo 80
            posX = 0;//Fila maximo 80

            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 80; i++)
            {
                Console.Write(" ");
            }
            posY = 23;//Fila maximo 80
            posX = 0;//Fila maximo 80
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(posX, posY);
            Console.Write(resumen);
        }
        public void avance(string titulo, string cabecera, string cuerpo, string lineaColor, string resumen, string color)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            clearColumn(0);
            clearColumn(1);
            clearColumn(2);
            clearColumn(3);
            clearColumn(4);
            clearColumn(5);
            clearColumn(6);
            clearColumn(7);
            clearColumn(8);
            clearColumn(9);
            clearColumn(10);
            clearColumn(11);
            clearColumn(12);
            clearColumn(13);
            clearColumn(14);
            clearColumn(15);
            clearColumn(16);
            clearColumn(17);
            clearColumn(18);
            clearColumn(19);
            clearColumn(20);
            clearColumn(21);
            clearColumn(22);
            clearColumn(23);
            clearColumn(24);
            clearColumn(25);
            clearColumn(26);
            clearColumn(27);
            clearColumn(28);
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 80; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(titulo);
            posX = 0;//Fila maximo 80
            posY = 2;//Columnas maximo 24
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 80; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            posX = 0;//Fila maximo 80
            posY = 2;//Columnas maximo 24
            Console.SetCursorPosition(posX, posY);
            Console.Write(cabecera);


            posY = 12;//Fila maximo 80
            posX = 0;//Fila maximo 80
            Console.SetCursorPosition(posX, posY);


            posY = 12;//Fila maximo 80
            posX = 0;//Fila maximo 80
            Console.SetCursorPosition(posX, posY);
            Console.Write(cuerpo);


            switch (color)
            {
                case "Rojo":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i < 80; i++)
                        {
                            Console.Write(" ");
                        }

                        break;
                    }
                case "Verde":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < 80; i++)
                        {
                            Console.Write(" ");
                        }
                        break;
                    }
                case "Azul":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int i = 0; i < 80; i++)
                        {
                            Console.Write(" ");
                        }

                        break;
                    }
                case "Azul-Blanco":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int i = 9; i < 21; i++)
                        {
                            for (int j = 0; j < 80; j++)
                            {
                                Console.Write(" ");
                            }
                        }

                        break;
                    }
                case "Rojo-Blanco":
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 9; i < 21; i++)
                        {
                            for (int j = 0; j < 80; j++)
                            {
                                Console.Write(" ");
                            }
                        }

                        break;
                    }
                default:
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        for (int i = 0; i < 80; i++)
                        {
                            Console.Write(" ");
                        }
                        break;
                    }
            }
            posY = 9;//Fila maximo 80
            posX = 0;//Fila maximo 80
            Console.SetCursorPosition(posX, posY);
            Console.Write(lineaColor);

            posY = 23;//Fila maximo 80
            posX = 0;//Fila maximo 80

            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 80; i++)
            {
                Console.Write(" ");
            }
            posY = 23;//Fila maximo 80
            posX = 0;//Fila maximo 80
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(posX, posY);
            Console.Write(resumen);
        }
        public void deterner(int t)
        {

            if (t == 0)
            {
                //Console.ReadKey();
            }
            else
            {
                Thread.Sleep(t);
            }
        }

        private void clearColumn(int pos)
        {
            Console.SetCursorPosition(0, pos);
            for (int i = 0; i < 80; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
