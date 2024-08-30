using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practocp5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void ConfigurarLabel()
        {
            lblNombre.BackColor = Color.Transparent;
            panel1.Controls.Add(lblNombre);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Crear la fila y agregar los valores de los campos
            int index = dataGridUser.Rows.Add();
            DataGridViewRow row = dataGridUser.Rows[index];




            row.Cells["Apellido"].Value = txtApellido.Text;
            row.Cells["Nombre"].Value = txtNombre.Text;
            row.Cells["Fecha_nacimiento"].Value = dateTimeUser.Value.ToShortDateString();
            row.Cells["Sexo"].Value = rbtnMujer.Checked ? "Mujer" : "Hombre";
            row.Cells["Saldo"].Value = txtSaldo.Text;

            // Verificar si hay una imagen seleccionada, si no cargar la imagen por defecto
            if (pictureUser.Image != null)
            {
                row.Cells["Foto"].Value = pictureUser.Image;
                row.Cells["Ruta"].Value = txtFoto.Text;
            }
            else
            {
                // Ruta de la imagen por defecto
                string defaultImagePath = Path.Combine(Application.StartupPath, "Fotos", "user_7718888.png");
                Image defaultImage = Image.FromFile(defaultImagePath);
                row.Cells["Foto"].Value = Image.FromFile(defaultImagePath);
                row.Cells["Ruta"].Value = defaultImagePath;
            }

            // Agregar un botón "Eliminar"
            DataGridViewButtonCell btnEliminar = new DataGridViewButtonCell();
            btnEliminar.Value = "Eliminar";
            row.Cells["Eliminar"] = btnEliminar;

            if (int.TryParse(txtSaldo.Text, out int saldo) && saldo < 50)
            {
                row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image Files|.jpg;.jpeg;.png;.bmp";
            openFileDialog.Title = "Seleccionar Imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureUser.Image = Image.FromFile(openFileDialog.FileName);
                txtFoto.Text = openFileDialog.FileName;
            }
        }

        private void dataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridUser.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dataGridUser.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void dataGridUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridUser.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridUser.SelectedRows[0];
                string sexo = selectedRow.Cells["Sexo"].Value.ToString();

                if (sexo == "Mujer")
                {
                    rbtnMujer.Checked = true;
                }
                else if (sexo == "Hombre")
                {
                    rbtnHombre.Checked = true;
                }


                if (selectedRow.Cells["Foto"].Value != null)
                {
                    pictureUser.Image = (Image)selectedRow.Cells["Foto"].Value;
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rbtnHombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFoto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
