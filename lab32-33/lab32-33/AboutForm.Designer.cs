namespace Lab32_33
{
    partial class AboutForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblInfo
            this.lblInfo.AutoSize = false;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.Location = new System.Drawing.Point(20, 30);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(350, 200);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Студент: Ясиняцький К.М. \r\nГрупа: БІКСб22440д\r\nСпеціальність: Кібербезпека\r\n\r\nЛабораторна робота №32-33\r\nВаріант 6\r\n\r\nТема: Створення меню різних типів,\r\nрядка стану та панелі швидкого вибору пунктів меню";

            // btnClose
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(310, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // AboutForm
            this.AcceptButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.ControlBox = true;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Про розробника";
            this.ResumeLayout(false);
        }
    }
}
