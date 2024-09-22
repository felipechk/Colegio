# Ejercicio Colegio
TABLA SQL:

CREATE DATABASE EscuelaDB;
GO

USE EscuelaDB;

CREATE TABLE Estudiantes (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Apellido NVARCHAR(100),
    FechaNacimiento DATE,
    NivelEstudio NVARCHAR(50)
);
