using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Deposito
{
    static class Conexion
    {
        static DataSet ds = new DataSet();
        static SqlConnection cn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Deposito;Integrated Security=True;");

        static public DataSet DS
        {
            get { return ds; }
        }

        static private void Conectar()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error de conexión" + ex.Message);
            }
        }
        static private void Desconectar()
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            catch
            {
                throw new Exception("La base ya está cerrada");
            }
        }


        static public SqlCommand Command(string cmdtext)
        {
            SqlCommand cmd = new SqlCommand(cmdtext, cn);
            return cmd;
        }

        static public int EjecutarEscalar(string q)
        {
            Conectar();
            int id = Convert.ToInt32(Command(q).ExecuteScalar());
            Desconectar();
            return id;
        }

        static public void ActualizarBd(SqlDataAdapter da, DataTable dt)
        {
            /*Sqlcommandbuilder toma el select del dataadapter cuando solo esa sentencia 
             sea de recuperacion de datos y no de calculo y referncie a una unica tabla
             */
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
            DataTable dtChanged = dt.GetChanges();//filtro en una nueva tabla las filas modificadas
            da.Update(dtChanged);
            dt.AcceptChanges();//le cambia el estado a todas las filas, y las que tenias estado borrado las borra
        }

        static public void GrabarNotaPedido(string cli){
            SqlCommand cmd=new SqlCommand();
	        cmd.CommandText="PR_CabeceraNP";
	        cmd.Connection=cn;
            cmd.CommandType = CommandType.StoredProcedure;
	        cmd.Parameters.AddWithValue("@cliente",cli);
	        Conectar();
	        cmd.ExecuteNonQuery();
            Desconectar();
        }
    }
}
