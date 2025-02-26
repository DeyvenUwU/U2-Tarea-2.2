using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Winser.conexiones;
using Winser.objetos;

namespace Winser
{
	public partial class _default : System.Web.UI.Page
	{
		private AccesoLibros libros;
		private ArrayList librosData;
        protected void Page_Load(object sender, EventArgs e)
		{
			libros = new AccesoLibros();
			librosData = libros.getTodosLosLibros();

            foreach (Libro libro in librosData)
            {
                HtmlTableRow row = new HtmlTableRow();

                HtmlTableCell cellId = new HtmlTableCell();
                cellId.InnerText = libro.id.ToString();
                row.Cells.Add(cellId);

                HtmlTableCell cellIsbn = new HtmlTableCell();
                cellIsbn.InnerText = libro.isbn;
                row.Cells.Add(cellIsbn);

                HtmlTableCell cellTitulo = new HtmlTableCell();
                cellTitulo.InnerText = libro.titulo;
                row.Cells.Add(cellTitulo);

                HtmlTableCell cellAutor = new HtmlTableCell();
                cellAutor.InnerText = libro.autor;
                row.Cells.Add(cellAutor);

                HtmlTableCell cellEdicion = new HtmlTableCell();
                cellEdicion.InnerText = libro.edicion.ToString();
                row.Cells.Add(cellEdicion);

                HtmlTableCell cellEdit = new HtmlTableCell();
                Button btnEditar = new Button();
                btnEditar.Text = "Ver";
                btnEditar.CommandArgument = libro.id.ToString();  // Asigna el ID del libro al CommandArgument
                btnEditar.Command += new CommandEventHandler(btnEditar_Command);  // Asocia el evento
                cellEdit.Controls.Add(btnEditar);
                row.Cells.Add(cellEdit);

                HtmlTableCell cellDelete = new HtmlTableCell();
                Button btnEliminar = new Button();
                btnEliminar.Text = "Eliminar";
                btnEliminar.CommandArgument = libro.id.ToString();  // Asigna el ID del libro al CommandArgument
                btnEliminar.Command += new CommandEventHandler(btnEliminar_Command);  // Asocia el evento
                cellDelete.Controls.Add(btnEliminar);
                row.Cells.Add(cellDelete);

                tablaLibros.Rows.Add(row);
            }
        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            String errores = "";

            String isbnS = isbn.Text;
            if (isbnS.Length == 0)
                errores += "El ISBN no puede estar vacio\n";
            if (isbnS.Length > 45)
                errores += "El ISBN no puede tener mas de 45 caracteres\n";

            String tituloS = titulo.Text;
            if (tituloS.Length == 0)
                errores += "El Título no puede estar vacio\n";
            if (tituloS.Length > 45)
                errores += "El Título no puede tener mas de 45 caracteres\n";

            String autorS = autor.Text;
            if (autorS.Length == 0)
                errores += "El Autor no puede estar vacio\n";
            if (autorS.Length > 45)
                errores += "El Autor no puede tener mas de 45 caracteres\n";

            String edicionI = edicion.Text;
            if (edicionI.Length > 0)
            {
                if (int.Parse(edicionI) < 0)
                    errores += "La Edición no puede ser negativa\n";
                if (int.Parse(edicionI) > 1000)
                    errores += "La Edición no puede ser mayor a 1000\n";
            }
            else
            {
                errores += "La Edición no puede estar vacio\n";
            }

                String anoI = ano.Text;
            if (anoI.Length > 0)
            {
                if (int.Parse(anoI) < 0)
                    errores += "El Año no puede ser negativo\n";
                if (int.Parse(anoI) > 2025)
                    errores += "El Año no puede ser mayor a 2025\n";
            }
            else
            {
                errores += "El Año no puede estar vacio\n";
            }

                String paisS = pais.Text;
            if (paisS.Length == 0)
                errores += "El País no puede estar vacio\n";
            if (paisS.Length > 45)
                errores += "El País no puede tener mas de 45 caracteres\n";

            String sinopsisS = sinopsis.Value;
            if (sinopsisS.Length == 0)
                errores += "La Sinopsis no puede estar vacio\n";
            if (sinopsisS.Length > 45)
                errores += "La Sinopsis no puede tener mas de 45 caracteres\n";

            String carreraS = carrera.Text;
            if (carreraS.Length == 0)
                errores += "La Carrera no puede estar vacio\n";
            if (carreraS.Length > 45)
                errores += "La Carrera no puede tener mas de 45 caracteres\n";

            String materiaS = materia.Text;
            if (materiaS.Length == 0)
                errores += "La Materia no puede estar vacio\n";
            if (materiaS.Length > 45)
                errores += "La Materia no puede tener mas de 45 caracteres\n";

            if (!errores.Equals(""))
            {
                string script = "alert('" + errores.Replace("'", "\\'").Replace("\n", "\\n") + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", script, true);
            }
            else
            {
                Libro nuevo = new Libro();
                nuevo.isbn = isbn.Text;
                nuevo.titulo = titulo.Text;
                nuevo.autor = autor.Text;
                nuevo.edicion = int.Parse(edicion.Text);
                nuevo.ano = int.Parse(ano.Text);
                nuevo.pais = pais.Text;
                nuevo.sinopsis = sinopsis.Value;
                nuevo.carrera = carrera.Text;
                nuevo.materia = materia.Text;

                libros.guardarLibro(nuevo);
                librosData = libros.getTodosLosLibros();
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Libro nuevo = new Libro();
            foreach (Libro libro in librosData)
            {
                if (libro.id == id)
                {
                    nuevo = libro;
                    break;
                }
            }
            isbn.Text = nuevo.isbn;
            titulo.Text = nuevo.titulo;
            autor.Text = nuevo.autor;
            edicion.Text = nuevo.edicion.ToString();
            ano.Text = nuevo.ano.ToString();
            pais.Text = nuevo.pais;
            sinopsis.Value = nuevo.sinopsis;
            carrera.Text = nuevo.carrera;
            materia.Text = nuevo.materia;
            //libros.guardarLibro(nuevo);
            //librosData = libros.getTodosLosLibros();
            //Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            libros.eliminarLibro(id);
            librosData = libros.getTodosLosLibros();
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}