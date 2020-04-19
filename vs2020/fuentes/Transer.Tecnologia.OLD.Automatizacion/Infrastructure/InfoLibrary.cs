using System;

namespace Infrastructure
{
    public class InfoLibrary
    {
        public void avance(string msj)
        {
            #region Limpiar Linea
            for (int i = 0; i < 80; i++)
            {
                Console.SetCursorPosition(i, 23);
                Console.Write(" ");
            }
            #endregion fin Limpiar Linea
            Console.SetCursorPosition(0, 23);
            Console.Write("Avance : ");
            Console.SetCursorPosition(9, 23);
            if (msj.Length>69)
            {
                Console.Write(msj.Substring(1,69));
            }
            else
            {
                Console.Write(msj);
            }
        }
    }
}
