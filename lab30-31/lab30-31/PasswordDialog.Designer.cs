namespace Var26_RS
{
    partial class PasswordDialog
    {
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnOk;

        private void InitializeComponent()
        {
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();

            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Location = new System.Drawing.Point(20, 20);

            this.btnOk.Text = "OK";
            this.btnOk.Location = new System.Drawing.Point(20, 60);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            this.Controls.Add(txtPwd);
            this.Controls.Add(btnOk);

            this.ClientSize = new System.Drawing.Size(200, 120);
            this.Text = "Введіть пароль";
        }
    }
}