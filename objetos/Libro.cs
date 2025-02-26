using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Winser.objetos
{
	public class Libro
	{
        public int id { get; set; }
        public String isbn { get; set; }
        public String titulo { get; set; }
        public String autor { get; set; }
        public int edicion { get; set; }
        public int ano { get; set; }
        public String pais { get; set; }
        public String sinopsis { get; set; }
        public String carrera { get; set; }
        public String materia { get; set; }

        public Libro()
        {

        }
        public override string ToString()
        {
            return $"ID: {id}, ISBN: {isbn}, Título: {titulo}, Autor: {autor}, Edición: {edicion}, Año: {ano}, País: {pais}, Sinopsis: {sinopsis}, Carrera: {carrera}, Materia: {materia}";
        }
    }
}