using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSystem
{
    public class CN_Articulo
    {
        List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=LAPTOP-O826RRH4\\SQLEXPRESS; database=Stock; integrated security=true";
                comando.CommandType= System.Data.CommandType.Text;
                comando.CommandText = "select Codigo,Descripcion,Imagen from Imagenes";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read()){
                    Articulos aux = new Articulos();
                    aux.Codigo = (int)lector["Codigo"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Imagen = (string)lector["Imagen"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
