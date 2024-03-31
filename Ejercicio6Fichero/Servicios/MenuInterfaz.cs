using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6Fichero.Servicios
{
    /// <summary>
    /// Interfaz de los menus de la aplicacion
    /// irodhan -> 22/03/2024
    /// </summary>
    internal interface MenuInterfaz
    {
        /// <summary>
        /// Metodo que muestra el menu y obtiene la opcion deseada por el usuario
        /// irodhan -> 22/03/2024
        /// </summary>
        /// <returns>Devuelve la opcion deseada por el usuario</returns>
        public int mostrarMenuYSeleccion();
    }
}
