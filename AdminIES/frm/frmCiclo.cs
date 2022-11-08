using AdminIES.DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminIES.frm
{
    public partial class frmCiclo : Form
    {
        CicloDLL cicloDLL;
        public frmCiclo()
        {
            cicloDLL = new CicloDLL();
            InitializeComponent();
            dgwCiclo.DataSource = cicloDLL.MostrarCiclos().Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtNombreCiclo.Text,@"^\S"))
            {
                cicloDLL.Agregar(txtNombreCiclo.Text);
                dgwCiclo.DataSource = cicloDLL.MostrarCiclos().Tables[0];
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            cicloDLL.Borrar(txtID.Text);
            dgwCiclo.DataSource = cicloDLL.MostrarCiclos().Tables[0];
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cicloDLL.Modificar(txtNombreCiclo.Text,txtID.Text);
            dgwCiclo.DataSource = cicloDLL.MostrarCiclos().Tables[0];
        }

        private void dgwCiclo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) { 
                txtID.Text = dgwCiclo.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
