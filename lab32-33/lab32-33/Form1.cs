using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab32_33
{
    public partial class Form1 : Form
    {
        private bool isRegistered = false;
        private string currentUser = "";
        private ToolStripStatusLabel userStatusLabel;
        private ToolStripStatusLabel dateStatusLabel;
        private Timer dateTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeUI();
            SetupEventHandlers();
        }

        private void InitializeUI()
        {
            this.Text = "Стандартні діалоги. Ясиняцький Кирило БІКСб22440д";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.ContextMenuStrip = CreateContextMenu();

            dateTimer = new Timer();
            dateTimer.Interval = 1000;
            dateTimer.Tick += (s, e) => UpdateStatusBar();
            dateTimer.Start();
        }

        private void SetupEventHandlers()
        {
            // Головне меню
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item.Text.Contains("Головне"))
                {
                    if (item.DropDownItems.Count > 0) item.DropDownItems[0].Click += MainMenu_Registration;
                    if (item.DropDownItems.Count > 2) item.DropDownItems[2].Click += MainMenu_Exit;
                }
                else if (item.Text.Contains("Діалоги"))
                {
                    if (item.DropDownItems.Count > 0) item.DropDownItems[0].Click += Dialog_SelectColor;
                    if (item.DropDownItems.Count > 1) item.DropDownItems[1].Click += Dialog_PrintPreview;
                    if (item.DropDownItems.Count > 2) item.DropDownItems[2].Click += Dialog_OpenFile;
                    if (item.DropDownItems.Count > 3) item.DropDownItems[3].Click += Dialog_Print;
                }
                else if (item.Text.Contains("Додатково"))
                {
                    if (item.DropDownItems.Count > 0) item.DropDownItems[0].Click += Additional_About;
                    if (item.DropDownItems.Count > 1) item.DropDownItems[1].Click += Additional_OpenWord;
                    if (item.DropDownItems.Count > 2) item.DropDownItems[2].Click += Additional_Execute;
                }
            }

            // Панель інструментів
            foreach (ToolStripButton btn in toolStrip1.Items.OfType<ToolStripButton>())
            {
                if (btn != null && !string.IsNullOrEmpty(btn.ToolTipText))
                {
                    if (btn.ToolTipText.Contains("Колір"))
                        btn.Click += Dialog_SelectColor;
                    else if (btn.ToolTipText.Contains("Перегляд"))
                        btn.Click += Dialog_PrintPreview;
                    else if (btn.ToolTipText.Contains("Відкрити"))
                        btn.Click += Dialog_OpenFile;
                    else if (btn.ToolTipText.Contains("Друк"))
                        btn.Click += Dialog_Print;
                }
            }
        }

        private void MainMenu_Registration(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            if (regForm.ShowDialog() == DialogResult.OK)
            {
                isRegistered = true;
                currentUser = regForm.Username;
                userStatusLabel.Text = $"Користувач: {currentUser}";
                EnableDialogMenuItems(true);
                EnableToolStripButtons(true);
            }
        }

        private void MainMenu_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dialog_SelectColor(object sender, EventArgs e)
        {
            if (!isRegistered) return;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
        }

        private void Dialog_PrintPreview(object sender, EventArgs e)
        {
            if (!isRegistered) return;
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.ShowDialog();
        }

        private void Dialog_OpenFile(object sender, EventArgs e)
        {
            if (!isRegistered) return;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Всі файли (*.*)|*.*";
            openFileDialog.ShowDialog();
        }

        private void Dialog_Print(object sender, EventArgs e)
        {
            if (!isRegistered) return;
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();
        }

        private void Additional_About(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void Additional_OpenWord(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE");
            }
            catch
            {
                try
                {
                    Process.Start("notepad.exe");
                }
                catch
                {
                    MessageBox.Show("Не вдалося відкрити текстовий редактор", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Additional_Execute(object sender, EventArgs e)
        {
            if (!isRegistered) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Всі файли (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (mainTextBox != null)
                {
                    mainTextBox.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                    mainTextBox.BackColor = Color.Yellow;
                    mainTextBox.Font = new Font("Times New Roman", 12, FontStyle.Underline);
                }
            }
        }

        private void EnableDialogMenuItems(bool enabled)
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item.Text.Contains("Діалоги"))
                {
                    foreach (ToolStripMenuItem subItem in item.DropDownItems)
                    {
                        subItem.Enabled = enabled;
                    }
                }
            }

            if (this.ContextMenuStrip != null)
            {
                foreach (ToolStripMenuItem item in this.ContextMenuStrip.Items)
                {
                    item.Enabled = enabled;
                }
            }
        }

        private void EnableToolStripButtons(bool enabled)
        {
            foreach (ToolStripButton btn in toolStrip1.Items.OfType<ToolStripButton>())
            {
                btn.Enabled = enabled;
            }
        }

        private void UpdateStatusBar()
        {
            dateStatusLabel.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private ContextMenuStrip CreateContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(new ToolStripMenuItem("Вибір кольору", null, Dialog_SelectColor) { Enabled = false });
            contextMenu.Items.Add(new ToolStripMenuItem("Попередній перегляд", null, Dialog_PrintPreview) { Enabled = false });
            contextMenu.Items.Add(new ToolStripMenuItem("Відкриття файлу", null, Dialog_OpenFile) { Enabled = false });
            contextMenu.Items.Add(new ToolStripMenuItem("Друк", null, Dialog_Print) { Enabled = false });
            return contextMenu;
        }
    }
}