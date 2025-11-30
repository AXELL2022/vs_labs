using System.Windows.Forms;

namespace Lab32_33
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox mainTextBox;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mainTextBox = new System.Windows.Forms.TextBox();

            // MenuStrip
            ToolStripMenuItem mainMenu = new ToolStripMenuItem("&Головне");
            mainMenu.DropDownItems.Add("&Реєстрація");
            mainMenu.DropDownItems.Add(new ToolStripSeparator());
            mainMenu.DropDownItems.Add("&Вихід");

            ToolStripMenuItem dialogMenu = new ToolStripMenuItem("&Діалоги");
            dialogMenu.DropDownItems.Add("&Вибір кольору");
            dialogMenu.DropDownItems.Add("&Попередній перегляд");
            dialogMenu.DropDownItems.Add("&Відкриття файлу");
            dialogMenu.DropDownItems.Add("&Друк");

            ToolStripMenuItem additionalMenu = new ToolStripMenuItem("&Додатково");
            additionalMenu.DropDownItems.Add("&Про розробника");
            additionalMenu.DropDownItems.Add("&Word");
            additionalMenu.DropDownItems.Add("В&иконати");

            this.menuStrip1.Items.AddRange(new ToolStripMenuItem[] { mainMenu, dialogMenu, additionalMenu });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // ToolStrip
            this.toolStrip1.Items.Add(new ToolStripButton("Колір") { ToolTipText = "Вибір кольору", Enabled = false });
            this.toolStrip1.Items.Add(new ToolStripButton("Перегляд") { ToolTipText = "Попередній перегляд", Enabled = false });
            this.toolStrip1.Items.Add(new ToolStripButton("Відкрити") { ToolTipText = "Відкриття файлу", Enabled = false });
            this.toolStrip1.Items.Add(new ToolStripButton("Друк") { ToolTipText = "Друк", Enabled = false });
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";

            // StatusStrip
            this.statusStrip1.Items.Add(new ToolStripStatusLabel("Користувач: не авторизований"));
            this.statusStrip1.Items.Add(new ToolStripSeparator());
            var dateLabel = new ToolStripStatusLabel(System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
            dateLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusStrip1.Items.Add(dateLabel);
            this.statusStrip1.Location = new System.Drawing.Point(0, 560);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 40);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";

            // TextBox
            this.mainTextBox.Location = new System.Drawing.Point(20, 60);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ReadOnly = true;
            this.mainTextBox.Size = new System.Drawing.Size(750, 490);
            this.mainTextBox.TabIndex = 3;

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.mainTextBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Стандартні діалоги";
            this.Load += new System.EventHandler(this.Form1_Load);

            // Отримуємо LabelsStatus
            userStatusLabel = this.statusStrip1.Items[0] as ToolStripStatusLabel;
            dateStatusLabel = this.statusStrip1.Items[2] as ToolStripStatusLabel;
        }
    }
}