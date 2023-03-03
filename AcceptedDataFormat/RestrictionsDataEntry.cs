using System;
using System.Text.RegularExpressions;


namespace AcceptedDataFormat
{
    public class RestrictionsDataEntry
    {
        public string AllowOnlyStringData(string i)
        {
            //Comprueba que una cadena no sea vacia, si lo es devuelve un true.
            while (string.IsNullOrEmpty(i) == false)
            {
                if (string.IsNullOrEmpty(i) == false)
                {

                    //Regex se usa para buscar expreskones regulares. Busca cirtos parametros en algun dato o entrada de texto.
                    //"[a-z A-Z 0-9]" Busca solo lo que esta entre llaves.
                    Regex regex = new Regex("[a-z A-Z À-ÿ 0-9]|[^a-z A-z]");
                    if (regex.IsMatch(i))
                    {
                        // @"\s" Busca los espacios en blanco al principio o al final de la cadena.
                        regex = new Regex(@"^\s|\s$");

                        //Pregunta si lo buscado con regex coincide con la variable i.
                        if (regex.IsMatch(i))
                        {
                            Console.WriteLine($"No se pueden ingresar valores vacios, intentelo nuevamente");
                            i = Console.ReadLine();
                        }
                        else
                        {
                            // (@"\d") busca los números.
                            regex = new Regex(@"\d");
                            if (regex.IsMatch(i))
                            {
                                Console.WriteLine($"No se pueden ingresar números, intentelo nuevamente");
                                i = Console.ReadLine();
                            }
                            else
                            {
                                //@"[^a-z A-z]" busca todo lo que no este entre llaves por el ^.
                                regex = new Regex(@"[^a-z A-z À-ÿ]");
                                if (regex.IsMatch(i))
                                {
                                    Console.WriteLine($"No se pueden ingresar caracteres, intentelo nuevamente");
                                    i = Console.ReadLine();
                                }
                                else
                                {
                                    //Unica forma de salir del ciclo, que el dato ingresado este solo compuesto por letras.
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(i) == true)
            {
                Console.WriteLine($"No se pueden ingresar caracteres o valores vacios, intentelo nuevamente");
                i = Console.ReadLine();
                AllowOnlyStringData(i);
            }

            return i;
        }

        //Si no se puede convertir en un dato tipo long (porque el usuario ingrasa letras o caracteres) llega un 0.
        //Repite esto hasta que el usuario ingrese un número, el cual será el que va a la clase.
        public long CancelLettersLong(long i)
        {
            while (i == 0)
            {
                if (i == 0)
                {
                    //Intento convertir un dato tipo string en tipo long y si no puedo el valor devuelto lo mando a la finción "" de la calse padre.
                    Console.WriteLine("No se puede ingresar ese tipo de dato, intentelo nuevamente: ");
                    long.TryParse(Console.ReadLine(), out i);
                }
            }
            return i;
        }

        public int CancelLettersInt(int i)
        {
            while (i == 0)
            {
                if (i == 0)
                {
                    Console.WriteLine("No se puede ingresar ese tipo de dato, intentelo nuevamente: ");
                    int.TryParse(Console.ReadLine(), out i);
                }
            }
            return i;
        }

        public string MailFormat(string i)
        {
            //Comprueba que haya una cadena de caracteres menos el espacio y el @, despues el @ solo, otra vez los caracteres y por ultimo un ".com".
            Regex regex = new Regex(@"[^@\s]+@[^@\s]+\.com");
            while (regex.IsMatch(i) == false)
            {
                if (regex.IsMatch(i) == false)
                {
                    Console.WriteLine($"Por favor ingrese un formato de mail valido.");
                    i = Console.ReadLine();
                }
            }
            return i;
        }
        public string DateFormat(string i)
        {
            //Comprueba que haya 4 digitos numericos un "- o /", despues un número de 2 digitos entre el 1 y el 12, y por último un número de 2 digitos del 1 al 31 .
            Regex regex = new Regex(@"\d{4}[/-]([1-9]|0[1-9]|1[0-2])[/-]([1-9]|0[1-9]|1\d|2\d|3[0-1]|\d)$");
            while (regex.IsMatch(i) == false)
            {
                if (regex.IsMatch(i) == false)
                {
                    Console.WriteLine($"Por favor ingrese un formato de fecha valida.");
                    i = Console.ReadLine();
                }
            }
            return i;
        }
    }
}
