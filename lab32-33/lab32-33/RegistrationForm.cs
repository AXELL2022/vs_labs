using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab32_33
{
    public partial class RegistrationForm : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUsername != null && txtPassword != null &&
                txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                Username = txtUsername.Text;
                Password = txtPassword.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Будь ласка, заповніть всі поля", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}