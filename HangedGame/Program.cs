using System;

namespace HangedGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe algo:");
            try
            {
                string input = Console.ReadLine();
                int a = int.Parse(input);
                Console.WriteLine("Es " + a);
            }
            catch (FormatException)
            {
                Console.WriteLine("Lo que ingresaste no es un número válido.");
            }

            Console.WriteLine("Presiona Enter para salir...");
            Console.ReadLine(); // Espera a que el usuario presione Enter antes de cerrar la consola
        }
    }
}
