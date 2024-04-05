using System;

namespace PAC_Desarrollo_Entrega_2S2324
{
    public class Program
    {
        static void Main(string[] args)
        {
            //--- Declaracion de variables
            string frase = "";
            string resultado = "";

            //------------------------------------------------------------------------------------------ Ejecución libre del programa

            //-------------------------- Se valida que la frase introducida sea correcta
            do
            {
                Console.Write("Inserta una frase para que la analice: ");
                frase = Console.ReadLine();

            } while (FraseValida(frase) == false);

            //-------------------------- Se obtiene la cuenta de caracteres mayúsculos, minúsculos, numéricos y otros
            resultado = ContarCaracteres(frase);
            Console.WriteLine(resultado);

            //-------------------------- Se obtiene la frase invertida
            string invertido = InvertirFrase(frase);
            Console.WriteLine(invertido);

            //-------------------------- Se obtiene la primera posición donde aparece el número que más veces está en el array
            Console.WriteLine(CaracterMasRepetido(invertido));

            //--- Fin de la ejecución del programa
        }

        public static bool FraseValida(string frase)
        {
            if (frase.Length >= 20 && frase.Length <= 25)
            {
                Console.WriteLine("frase valida");
                return true;
            }

            return false;
        }

        public static string ContarCaracteres(string frase)
        {
            
  


           
            int mayusculas = 0;
            int minusculas = 0;
            int numeros = 0;
            //------recorremos cada caracter de la string con el foreach 
            foreach (char caracter in frase)
            {
                            //------usamos las funciones isUpper(), IsLower() y IsDigit() en el caracter para verificar si era mayuscula, minuscula o numero.
                if (char.IsUpper(caracter)) //------despues de verificarlo incrementamos el contador del correspondiente.
                {
                    mayusculas++;
                }
                else if (char.IsLower(caracter))
                {
                    minusculas++;
                }
                else if (char.IsDigit(caracter))
                {
                    numeros++;
                }
            }

            return "La frase contiene " + mayusculas + " letras mayúsculas, " + minusculas + " letras minúsculas y " + numeros + " números.";
        }

        public static string InvertirFrase(string frase)
        {
            char[] caracteres = frase.ToCharArray();
            int tamaño = frase.Length;
            string invertido = "";

            for (int i = tamaño - 1; i >= 0; i--)
            {
                invertido += caracteres[i];
            }

            return invertido;
        }

        public static string CaracterMasRepetido(string frase)
        {
            char[] arrLetras = new char[frase.Length];
            int[] arrContadorLetras = new int[frase.Length];
            int posicion = 0;
            int contador = 0;

            // Recorrer la frase para contar la frecuencia de cada carácter
            for (int i = 0; i < frase.Length; i++)
            {
                char letra = frase[i];
                bool encontrado = false;

                // Comprobar si el carácter ya ha sido contado previamente
                for (int j = 0; j < posicion; j++)
                {
                    if (arrLetras[j] == letra)
                    {
                        arrContadorLetras[j]++;
                        encontrado = true;
                        break;
                    }
                }

                // Si el carácter no ha sido contado previamente, añadirlo al array y establecer contador a 1
                if (!encontrado)
                {
                    arrLetras[posicion] = letra;
                    arrContadorLetras[posicion] = 1;
                    posicion++;
                }
            }

            // Encontrar el carácter más repetido
            int maxContador = 0;
            char maxCaracter = '\0';

            for (int i = 0; i < posicion; i++)
            {
                if (arrContadorLetras[i] > maxContador)
                {
                    maxContador = arrContadorLetras[i];
                    maxCaracter = arrLetras[i];
                }
            }

            if (maxContador > 1)
            {
                return "El valor '" + maxCaracter + "' se repite " + maxContador + " veces.";
            }
            else
            {
                return "Todos los caracteres de la frase aparecen por igual.";
            }
        }
    }
}
