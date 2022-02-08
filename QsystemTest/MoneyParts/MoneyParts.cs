using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyParts
{
    public  class MoneyParts
    {
        public static List<List<decimal>> build(decimal monto)
        {
            var denominacion = new decimal[] { 200m, 100m, 50m, 20m, 10m, 5m, 2m, 1m, 0.5m, 0.2m, 0.1m, 0.05m };
            var result = new List<List<decimal>>();

            foreach (var nume in denominacion.OrderBy(x=>x))
            {
                var arrayDecimal = new List<decimal>();
                if (monto >= nume)
                {
                    if (monto % nume == 0)
                    {
                        var nveces = monto / nume;

                        for (int i = 0; i < nveces; i++)
                        {
                            arrayDecimal.Add(nume);
                        }
                    }
                    result.Add(arrayDecimal);
                }
            }

            var ndecimal = (monto % 1);
            var nentero = (int)monto;

            if (nentero != 0 && ndecimal != 0)
            {
                foreach (var entero in denominacion.OrderBy(x=>x))
                {
                    var arrayEntero = new List<decimal>();
                    if (nentero >= entero)
                    {
                        var convertEntero = (int)entero;
                        if (convertEntero != 0)
                        {
                            if (convertEntero % entero == 0)
                            {
                                var ciclo = nentero / entero;

                                for (int i = 0; i < ciclo; i++)
                                {
                                    arrayEntero.Add(entero);
                                }
                            }

                            var aux = new List<decimal>(arrayEntero); 
                         
                                //Parte decimal Combinacion
                                foreach (var tdecimal in denominacion.OrderBy(x => x))
                                {
                                    var arrayDecimal = new List<decimal>();
                                    if (ndecimal >= tdecimal)
                                    {
                                        if (ndecimal % tdecimal == 0)
                                        {
                                            var ciclod = ndecimal / tdecimal;
                                            for (int j = 0; j < ciclod; j++)
                                            {
                                                aux.Add(tdecimal);
                                            }
                                        result.Add(aux);
                                        }
                                    }
                                    aux = new List<decimal>(arrayEntero);
                                }
                                //**
                        }
                    }
                }
            }

            return result;
        }

        public static void ValidateDecimalNumber(bool validate, out decimal Nnumbers, string stringNumber)
        {
            do
            {
                Console.WriteLine("Digite un monto decimal");
                stringNumber = Console.ReadLine();

                if (!decimal.TryParse(stringNumber, out Nnumbers))
                {
                    Console.WriteLine("Digite un numero valido" + Environment.NewLine);
                }
                else if (Nnumbers < 0)
                {
                    Console.WriteLine("Solo se permite decimales positivos" + Environment.NewLine);
                }
                else
                {
                    validate = false;
                }
            } while (validate);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                var validate = true;
                decimal Nnumbers = 0;
                string stringNumber = string.Empty;

                ValidateDecimalNumber(validate, out Nnumbers, stringNumber);

                var cantida = build(Nnumbers);

                Console.WriteLine($"Entrada: {Nnumbers}");

                foreach (var list in cantida)
                {
                    if (list.Count > 0)
                        Console.WriteLine("Salida: [{0}]", string.Join(", ", list));
                }
                Console.WriteLine("Digite Ctrl+c para terminar la ejecución"+Environment.NewLine);
            }
        }
    }

}
