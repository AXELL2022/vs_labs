namespace Var26_RS
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnAdd, btnSave, btnShowFile, btnExit, btnAuthor, btnCalendar, btnCalc;
        private System.Windows.Forms.Label lblList, lblCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowFile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAuthor = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.lblList = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(20, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(250, 147);
            this.listBox1.TabIndex = 2;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(126, 200);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(144, 20);
            this.txtCount.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(300, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Додати";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 80);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Записати у файл";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShowFile
            // 
            this.btnShowFile.Location = new System.Drawing.Point(300, 120);
            this.btnShowFile.Name = "btnShowFile";
            this.btnShowFile.Size = new System.Drawing.Size(83, 23);
            this.btnShowFile.TabIndex = 6;
            this.btnShowFile.Text = "Показати файл";
            this.btnShowFile.Click += new System.EventHandler(this.btnShowFile_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(300, 280);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Вихід";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAuthor
            // 
            this.btnAuthor.Location = new System.Drawing.Point(300, 160);
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(83, 23);
            this.btnAuthor.TabIndex = 7;
            this.btnAuthor.Text = "Про автора";
            this.btnAuthor.Click += new System.EventHandler(this.btnAuthor_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.Location = new System.Drawing.Point(300, 200);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(83, 23);
            this.btnCalendar.TabIndex = 8;
            this.btnCalendar.Text = "Календар";
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(300, 240);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(83, 23);
            this.btnCalc.TabIndex = 9;
            this.btnCalc.Text = "Калькулятор";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // lblList
            // 
            this.lblList.Location = new System.Drawing.Point(17, 9);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(161, 23);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "Список РС:";
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(20, 200);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(100, 23);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Кількість:";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowFile);
            this.Controls.Add(this.btnAuthor);
            this.Controls.Add(this.btnCalendar);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnExit);
            this.Name = "MainForm";
            this.Text = "РС. Варіант 26 (.NET 4.8)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
