using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRange
{
    public static class OrderRange
    {
        public static Tuple<List<int>, List<int>> build(int[] numeros)
        {
            var listaPares = new List<int>();
            var listaImPares = new List<int>();

            //numeros = new int[] { 2, 1, 4, 5,10,100,91,13,51 };
            //numeros = new int[] { 2, 1, 4, 5 };
            //numeros = new int[] { 4,2,9,3,6 };
            //numeros = new int[] { 58,60,55,48,57,73 };

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i]%2 == 0 )
                    listaPares.Add(numeros[i]);
                else
                    listaImPares.Add(numeros[i]);
            }

            listaPares = listaPares.OrderBy(x => x).ToList();
            listaImPares = listaImPares.OrderBy(x => x).ToList();

            return Tuple.Create(listaImPares, listaPares); 
        }

        public static void ValidateQuantityNumber(bool validate,out int Nnumbers, string stringNumber)
        {
            do
            {
                Console.WriteLine("Digite la cantidad de numeros a ingresar");
                stringNumber = Console.ReadLine();

                if (!int.TryParse(stringNumber, out Nnumbers))
                {
                    Console.WriteLine("Digite un numero valido" + Environment.NewLine);
                }
                else if (Nnumbers < 0)
                {
                    Console.WriteLine("Solo se permite numeros positivos" + Environment.NewLine);
                }
                else
                {
                    validate = false;
                }

            } while (validate);
        }

        public static void ArrayValidateNumbers(int[] coleccionNumeros, bool validate, string stringNumber, int Nnumbers)
        {
            for (int i = 0; i < coleccionNumeros.Length; i++)
            {
                do
                {
                    validate = true;
                    Console.WriteLine($"Digite el {i + 1} numero entero positivo");
                    stringNumber = Console.ReadLine();

                    if (!int.TryParse(stringNumber, out Nnumbers))
                    {
                        Console.WriteLine(Environment.NewLine + "Digite un numero valido" + Environment.NewLine);
                    }
                    else if (Nnumbers < 0)
                    {
                        Console.WriteLine(Environment.NewLine + "Solo se permite numeros positivos" + Environment.NewLine);
                    }
                    else
                    {
                        validate = false;
                        coleccionNumeros[i] = Nnumbers;
                    }
                } while (validate);
            }
        }

        static void Main(string[] args)
        {
            #region QuickTest
            //var stringResult = "";
            //var imprimir = build(null);
            //stringResult = string.Format("Salida: [{0}]", string.Join(", ", imprimir.Item2));
            //stringResult = $"{stringResult} {string.Format(", [{0}]", string.Join(", ", imprimir.Item1))}";
            //Console.WriteLine(stringResult+Environment.NewLine);
            #endregion
            while (true)
            {
                var stringResult = "";

                var validate = true;
                int Nnumbers = 0;
                string stringNumber = string.Empty;

                ValidateQuantityNumber(validate, out Nnumbers, stringNumber);

                int[] coleccionNumeros = new int[Nnumbers];
                validate = true;

                ArrayValidateNumbers(coleccionNumeros, validate, stringNumber, Nnumbers);

                Console.WriteLine("Entrada: [{0}]", string.Join(", ", coleccionNumeros));
                //Array.ForEach(coleccionNumeros, Console.WriteLine);

                var imprimir = build(coleccionNumeros);
                stringResult = string.Format("Salida: [{0}]", string.Join(", ", imprimir.Item2));
                stringResult = $"{stringResult} {string.Format(", [{0}]", string.Join(", ", imprimir.Item1))}";

                Console.WriteLine(stringResult + Environment.NewLine);
            }
        }
    }
}
