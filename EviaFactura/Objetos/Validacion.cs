using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviaNomina
{
    /// <summary>
    /// Esta clase proporciona propiedades para distinguir el estatus
    /// de las operaciones de consulta y reportes de comprobantes.
    /// </summary>
    public class Validacion
    {
        /// <summary>
        /// Establece o devuelve el tipo de error de la operación.
        /// </summary>
        public bool Valido { get; set; }

        /// <summary>
        /// Establece o devuelve el mensaje devuelto de la operación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Establece o devuelve el detalle de la operación.
        /// </summary>
        public string Detalle { get; set; }

        /// <summary>
        /// Inicializa el objeto estatus con los valores especificados.
        /// </summary>
        /// <param name="valido">Tipo de estatus de la operación.</param>
        /// <param name="mensaje">Mensaje devuelto de la operación.</param>
        public Validacion(bool valido, string mensaje)
        {
            this.Valido = valido;
            this.Mensaje = mensaje;
        }

        /// <summary>
        /// Inicializa el objeto estatus con los valores especificados.
        /// </summary>
        /// <param name="valido">Tipo de estatus de la operación.</param>
        /// <param name="mensaje">Mensaje devuelto de la operación.</param>
        /// <param name="detalle">Detalle de la operación.</param>
        public Validacion(bool valido, string mensaje, string detalle)
        {
            this.Valido = valido;
            this.Mensaje = mensaje;
            this.Detalle = detalle;
        }
    }
}
