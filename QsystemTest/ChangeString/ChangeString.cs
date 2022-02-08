using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeString
{
    public static class ChangeString
    {
        private static readonly char[] abecedario = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u', 'v',
            'w','x','y','z'};

        public static string build(string cadenaTexto)
        {
            //cadenaTexto = "123 Abcd*3";
            var charAlphabet = new char[cadenaTexto.Length];
            
            for (int i = 0; i < cadenaTexto.Length; i++)
            {
                charAlphabet[i] = cadenaTexto[i];

                for (int j = 0; j < abecedario.Length; j++)
                {
                    if(char.ToLower(charAlphabet[i]) == abecedario[j])
                    {
                        if(char.ToLower(charAlphabet[i]) == 'z')
                        {
                            charAlphabet[i] = char.IsUpper(charAlphabet[i]) ? char.ToUpper(abecedario[0]) : abecedario[0];
                            break;
                        }
                        charAlphabet[i] = char.IsUpper(charAlphabet[i]) ? char.ToUpper(abecedario[j + 1]) : abecedario[j + 1];
                        break;
                    }
                }
            }

            cadenaTexto = new string(charAlphabet);
            //Console.WriteLine(cadenaTexto);
            return cadenaTexto;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Digite la cadena de texto a convertir");
                var cadena = Console.ReadLine();
                Console.WriteLine($"Entrada: {cadena}");
                cadena = build(cadena);
                Console.WriteLine($"Salida: {cadena}");
                Console.WriteLine("* * Presione Ctrl C para termina con la instruccion * *");
            }
        }
    }
}
