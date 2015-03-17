using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviaNomina
{
    public class Peticion
    {
        /// <summary>
        /// Establece o devuelve la respuesta del servidor.
        /// </summary>
        public string Respuesta { get; set; }

        /// <summary>
        /// Establece o devuelve el estado de la validación del objeto.
        /// </summary>
        public Validacion Validacion { get; set; }


        public Peticion(string datos, string url)
        {
            // Se asignan los datos de consulta
            string respuestaLlamada = null;
            byte[] buffer = Encoding.UTF8.GetBytes(datos);
            System.Net.WebRequest WebRequest = System.Net.WebRequest.Create(url);
            WebRequest.Method = "POST";
            WebRequest.ContentType = "application/x-www-form-urlencoded";
            WebRequest.ContentLength = buffer.Length;
            WebRequest.Timeout = Settings.App.Default.timeout;

            try
            {
                // Se crea el post y se leen los datos de respuesta
                System.IO.Stream DatosPost = WebRequest.GetRequestStream();
                DatosPost.Write(buffer, 0, buffer.Length);
                DatosPost.Close();
                System.Net.WebResponse WebResponse = WebRequest.GetResponse();
                System.IO.Stream resultado = WebResponse.GetResponseStream();

                System.IO.StreamReader lecturaResultado = new System.IO.StreamReader(resultado);
                respuestaLlamada = lecturaResultado.ReadToEnd();

                //Log.set.Debug("Respuesta: " + respuestaLlamada);

                // Creamos un tipo anónimo para leer la validacion de respuesta del servidor.
                var validacionRespuesta = new { Exito = "1", Mensaje = string.Empty };

                // Si el servidor no devuelve validación de respuesta
                // esta simplemente se establecerá como correcta.
                try
                {
                    // Deserializamos la respuesta de validacion del servidor.
                    try
                    {
                        validacionRespuesta = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(respuestaLlamada, validacionRespuesta);
                        //Log.set.Debug("Se asigna la validacion de la respuesta: " + Newtonsoft.Json.JsonConvert.SerializeObject(validacionRespuesta));
                    }
                    catch
                    {
                        if (!string.IsNullOrEmpty(validacionRespuesta.Mensaje))
                        {
                            //Log.set.Fatal("Ocurrio excepcion: " + validacionRespuesta.Mensaje);
                            throw new Exception(validacionRespuesta.Mensaje);
                        }
                    }

                    if (validacionRespuesta.Exito != "0")
                    {
                        //Log.set.Debug("La operacion fue realizada con exito.");
                        // Se asigna la validación como satisfactoria.
                        Validacion = new Validacion(true, "Operación realizada con éxito.");

                        // Se establece la respuesta de la llamada.
                        Respuesta = respuestaLlamada;
                    }
                    else
                    {
                        //Log.set.Error("La operacion tuvo un error: " + validacionRespuesta.Mensaje);
                        // Se establece el resultado de la validación del servidor.
                        this.Validacion = new Validacion(false, validacionRespuesta.Mensaje);
                    }
                }
                catch (Exception ex)
                {
                    //Log.set.Fatal("Ocurrio excepcion: " + ex.Message);

                    // Se asigna la validación como satisfactoria.
                    Validacion = new Validacion(false, ex.Message, ex.StackTrace);

                    // Se establece la respuesta de la llamada.
                    Respuesta = respuestaLlamada;
                }
            }
            catch (Exception ex)
            {
                //Log.set.Fatal("Ocurrio excepcion: " + ex.Message);

                // Se establece el error de la validación.
                Validacion = new Validacion(
                    false, "El tiempo de espera para solicitud se ha excedido.", ex.Message);
            }
        }
    }
}
