using System.Windows.Forms;

namespace Var26_RS
{
    partial class FileViewer
    {
        private System.Windows.Forms.TextBox textBox1;

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();

            this.textBox1.Multiline = true;
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Dock = DockStyle.Fill;

            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(textBox1);
            this.Text = "Вміст файлу";
        }
    }
}