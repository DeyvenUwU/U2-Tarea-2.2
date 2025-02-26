using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Winser.objetos;

namespace Winser.conexiones
{
    public class AccesoLibros
    {

        public ArrayList getTodosLosLibros()
        {
            ArrayList libros = new ArrayList();

            String query = "select * from LIBROS";
            ConexionSQL conexion = new ConexionSQL();
            SqlConnection acceso = conexion.getConexion();
            using (acceso)
            {
                try
                {
                    acceso.Open();
                    using (SqlCommand command = new SqlCommand(query, acceso))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Libro libro = new Libro
                                {
                                    id = reader.GetInt32(0),
                                    isbn = reader.GetString(1),
                                    titulo = reader.GetString(2),
                                    autor = reader.GetString(3),
                                    edicion = reader.GetInt32(4),
                                    ano = reader.GetInt32(5),
                                    pais = reader.GetString(6),
                                    sinopsis = reader.GetString(7),
                                    carrera = reader.GetString(8),
                                    materia = reader.GetString(9)
                                };

                                libros.Add(libro);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Ocurrió un error: " + ex.Message);
                }
                finally
                {
                    acceso.Close();
                }

                return libros;
            }
        }

        public void guardarLibro(Libro l)
        {
            string insertQuery = "insert into LIBROS (isbn, titulo, autor, edicion, ano, pais, sinopsis, carrera, materia) values (@v1, @v2, @v3, @v4, @v5, @v6, @v7, @v8, @v9)";
            //string updateQuery = "update LIBROS set isbn = @v1, titulo, autor, edicion, ano, pais, sinopsis, carrera, materia";
            ConexionSQL conexion = new ConexionSQL();
            SqlConnection acceso = conexion.getConexion();
            using (acceso)
            {
                try
                {
                    acceso.Open();
                    using (SqlCommand command = new SqlCommand(insertQuery, acceso))
                    {
                        command.Parameters.AddWithValue("@v1", l.isbn);
                        command.Parameters.AddWithValue("@v2", l.titulo);
                        command.Parameters.AddWithValue("@v3", l.autor);
                        command.Parameters.AddWithValue("@v4", l.edicion);
                        command.Parameters.AddWithValue("@v5", l.ano);
                        command.Parameters.AddWithValue("@v6", l.pais);
                        command.Parameters.AddWithValue("@v7", l.sinopsis);
                        command.Parameters.AddWithValue("@v8", l.carrera);
                        command.Parameters.AddWithValue("@v9", l.materia);

                        int rowsAffected = command.ExecuteNonQuery();
                        Debug.WriteLine($"{rowsAffected} fila(s) insertada(s) correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Ocurrió un error: " + ex.Message);
                }
                finally
                {
                    acceso.Close();
                }
            }
        }

        public void eliminarLibro(int id)
        {
            string query = "delete from LIBROS where id = @v1";
            ConexionSQL conexion = new ConexionSQL();
            SqlConnection acceso = conexion.getConexion();
            using (acceso)
            {
                try
                {
                    acceso.Open();
                    using (SqlCommand command = new SqlCommand(query, acceso))
                    {
                        command.Parameters.AddWithValue("@v1", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        Debug.WriteLine($"{rowsAffected} fila(s) insertada(s) correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Ocurrió un error: " + ex.Message);
                }
                finally
                {
                    acceso.Close();
                }
            }
        }
    }
}