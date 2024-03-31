using Ejercicio6Fichero.Servicios;

namespace Ejercicio6Fichero.Controladores
{
    /// <summary>
    /// Clase principal de la aplicacion
    /// irodhan -> 22/03/2024
    /// </summary>
    class Program
    {
        static string fichero = "C:\\Users\\ivanr\\OneDrive\\Escritorio\\programacion 23-24\\Fichero\\FicheroPrueba.txt";
        static int numeroLinea = 0;
        static int numeroPosicion = 0;
        static string nuevoTexto = "aaaaa";

        /// <summary>
        /// Metodo principal de la aplicacion
        /// irodhan -> 22/03/2024
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MenuInterfaz mI=new MenuImplementacion();

            int opcionSeleccionada = 0;
            bool cerrarMenu=false;

            while(!cerrarMenu) 
            {
                opcionSeleccionada = mI.mostrarMenuYSeleccion();
                switch ( opcionSeleccionada ) 
                { 
                    case 0:
                        Console.WriteLine("[INFO] -  Ha seleccionado la opcion 0");
                        Console.WriteLine("[INFO] -  La aplicacion va ha cerrarse");
                        cerrarMenu = true;
                        break;
                    case 1:
                        mostrarFichero();
                        Console.WriteLine("[INFO] -  Ha seleccionado la opcion 1");
                        break;
                    case 2:
                        Console.WriteLine("[INFO] -  Ha seleccionado la opcion 2");
                        modificarLinea();
                        break;
                    case 3:
                        insertarLinea();
                        Console.WriteLine("[INFO] -  Ha seleccionado la opcion 3");
                        break;
                    default:
                        Console.WriteLine("[INFO] -  La opcion seleccionada no coincide con ninguna opcion mostrada anteriormente");
                        break;
                }
            }
        }

        static void mostrarFichero() 
        {
            string[] lineas = File.ReadAllLines(fichero);
            foreach (string linea in lineas) 
            { 
                Console.WriteLine(linea);
            }
        }
        /// <summary>
        /// Metodo que modifica la linea indicada por el usuario
        /// irodhan -> 22/03/2024
        /// </summary>
        static void modificarLinea()
        {
            try
            {
                //Pedimos al usuario en que linea desea escribir
                Console.WriteLine("En que linea deseas escribir: ");
                numeroLinea = Convert.ToInt32(Console.ReadLine());

                //Guardamos la informacion de la lista en un array
                string[] lineas = File.ReadAllLines(fichero);

                //Comprobamos que la linea  indicada este dentro del tamaño del array
                if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
                {
                    Console.WriteLine("Que desea escribir: ");
                    nuevoTexto = Console.ReadLine();

                    lineas[numeroLinea - 1] = nuevoTexto;

                    File.WriteAllLines(fichero, lineas);
                }
                else
                {
                    Console.WriteLine("La linea en la que desea escribir esta fuera de rango");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error al leer o escribir en el archivo: " + e.Message);
            }
        }

        /// <summary>
        /// Metodo que inserta nueva informacion en la linea y posicion indicada por el usuario
        /// irodhan -> 22/03/2024
        /// </summary>
        static void insertarLinea()
        {
            try
            {
                //Pedimos al usuario en que linea desea escribir
                Console.WriteLine("Indica la linea deseas escribir: ");
                numeroLinea = Convert.ToInt32(Console.ReadLine());

                //Guardamos la informacion de la lista en un array
                string[] lineas = File.ReadAllLines(fichero);

                //Comprobamos que la linea  indicada este dentro del tamaño del array
                if (numeroLinea >= 1 && numeroLinea < lineas.Length)
                {
                    //Guardamos la linea indicada en un string
                    string linea = lineas[numeroLinea - 1];

                    //Pedimos al usuario la posicion de la linea donde desea escribir
                    Console.WriteLine("Indica la posicion en la que desea añadir texto: ");
                    numeroPosicion = Convert.ToInt32(Console.ReadLine());

                    //Comprobamos que la posicion entre dentro del rango
                    if (numeroPosicion >= 1 && numeroPosicion <= linea.Length)
                    {
                        //Le pedimos al usuario lo que desea escribir en el fichero
                        Console.WriteLine("Que desea escribir: ");
                        nuevoTexto = Console.ReadLine();

                        //Añadimos le texto indicado a la posicion
                        string nuevaLinea = linea.Insert(numeroPosicion, nuevoTexto);

                        //Modificamos la linea con el texto nuevo incluido
                        lineas[numeroLinea - 1] = nuevaLinea;

                        //Sobreescribimos el archivo con la nueva informacion
                        File.WriteAllLines(fichero, lineas);

                    }
                    else
                    {
                        Console.WriteLine("La posicion indicada esta fuera del rango de la linea");
                    }

                }
                else
                {
                    Console.WriteLine("La linea indicada no cioncide con el tamaño del fichero");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("La aplicacion no pudo leer o modificar el fichero " + e.Message);
            }
        }


    }
}
