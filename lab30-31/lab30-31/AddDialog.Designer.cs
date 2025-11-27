namespace Var26_RS
{
    partial class AddDialog
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbl;

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();

            this.lbl.Text = "Назва виробника:";
            this.lbl.Location = new System.Drawing.Point(20, 10);

            this.txtName.Location = new System.Drawing.Point(20, 40);
            this.txtName.Width = 200;

            this.btnOk.Text = "OK";
            this.btnOk.Location = new System.Drawing.Point(20, 80);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            this.ClientSize = new System.Drawing.Size(260, 140);
            this.Controls.Add(lbl);
            this.Controls.Add(txtName);
            this.Controls.Add(btnOk);
            this.Text = "Додати елемент";
        }
    }
}