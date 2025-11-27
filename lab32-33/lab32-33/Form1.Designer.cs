namespace Lab32_33_Variant6
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRegistration = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDialogs = new System.Windows.Forms.ToolStripMenuItem();
            this.itemColorDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdditional = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.itemWord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnColor = new System.Windows.Forms.ToolStripButton();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxColor = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMain,
            this.menuDialogs,
            this.menuAdditional});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuMain
            // 
            this.menuMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemRegistration,
            this.itemExit});
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(67, 20);
            this.menuMain.Text = "&Головне";
            // 
            // itemRegistration
            // 
            this.itemRegistration.Name = "itemRegistration";
            this.itemRegistration.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.itemRegistration.Size = new System.Drawing.Size(187, 22);
            this.itemRegistration.Text = "&Реєстрація";
            this.itemRegistration.Click += new System.EventHandler(this.itemRegistration_Click);
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.itemExit.Size = new System.Drawing.Size(187, 22);
            this.itemExit.Text = "&Вихід";
            this.itemExit.Click += new System.EventHandler(this.itemExit_Click);
            // 
            // menuDialogs
            // 
            this.menuDialogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemColorDialog,
            this.itemPrintPreview,
            this.itemOpenFile,
            this.itemPrint});
            this.menuDialogs.Name = "menuDialogs";
            this.menuDialogs.Size = new System.Drawing.Size(62, 20);
            this.menuDialogs.Text = "&Діалоги";
            // 
            // itemColorDialog
            // 
            this.itemColorDialog.Enabled = false;
            this.itemColorDialog.Name = "itemColorDialog";
            this.itemColorDialog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.itemColorDialog.Size = new System.Drawing.Size(236, 22);
            this.itemColorDialog.Text = "Вибір &кольору";
            this.itemColorDialog.Click += new System.EventHandler(this.itemColorDialog_Click);
            // 
            // itemPrintPreview
            // 
            this.itemPrintPreview.Enabled = false;
            this.itemPrintPreview.Name = "itemPrintPreview";
            this.itemPrintPreview.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.itemPrintPreview.Size = new System.Drawing.Size(236, 22);
            this.itemPrintPreview.Text = "&Попередній перегляд";
            this.itemPrintPreview.Click += new System.EventHandler(this.itemPrintPreview_Click);
            // 
            // itemOpenFile
            // 
            this.itemOpenFile.Enabled = false;
            this.itemOpenFile.Name = "itemOpenFile";
            this.itemOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.itemOpenFile.Size = new System.Drawing.Size(236, 22);
            this.itemOpenFile.Text = "&Відкриття файлу";
            this.itemOpenFile.Click += new System.EventHandler(this.itemOpenFile_Click);
            // 
            // itemPrint
            // 
            this.itemPrint.Enabled = false;
            this.itemPrint.Name = "itemPrint";
            this.itemPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.itemPrint.Size = new System.Drawing.Size(236, 22);
            this.itemPrint.Text = "&Друк";
            this.itemPrint.Click += new System.EventHandler(this.itemPrint_Click);
            // 
            // menuAdditional
            // 
            this.menuAdditional.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAbout,
            this.itemExecute,
            this.itemWord});
            this.menuAdditional.Name = "menuAdditional";
            this.menuAdditional.Size = new System.Drawing.Size(77, 20);
            this.menuAdditional.Text = "Д&одатково";
            // 
            // itemAbout
            // 
            this.itemAbout.Name = "itemAbout";
            this.itemAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.itemAbout.Size = new System.Drawing.Size(187, 22);
            this.itemAbout.Text = "Про &розробника";
            this.itemAbout.Click += new System.EventHandler(this.itemAbout_Click);
            // 
            // itemExecute
            // 
            this.itemExecute.Name = "itemExecute";
            this.itemExecute.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.itemExecute.Size = new System.Drawing.Size(187, 22);
            this.itemExecute.Text = "&Виконати";
            this.itemExecute.Click += new System.EventHandler(this.itemExecute_Click);
            // 
            // itemWord
            // 
            this.itemWord.Name = "itemWord";
            this.itemWord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.itemWord.Size = new System.Drawing.Size(187, 22);
            this.itemWord.Text = "&Word";
            this.itemWord.Click += new System.EventHandler(this.itemWord_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnColor,
            this.btnPreview,
            this.btnOpen,
            this.btnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnColor
            // 
            this.btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnColor.Enabled = false;
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(42, 22);
            this.btnColor.Text = "Колір";
            this.btnColor.Click += new System.EventHandler(this.itemColorDialog_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPreview.Enabled = false;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(63, 22);
            this.btnPreview.Text = "Перегляд";
            this.btnPreview.Click += new System.EventHandler(this.itemPrintPreview_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpen.Enabled = false;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(62, 22);
            this.btnOpen.Text = "Відкрити";
            this.btnOpen.Click += new System.EventHandler(this.itemOpenFile_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrint.Enabled = false;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(39, 22);
            this.btnPrint.Text = "Друк";
            this.btnPrint.Click += new System.EventHandler(this.itemPrint_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusUser,
            this.statusDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusUser
            // 
            this.statusUser.Name = "statusUser";
            this.statusUser.Size = new System.Drawing.Size(685, 17);
            this.statusUser.Spring = true;
            this.statusUser.Text = "Користувач: Не авторизовано";
            this.statusUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusDate
            // 
            this.statusDate.Name = "statusDate";
            this.statusDate.Size = new System.Drawing.Size(100, 17);
            this.statusDate.Text = "22.11.2025";
            this.statusDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxColor,
            this.ctxPreview,
            this.ctxOpen,
            this.ctxPrint});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(187, 92);
            // 
            // ctxColor
            // 
            this.ctxColor.Enabled = false;
            this.ctxColor.Name = "ctxColor";
            this.ctxColor.Size = new System.Drawing.Size(186, 22);
            this.ctxColor.Text = "Вибір кольору";
            this.ctxColor.Click += new System.EventHandler(this.itemColorDialog_Click);
            // 
            // ctxPreview
            // 
            this.ctxPreview.Enabled = false;
            this.ctxPreview.Name = "ctxPreview";
            this.ctxPreview.Size = new System.Drawing.Size(186, 22);
            this.ctxPreview.Text = "Попередній перегляд";
            this.ctxPreview.Click += new System.EventHandler(this.itemPrintPreview_Click);
            // 
            // ctxOpen
            // 
            this.ctxOpen.Enabled = false;
            this.ctxOpen.Name = "ctxOpen";
            this.ctxOpen.Size = new System.Drawing.Size(186, 22);
            this.ctxOpen.Text = "Відкриття файлу";
            this.ctxOpen.Click += new System.EventHandler(this.itemOpenFile_Click);
            // 
            // ctxPrint
            // 
            this.ctxPrint.Enabled = false;
            this.ctxPrint.Name = "ctxPrint";
            this.ctxPrint.Size = new System.Drawing.Size(186, 22);
            this.ctxPrint.Text = "Друк";
            this.ctxPrint.Click += new System.EventHandler(this.itemPrint_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox1.Location = new System.Drawing.Point(100, 100);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(600, 300);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Тут відобразиться назва файлу";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стандартні діалоги. [Ваше Прізвище]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuMain;
        private System.Windows.Forms.ToolStripMenuItem itemRegistration;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.ToolStripMenuItem menuDialogs;
        private System.Windows.Forms.ToolStripMenuItem itemColorDialog;
        private System.Windows.Forms.ToolStripMenuItem itemPrintPreview;
        private System.Windows.Forms.ToolStripMenuItem itemOpenFile;
        private System.Windows.Forms.ToolStripMenuItem itemPrint;
        private System.Windows.Forms.ToolStripMenuItem menuAdditional;
        private System.Windows.Forms.ToolStripMenuItem itemAbout;
        private System.Windows.Forms.ToolStripMenuItem itemExecute;
        private System.Windows.Forms.ToolStripMenuItem itemWord;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnColor;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusUser;
        private System.Windows.Forms.ToolStripStatusLabel statusDate;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxColor;
        private System.Windows.Forms.ToolStripMenuItem ctxPreview;
        private System.Windows.Forms.ToolStripMenuItem ctxOpen;
        private System.Windows.Forms.ToolStripMenuItem ctxPrint;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}