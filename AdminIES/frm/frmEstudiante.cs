using AdminIES.DLL;
using AdminIES.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminIES.frm
{
    public partial class frmEstudiante : Form
    {
        EstudianteDLL estudianteDLL;
        CicloDLL cicloDLL;
        private byte[] imagaenByte;

        public frmEstudiante()
        {   
            estudianteDLL = new EstudianteDLL();
            cicloDLL= new CicloDLL();
            InitializeComponent();
            mostrarComboBox();
            dgwEstudiante.DataSource = estudianteDLL.MostrarEstudiantes().Tables[0];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            estudianteDLL.Agregar(txtNombre.Text,txtPrimerApellido.Text,txtSegundoApellido.Text, txtCorreo.Text,null);
            estudianteDLL.AgregarEstudianteCiclo(cbCiclo.SelectedValue.ToString());
            dgwEstudiante.DataSource = estudianteDLL.MostrarEstudiantes().Tables[0];
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            estudianteDLL.Modificar(txtClave.Text, txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtCorreo.Text, null);
            dgwEstudiante.DataSource = estudianteDLL.MostrarEstudiantes().Tables[0];
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            estudianteDLL.BorrarEstudianteCiclo(txtClave.Text);
            estudianteDLL.Borrar(txtClave.Text);
            dgwEstudiante.DataSource = estudianteDLL.MostrarEstudiantes().Tables[0];
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = "Imagenes|*.jpg;*.jpeg;*.png";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Seleccionar imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromStream(openFileDialog.OpenFile());
                MemoryStream memoryStream = new MemoryStream();
                pbFoto.Image.Save(memoryStream,System.Drawing.Imaging.ImageFormat.Png);
                imagaenByte = memoryStream.ToArray();
            }
            pbFoto.ImageLocation = filePath;
        }

        private void dgwEstudiante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtClave.Text = dgwEstudiante.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = dgwEstudiante.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPrimerApellido.Text = dgwEstudiante.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSegundoApellido.Text = dgwEstudiante.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCorreo.Text = dgwEstudiante.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        public void mostrarComboBox() { 
            DataTable dt = cicloDLL.MostrarCiclos().Tables[0];

            this.cbCiclo.ValueMember = "Id";
            this.cbCiclo.DisplayMember = "Nombre";
            this.cbCiclo.DataSource = dt;
        }
    }
}
