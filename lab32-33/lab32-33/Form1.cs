using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab32_33_Variant6
{
    public partial class MainForm : Form
    {
        private string currentUser = "";
        private bool isLoggedIn = false;
        private string selectedFileName = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Встановлення поточної дати
            statusDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        // Обробник реєстрації
        private void itemRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            if (regForm.ShowDialog() == DialogResult.OK)
            {
                currentUser = regForm.Username;
                isLoggedIn = true;
                statusUser.Text = "Користувач: " + currentUser;

                // Активація пунктів меню Діалоги
                EnableDialogMenus(true);

                MessageBox.Show("Ви успішно авторизовані!", "Реєстрація",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Метод активації/деактивації меню діалогів
        private void EnableDialogMenus(bool enabled)
        {
            // Активація пунктів меню
            itemColorDialog.Enabled = enabled;
            itemPrintPreview.Enabled = enabled;
            itemOpenFile.Enabled = enabled;
            itemPrint.Enabled = enabled;

            // Активація кнопок на панелі інструментів
            btnColor.Enabled = enabled;
            btnPreview.Enabled = enabled;
            btnOpen.Enabled = enabled;
            btnPrint.Enabled = enabled;

            // Активація контекстного меню
            ctxColor.Enabled = enabled;
            ctxPreview.Enabled = enabled;
            ctxOpen.Enabled = enabled;
            ctxPrint.Enabled = enabled;
        }

        // Обробник виходу
        private void itemExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви дійсно хочете вийти?", "Вихід",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Обробник вибору кольору
        private void itemColorDialog_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Ви обрали колір: " + colorDialog1.Color.Name,
                    "Вибір кольору", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Обробник попереднього перегляду
        private void itemPrintPreview_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Попередній перегляд друку", "Діалог",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Обробник відкриття файлу
        private void itemOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt";
            openFileDialog1.Title = "Відкриття файлу";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFileName = openFileDialog1.FileName;
                MessageBox.Show("Ви обрали файл: " + selectedFileName,
                    "Відкриття файлу", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Обробник друку
        private void itemPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Діалог друку", "Друк",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Обробник "Про розробника"
        private void itemAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        // Обробник "Виконати"
        private void itemExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFileName))
            {
                MessageBox.Show("Спочатку оберіть файл через 'Відкриття файлу'!",
                    "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Зміна властивостей TextBox згідно варіанту 6
            textBox1.BackColor = Color.Yellow;
            textBox1.Font = new Font("Times New Roman", 12, FontStyle.Underline);
            textBox1.Text = selectedFileName;
        }

        // Обробник відкриття Word
        private void itemWord_Click(object sender, EventArgs e)
        {
            try
            {
                // Спроба відкрити Word
                Process.Start("winword.exe");
            }
            catch
            {
                try
                {
                    // Якщо Word не знайдено, відкриваємо Notepad
                    Process.Start("notepad.exe");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не вдалося відкрити текстовий редактор: " + ex.Message,
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // Форма реєстрації
    public partial class RegistrationForm : Form
    {
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnOK;
        private Button btnCancel;

        public string Username { get; private set; }

        public RegistrationForm()
        {
            InitializeRegistrationForm();
        }

        private void InitializeRegistrationForm()
        {
            this.Text = "Реєстрація";
            this.Size = new Size(350, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblUsername = new Label();
            lblUsername.Text = "Логін:";
            lblUsername.Location = new Point(30, 30);
            lblUsername.Size = new Size(80, 20);

            txtUsername = new TextBox();
            txtUsername.Location = new Point(120, 30);
            txtUsername.Size = new Size(180, 20);

            lblPassword = new Label();
            lblPassword.Text = "Пароль:";
            lblPassword.Location = new Point(30, 70);
            lblPassword.Size = new Size(80, 20);

            txtPassword = new TextBox();
            txtPassword.Location = new Point(120, 70);
            txtPassword.Size = new Size(180, 20);
            txtPassword.PasswordChar = '*';

            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Location = new Point(100, 120);
            btnOK.Click += BtnOK_Click;

            btnCancel = new Button();
            btnCancel.Text = "Скасувати";
            btnCancel.Location = new Point(200, 120);
            btnCancel.DialogResult = DialogResult.Cancel;

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnOK);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Введіть логін!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введіть пароль!", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Username = txtUsername.Text;
            this.DialogResult = DialogResult.OK;
        }
    }

    // Форма "Про розробника"
    public partial class AboutForm : Form
    {
        private Label lblInfo;
        private Button btnClose;

        public AboutForm()
        {
            InitializeAboutForm();
        }

        private void InitializeAboutForm()
        {
            this.Text = "Про розробника";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblInfo = new Label();
            lblInfo.Text = "Лабораторна робота №32-33\n\n" +
                          "Прізвище: [Ваше Прізвище]\n" +
                          "Група: [Ваша Група]\n" +
                          "Спеціальність: [Ваша Спеціальність]\n\n" +
                          "Варіант: 6\n\n" +
                          "Дисципліна: Технології безпечного програмування";
            lblInfo.Location = new Point(30, 30);
            lblInfo.Size = new Size(340, 150);
            lblInfo.AutoSize = false;

            btnClose = new Button();
            btnClose.Text = "Закрити";
            btnClose.Location = new Point(150, 180);
            btnClose.Click += (s, ev) => { this.Close(); };

            this.Controls.Add(lblInfo);
            this.Controls.Add(btnClose);
        }
    }
}