using System;
using System.Windows.Forms;

namespace Var26_RS
{
    public partial class PasswordDialog : Form
    {
        public string Password => txtPwd.Text;

        public PasswordDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}