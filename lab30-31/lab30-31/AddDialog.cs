using System;
using System.Windows.Forms;

namespace Var26_RS
{
    public partial class AddDialog : Form
    {
        public string ElementName => txtName.Text;

        public AddDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Введіть назву!");
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}