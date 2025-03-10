﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void gestiónDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente cliente=new frmCliente();
            cliente.MdiParent = this;//Indico que es un hijo
            cliente.Show();
        }

        private void gestiónDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicio servicio=new frmServicio();
            servicio.MdiParent = this; 
            servicio.Show();
        }

        private void listadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListado listado = new frmListado();
            listado.MdiParent=this;
            listado.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
