using AccesodeDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LogicadeNegocio
{
    // Clase que contiene la lógica de negocios para los estudiantes
    public class LogicaNegocio
    {
        // Creamos una instancia de la clase DBEstudiantes que se encargará de interactuar con la base de datos
        private DBEstudiantes estudianteDB = new DBEstudiantes();
        // Método para agregar un estudiante, que valida los datos antes de insertarlos
        public void AgregarEstudiante(string nombre, string apellido, DateTime fechaNacimiento, string nivelEstudio)
        {
            // Validamos que los datos no sean nulos o vacíos y que la fecha de nacimiento sea válida
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido) && fechaNacimiento < DateTime.Now)
            {
                // Si la validación es correcta, llamamos al método DAL para agregar el estudiante
                estudianteDB.AgregarEstudiantes(nombre, apellido, fechaNacimiento, nivelEstudio);
            }
            else
            {
                // Si hay un error en la validación, lanzamos una excepción con un mensaje
                throw new Exception("Los datos del estudiante son inválidos");
            }
        }
        // Método para obtener la lista de estudiantes desde la base de datos
        public SqlDataReader ObtenerEstudiantes() 
        {
            // Llamamos al método para obtener los estudiantes
            return estudianteDB.ObtenerEstudiantes();
        }
    }
}
