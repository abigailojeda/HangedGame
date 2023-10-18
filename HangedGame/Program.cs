using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace HangedGame
{
    internal class Program
    {
        //words
        List<string> words = new List<string>();
        static int rounds = 3;


        static void Main(string[] args)
        {
            Hangman();
            
        }

       
        static void Hangman()
        {
            Program game = new Program();
            game.MostrarCabecera();
            game.PrecargarPalabras();

            string word = game.SeleccionarPalabraAleatoria();
            string cadena = game.OcultarPalabra(word);

            game.DibujarLineas(cadena);

            char letter = game.SolicitarLetra();

            game.ComprobarLetra(cadena, letter);

            Console.WriteLine("Letter: " + letter);
           
            //Console.WriteLine("Escribe un número");
            //string input = Console.ReadLine();
            //int a = int.Parse(input);
            //Console.WriteLine("Es " + a);
            //Console.WriteLine("Presiona Enter para salir...");
            //Console.ReadLine();
        }

        public void MostrarCabecera()
        {
            Console.WriteLine("Bienvenido al juego del ahorcado");
            Console.WriteLine("Tienes " + rounds + " intentos para adivinar la palabra.");
            Console.WriteLine("¡Buena suerte!");
            Console.WriteLine();
        }

        public void PrecargarPalabras()
        {

            words.Add("manzana");
            words.Add("pera");
            words.Add("naranja");
            words.Add("plátano");
            words.Add("uva");
        }

        public string SeleccionarPalabraAleatoria()
        {
           
            Random random = new Random();
            int index = random.Next(0, words.Count);

            return words[index];
        }

        public string OcultarPalabra(string word)
        {
            string hiddenWord = new string('_', word.Length);
            return hiddenWord;
        }

        public  void DibujarLineas(string cadena)
        {
            foreach (char caracter in cadena)
            {
                Console.Write(caracter + " ");
            }
            Console.WriteLine(); 
        }

        public int IntentosRestantes()
        {
            return rounds;
        }

        public char SolicitarLetra()
        {
            //char letter = '\0'; 

            //while (letter == '\0')
            //{
            //    Console.Write("Inserta una letra: ");
            //    string input = Console.ReadLine();
            //    Console.WriteLine("Letter: " + input);

            //    if (input.Length == 1 && char.IsLetter(input[0]))
            //    {
            //        letter = input[0];
            //    }
            //    else
            //    {
            //        Console.WriteLine("Entrada no válida. Por favor, inserta una única letra.");
            //    }
            //}

            //return letter;

            char letter = '\0';
            return letter;
        }

        public void ComprobarLetra(string palabra, char letra)
        {
            Console.WriteLine("PUES: " + palabra.Contains(letra));
        }



    }
}
