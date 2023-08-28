using System;

namespace AdivinaPalabras
{
    class Program
    {
        static void Main(string[] args)
        {
            string fraseOriginal = "El gato juega en el jardín";
            string[] palabrasOcultas = { "gato", "en", "jardín" };
            string[] palabrasAdivinadas = new string[palabrasOcultas.Length];

            string fraseOculta = OcultarPalabras(fraseOriginal, palabrasOcultas);

            int intentosRestantes = 10;

            Console.WriteLine("Bienvenido al juego de adivinar palabras ocultas!");
            Console.WriteLine($"Frase oculta: {fraseOculta}\n");

            while (intentosRestantes > 0)
            {
                Console.Write("Ingresa una palabra: ");
                string palabraIngresada = Console.ReadLine().ToLower();

                bool adivino = false;

                for (int i = 0; i < palabrasOcultas.Length; i++)
                {
                    if (palabraIngresada == palabrasOcultas[i] && palabrasAdivinadas[i] == null)
                    {
                        Console.WriteLine("¡Has acertado!");
                        palabrasAdivinadas[i] = palabraIngresada;
                        adivino = true;
                        break;
                    }
                }

                if (!adivino)
                {
                    Console.WriteLine("Incorrecto. Pierdes un intento.");
                    intentosRestantes--;
                }

                if (Array.TrueForAll(palabrasAdivinadas, palabra => palabra != null))
                {
                    Console.WriteLine("\n¡Felicitaciones! Has adivinado todas las palabras.");
                    Console.WriteLine($"La frase completa es: {fraseOriginal}");
                    break;
                }

                Console.WriteLine($"Intentos restantes: {intentosRestantes}\n");
            }

            if (intentosRestantes == 0)
            {
                Console.WriteLine("\n¡Agotaste tus intentos! Has perdido.");
                Console.WriteLine($"La frase completa era: {fraseOriginal}");
            }
        }

        static string OcultarPalabras(string frase, string[] palabras)
        {
            foreach (string palabra in palabras)
            {
                frase = frase.Replace(palabra, new string('_', palabra.Length));
            }
            return frase;
        }
    }
}

