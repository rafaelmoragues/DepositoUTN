using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Deposito
{
    static public class ADO_Cabecera_NotasPedidos
    {
        //Creo un DataAdapter que se comunica con la base de datos
        //static SqlDataAdapter daProductos;
        //static DataTable dtProductos;

        static public int AgregarCabecera(string cli)
        {
            return Conexion.EjecutarEscalar("INSERT Cabecera_NotaPedido (Fecha, Cliente) VALUES ( GETDATE(), '" + cli + "' ) SELECT @@identity");

        }
    }
}
