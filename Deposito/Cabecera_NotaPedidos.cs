using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deposito
{
    public class Cabecera_NotaPedidos
    {
        int nroPedido;
        public int NroPedido
        {
            get { return nroPedido; }            set { nroPedido = value; }
        }

        string cliente;
        public string Cliente
        {
            get { return cliente; }            set { cliente = value; }
        }

        DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }            set { fecha = value; }
        }

        public Cabecera_NotaPedidos(int nro) 
        {
            this.nroPedido = nro;
            this.fecha = DateTime.Today;
        }
    }
}
