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
    public partial class NotasPedido : Form
    {
        public NotasPedido()
        {
            InitializeComponent();
        }

        private void refreshGridProd()
        {
            dataGridView2.DataSource = ADO_Productos.CargarProductos();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void refreshGridItems()
        {
            dataGridView1.DataSource = ADO_Item_NotaPedidos.CargarItems();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns["NroPedido"].Visible = false;
            dataGridView1.Columns["CodProducto"].ReadOnly = true;
        }

        private void NotasPedido_Load(object sender, EventArgs e)
        {
            refreshGridProd();
            /*int idCabecera = ADO_Cabecera_NotasPedidos.AgregarCabecera();
            Cabecera_NotaPedidos cabecera = new Cabecera_NotaPedidos(idCabecera);
            txtPedido.Text = "NP-00"+cabecera.NroPedido.ToString();*/
            txtFecha.Text = DateTime.Today.ToShortDateString();
            refreshGridItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Selected)
            {
                DataGridViewRow r = dataGridView2.CurrentRow;
                //int nroPedido = Convert.ToInt32(txtPedido.Text.Substring(5));
                Item_NotaPedidos item = new Item_NotaPedidos(0, Convert.ToInt32(r.Cells["CodProducto"].Value), 1);
                ADO_Item_NotaPedidos.Agregar(item);
                refreshGridItems();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Selected)
            {
                DataGridViewRow r = dataGridView2.CurrentRow;
                ADO_Item_NotaPedidos.Eliminar(Convert.ToInt32(r.Cells["CodProducto"].Value));
                refreshGridItems();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                ADO_Item_NotaPedidos.GrabarNotaPedido(comboBox1.SelectedItem.ToString());
                refreshGridItems();
                refreshGridProd();
            }
            else
                MessageBox.Show("Debe seleccionar un cliente");
        }
    }
}
