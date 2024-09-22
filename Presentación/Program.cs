using System;
using LogicadeNegocio;


namespace Presentación
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creamos una instancia de la capa lógica de negocios
            LogicaNegocio logica = new LogicaNegocio();
            // Llamamos al método para agregar un estudiante, pasando los datos como argumentos
            logica.AgregarEstudiante("Pedro","Jara",new DateTime(1992,4,2),"Media");
            logica.AgregarEstudiante("Juan", "Jara", new DateTime(1992, 4, 2), "Media");
            logica.AgregarEstudiante("Diego", "Jara", new DateTime(1992, 4, 2), "Media");
            // Obtenemos la lista de estudiantes usando el método ObtenerEstudiantes
            var lista = logica.ObtenerEstudiantes();
            // Mostramos la lista de estudiantes en la consola
            Console.WriteLine("Lista de estudiantes: ");
            while (lista.Read())// Recorremos cada fila obtenida de la consulta
            {
                // Mostramos los datos del estudiante
                Console.WriteLine($"Nombre: {lista["Nombre"]}, Apellido: {lista["Apellido"]}, Fecha de Nacimiento: {lista["FechaNacimiento"]}, Nivel de Estudio: {lista["NivelEstudio"]}");
            }
            lista.Close(); // Cerramos el lector de datos
        }
    }
}
