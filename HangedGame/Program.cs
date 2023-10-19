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

            //THE USER CAN CHOOSE BETWEEN INSERTING A WORD OR RANDOMIZING IT (BY NO INSERTING ANY WORD)


            string word = game.SetWord();

            string cadena = game.OcultarPalabra(word);
            List<char> letrasIntroducidas = new List<char>();

            game.DibujarLineas(cadena);

            while (rounds > 0 && cadena.Contains("_"))
            {

                char letter = game.SolicitarLetra();

                if (letrasIntroducidas.Contains(letter))
                {
                    Console.WriteLine("\n¡LA LETRA '" + letter + "' YA HA SIDO INTRODUCIDA PREVIAMENTE!");
                    continue;
                }

                letrasIntroducidas.Add(letter);

                bool result = game.ComprobarLetra(word, letter);

                if (result)
                {
                    cadena = game.ReemplazarLineas(word, cadena, letter);
                    game.showSuccess();
                    Console.WriteLine(cadena);
                    game.showInfo();
                }
                else
                {
                    game.DecrementarVidas();
                    game.showError(letter);
                    game.showInfo();
                    Console.WriteLine(ahorcadoASCII[rounds]);

                }

                game.showContinue();

            }

            if (cadena.Contains("_"))
            {
                game.showGameOver(word);

            }
            else
            {
                game.showVictory(word);

            }

            Console.WriteLine("\n\n+----------------+\nPULSA UNA TECLA PARA SALIR");
            string input = Console.ReadLine();
        }


        public void MostrarCabecera()
        {
            Console.WriteLine("\n\n+----------------+\n\nJUEGO DEL AHORCADO\n\nBY ABIGAIL OJEDA ALONSO\n\n+----------------+");
            Console.WriteLine("\n\nTIENES " + rounds + " INTENTOS PARA ADIVINAR LA PALABRA");
            Console.WriteLine("\n¡BUENA SUERTE!\n\n");

        }

        public void PrecargarPalabras()
        {

            words.Add("helicoptero");
            words.Add("pera");
            words.Add("gato");
            words.Add("unicornio");
            words.Add("ave");
            words.Add("videojuego");
            words.Add("pacman");
            words.Add("spyro");
            words.Add("adivino");
            words.Add("mañana");
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

        public void DibujarLineas(string cadena)
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
                Console.Write("\nINSERTA UNA LETRA:\n");
                string input = Console.ReadLine();

                if (input.Length == 1 && char.IsLetter(input[0]))
                {
                    letter = char.ToLower(input[0]);
                }
                else
                {
                    Console.WriteLine("\n\n+----------------+\n\nPOR FAVOR, INSERTA UNA LETRA VÁLIDA");
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

        public void showInfo()
        {
            Console.WriteLine("+----------------+\n\nINTENTOS DISPONIBLES: " + rounds + "\n\n+----------------+");
        }

        public void showError(char letter)
        {
            Console.WriteLine("\n\n+----------------+\n\nLA PALABRA NO CONTIENE LA LETRA'" + letter + "' U_U \n\n");
        }

        public void showSuccess()
        {
            Console.WriteLine("\n\n+----------------+\n\nLETRA CORRECTA! ^_^\n\n");
        }

        public void showVictory(string word)
        {
            Console.WriteLine("(*^_^*)\n\n¡FELICIDADES!\n\n+----------------+\n\nHAS ADIVINADO LA PALABRA: " + word);
        }

        public void showGameOver(string word)
        {
            Console.WriteLine("\nT_T\n\n¡HAS PERDIDO!\n\n+----------------+\n\nLA PALABRA ERA: " + word);
        }

        public void showContinue(){
            Console.WriteLine("\nPULSA UNA TECLA PARA CONTINUAR");
            Console.ReadKey();
            Console.Clear();
            
        }

        public string SetWord()
        {
            Console.WriteLine("+----------------+\n\nSI LO DESEEAS, INTRODUCE UNA PALABRA Y QUE OTRO JUGADOR LO ADIVINE\n");
            Console.WriteLine("\nSI LO PREFIERES, PULSA ENTER Y LA PALABRA SERÁ ALEATORIA\n\n");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
               
                return SeleccionarPalabraAleatoria();
            }
            else
            {
              
                return input.ToLower();
            }
        }

    }
}
