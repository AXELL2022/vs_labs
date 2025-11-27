namespace Var26_RS
{
    partial class AuthorDialog
    {
        private System.Windows.Forms.Label lbl;

        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();

            lbl.Text = "Автор: Ясиняцький К.М.\nВаріант: 26";
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(20, 20);

            this.ClientSize = new System.Drawing.Size(250, 120);
            this.Controls.Add(lbl);

            this.Text = "Про автора";
        }
    }
}