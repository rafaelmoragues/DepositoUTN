using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Deposito
{
    static public class ADO_Productos
    {
        //Creo un DataAdapter que se comunica con la base de datos
        static SqlDataAdapter daProductos;
        static DataTable dtProductos;

        static public DataTable CargarProductos(string q="0")
        {
            if (daProductos == null)
                daProductos = new SqlDataAdapter();
            if(q=="0")
                daProductos.SelectCommand = Conexion.Command("SELECT * FROM Productos");
            else
                daProductos.SelectCommand = Conexion.Command(q);
            daProductos.Fill(Conexion.DS, "Productos");// le pongo un alias"alumnos" a la tabla que voy a crear
            DataColumn[] pk = new DataColumn[1];
            //busco dentro del dataset la tabla "alumnos" y dentro la PK que corresponde
            pk[0] = Conexion.DS.Tables["Productos"].Columns["CodProducto"];
            Conexion.DS.Tables["Productos"].PrimaryKey = pk;
            dtProductos = Conexion.DS.Tables["Productos"];//Asigno la tabla a una dt para manejarlo mas simple
            return dtProductos;
        }

        static public void ModificarStock(int id, int nro)
        {
            DataRow row = dtProductos.Rows.Find(id);
            row["StockActual"] = Convert.ToInt32(row["StockActual"]) - nro;
        }

        static public void ActualizarBD()
        {
            Conexion.ActualizarBd(daProductos, dtProductos);
        }
    }
}
