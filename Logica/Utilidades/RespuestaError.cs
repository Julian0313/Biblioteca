using Dominio.Utilidades;

namespace Logica.Utilidades
{
    public class RespuestaError
    {
        public static Respuesta<T> RespuestaOkay<T>(T datos)
        {
            return new Respuesta<T>()
            {
                CodigoEstado = System.Net.HttpStatusCode.OK,
                Datos = datos,
                Mensaje = "Proceso exitoso"
            };
        }

        public static Respuesta<T> RespuestaSinRegistros<T>(string mensaje)
        {
            return new Respuesta<T>()
            {
                CodigoEstado = System.Net.HttpStatusCode.NoContent,
                Mensaje = mensaje
            };
        }
        public static Respuesta<T> ErrorRespuesta<T>(T datos)
        {
            return new Respuesta<T>()
            {
                CodigoEstado = System.Net.HttpStatusCode.BadRequest,
                Mensaje = "Error en el proceso",
                Datos = datos
            };
        }
        public static Respuesta<T> ErrorIntRespuesta<T>(string mensaje)
        {
            return new Respuesta<T>()
            {
                CodigoEstado = System.Net.HttpStatusCode.BadRequest,
                Mensaje = mensaje
            };
        }
    }
}
