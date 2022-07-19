using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Deposito
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNotasPedido_Click(object sender, EventArgs e)
        {
            NotasPedido formNotasPedidos = new NotasPedido();
            formNotasPedidos.ShowDialog();
        }
    }
}
