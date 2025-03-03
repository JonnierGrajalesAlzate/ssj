using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class frmListado : Form
    {
        public frmListado()
        {
            InitializeComponent();
        }

        CN_Cliente cliente = new CN_Cliente();
        CN_Servicio servicio = new CN_Servicio();

        private void frmListado_Load(object sender, EventArgs e)
        {

        }

        private void rbtClientes_CheckedChanged(object sender, EventArgs e)
        {
            dgvListado.DataSource = null;
            dgvListado.DataSource = cliente.listarCliente();
        }

        private void rbtServicios_CheckedChanged(object sender, EventArgs e)
        {
            dgvListado.DataSource = null;
            dgvListado.DataSource = servicio.listarServicio();
        }
    }
}
