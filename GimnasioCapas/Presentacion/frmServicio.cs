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
    public partial class frmServicio : Form
    {
        public frmServicio()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                objCN.insertarCliente(
                    int.Parse(txtCodigo.Text), cboServicio.Text,
                    cboEstado.Text
                );
                MessageBox.Show("Se ha registrado el servicio", "Gimnasio SportGym", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        CN_Servicio objCN = new CN_Servicio();


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                objCN.actualizarCliente(
                    int.Parse(txtCodigo.Text), cboServicio.Text,
                    cboEstado.Text
                );
                MessageBox.Show("Se ha actualizado el servicio", "Gimnasio SportGym", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                objCN.buscarCliente(
                    int.Parse(txtCodigo.Text)
                );
                if (objCN.encontro)
                {
                    txtCodigo.Text = objCN.codigo.ToString();
                    cboServicio.Text = objCN.tipo.ToString();
                    cboEstado.Text = objCN.estado.ToString();
                }
                else
                {
                    MessageBox.Show("El servicio no esta registrado", "Gimnasio SportGym", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Gimnasio SportGym", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                objCN.eliminarCliente(
                    int.Parse(txtCodigo.Text)
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Gimnasio SportGym", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
