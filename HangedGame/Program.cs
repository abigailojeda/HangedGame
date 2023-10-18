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
        static int rounds = 7;


        static void Main(string[] args)
        {
            Hangman();
            
        }

        static void Hangman()
        {
            string[] ahorcadoASCII = new string[]
            {
                "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
                "  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========",
                "",
            };

            Program game = new Program();
            game.MostrarCabecera();
            game.PrecargarPalabras();

            string word = game.SeleccionarPalabraAleatoria();
            string cadena = game.OcultarPalabra(word);

            game.DibujarLineas(cadena);

            while ( rounds > 0)
            {
                char letter = game.SolicitarLetra();

                bool result = game.ComprobarLetra(word, letter);

                if (result)
                {
                    cadena = game.ReemplazarLineas(word, cadena, letter);
                    Console.WriteLine("¡Letra correcta! Palabra adivinada parcialmente: " + cadena);
                }
                else
                {
                    game.DecrementarVidas();
                    Console.WriteLine("Ups!!! te quedan " + rounds + " intentos");
                    Console.WriteLine(ahorcadoASCII[rounds]);
                }
            }

            if (cadena.Contains("_"))
            {
                Console.WriteLine("¡Has perdido! La palabra era: " + word);
            }
            else
            {
                Console.WriteLine("¡Felicidades! Has adivinado la palabra: " + word);
            }

            Console.WriteLine("Pulsa una tecla para salir ");
            string input = Console.ReadLine();
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
            char letter = '\0'; 

            while (letter == '\0')
            {
                Console.Write("Inserta una letra: ");
                string input = Console.ReadLine();
             
               if (input.Length == 1 && char.IsLetter(input[0]))
                {
                    letter = input[0];
               }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, inserta una única letra.");
                }
            }

            return letter;

        }

        public bool ComprobarLetra(string palabra, char letra)
        {
            return palabra.Contains(letra);
        }

        public void DecrementarVidas()
        {
            if (rounds > 0)
            {
                rounds--;
            }
        }

        public string ReemplazarLineas(string palabraAdivinar, string palabraAdivinada, char letra)
        {
            char[] palabraAdivinadaArray = palabraAdivinada.ToCharArray();

            for (int i = 0; i < palabraAdivinar.Length; i++)
            {
                if (palabraAdivinar[i] == letra)
                {
                    palabraAdivinadaArray[i] = letra;
                }
            }

            return new string(palabraAdivinadaArray);
        }



    }
}
