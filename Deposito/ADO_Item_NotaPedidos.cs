using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Deposito
{
    static public class ADO_Item_NotaPedidos
    {
        static SqlDataAdapter daItems;
        static public DataTable dtItems;

        static public DataTable CargarItems()
        {
            if (daItems == null)
                daItems = new SqlDataAdapter();

            daItems.SelectCommand = Conexion.Command("SELECT * FROM Items_NotaPedido WHERE 1 > 1"); //Hago una consulta vacía
            daItems.Fill(Conexion.DS, "Items");
            dtItems = Conexion.DS.Tables["Items"];
            return dtItems;
        }

        static public void Agregar(Item_NotaPedidos item)
        {
            DataRow row = dtItems.NewRow();

            row["NroPedido"] = item.NroPedido;
            row["CodProducto"] = item.CodProducto;
            row["Cantidad"] = item.Cant;

            dtItems.Rows.Add(row);
        }

        static public void Eliminar(int id)
        {
            DataRow r = dtItems.Rows.Find(id);
            dtItems.Rows.Remove(r);
        }

        static public void GrabarNotaPedido(string cli)
        {
            int nroPedido = ADO_Cabecera_NotasPedidos.AgregarCabecera(cli);
            foreach (DataRow row in dtItems.Rows)
            {
                row["NroPedido"] = nroPedido.ToString();
                ADO_Productos.ModificarStock(Convert.ToInt32(row["CodProducto"]), Convert.ToInt32(row["Cantidad"]));
            }
            Conexion.ActualizarBd(daItems, dtItems);
            ADO_Productos.ActualizarBD();
        }

    }
}
