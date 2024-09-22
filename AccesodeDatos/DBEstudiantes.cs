// Importamos los espacios de nombres necesarios para trabajar con SQL y configuraciones
using System;
using System.Data.SqlClient;
using System.Configuration; // Para obtener la cadena de conexión desde la configuración de la aplicación

namespace AccesodeDatos
{
    // Clase que maneja las operaciones relacionadas con los estudiantes en la base de datos
    public class DBEstudiantes
    {
        // Cadena de conexión obtenida desde el archivo de configuración de la aplicación (app.config)
        // Aquí usamos Properties.Settings.Default para obtener la cadena de conexión guardada en las propiedades del proyecto
        string conexion = Properties.Settings.Default.MiCadena;
        // Método para agregar un estudiante a la base de datos
        public void AgregarEstudiantes(string nombre, string apellido, DateTime fechaNacimiento, string nivelEstudio)
        {
            // Creamos una conexión a la base de datos usando la cadena de conexión obtenida
            using (SqlConnection conectar = new SqlConnection(conexion))
            {
                // Abrimos la conexión con la base de datos
                conectar.Open();
                // Definimos la consulta SQL para insertar un nuevo estudiante en la tabla Estudiantes
                string query = "INSERT INTO ESTUDIANTES (Nombre, Apellido, FechaNacimiento,NivelEstudio) " +
                    "VALUES (@Nombre, @Apellido, @FechaNacimiento, @NivelEstudio)";
                // Creamos un comando SQL utilizando la consulta anterior y la conexión
                SqlCommand cmd = new SqlCommand(query, conectar);
                // Añadimos los parámetros para la consulta. Estos valores son los que se pasaron al método.
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@NivelEstudio", nivelEstudio);
                // Ejecutamos la consulta para insertar el estudiante en la base de datos
                cmd.ExecuteNonQuery();
            }// El bloque "using" cierra la conexión automáticamente al salir del bloque
        }
        // Método para obtener la lista de estudiantes de la base de datos
        public SqlDataReader ObtenerEstudiantes()
        {
            // Creamos una nueva conexión a la base de datos
            SqlConnection conectar = new SqlConnection(conexion);
            // Abrimos la conexión
            conectar.Open();
            // Definimos la consulta SQL para seleccionar todos los estudiantes
            string query = "SELECT * FROM ESTUDIANTES";
            // Creamos un comando SQL utilizando la consulta anterior y la conexión
            SqlCommand cmd = new SqlCommand(query, conectar);
            // Ejecutamos la consulta y devolvemos un objeto SqlDataReader que contiene los resultados
            return cmd.ExecuteReader();
        }
    }
}