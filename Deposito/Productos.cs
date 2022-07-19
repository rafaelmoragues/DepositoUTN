using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deposito
{
    public class Productos
    {
        int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        int stock;
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        int rubro;
        public int Rubro
        {
            get { return rubro; }
            set { rubro = value; }
        }

        /*Rubros rubro;
        public Rubros Rubro
        {
            get { return rubro; }
            set { rubro = value; }
        }

        public Productos(int codigo, string nombre, int stock, Rubros rubro)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.stock = stock;
            this.rubro = rubro;
        }*/
        
        public Productos(int codigo, string nombre, int stock, int idRubro)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.stock = stock;
            this.rubro = idRubro;
        }
    }
}
