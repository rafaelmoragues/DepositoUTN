using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deposito
{
    public class Item_NotaPedidos
    {
        int nroPedido;
        public int NroPedido
        {
            get { return nroPedido; }
            set { nroPedido = value; }
        }

        int codProducto;
        public int CodProducto
        {
            get { return codProducto; }
            set { codProducto = value; }
        }

        int cant;
        public int Cant
        {
            get { return cant; }
            set { cant = value; }
        }

        public Item_NotaPedidos(int nroPedido, int codProd, int cant)
        {
            this.nroPedido = nroPedido;
            this.codProducto = codProd;
            this.cant = cant;
        }
    }
}
