using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deposito
{
    public class Rubros
    {
        int id;
        public int Id
        {
            get { return id; }            set { id = value; }
        }

        string nombre;
        public string Nombre
        {
            get { return nombre; }            set { nombre = value; }
        }

        public Rubros(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
