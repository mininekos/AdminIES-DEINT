using AdminIES.DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            
            cicloDLL.Agregar(txtNombreCiclo.Text);
            dgwCiclo.DataSource = cicloDLL.MostrarCiclos().Tables[0];
        }
    }
}
