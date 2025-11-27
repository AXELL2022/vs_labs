using System;
using System.IO;
using System.Windows.Forms;

namespace Var26_RS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PasswordDialog pd = new PasswordDialog();

            if (pd.ShowDialog() == DialogResult.OK)
            {
                if (pd.Password == "1234")
                {
                    AddDialog ad = new AddDialog();
                    if (ad.ShowDialog() == DialogResult.OK)
                        listBox1.Items.Add(ad.ElementName);
                }
                else
                {
                    MessageBox.Show("Неправильний пароль!");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Оберіть елемент!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.AppendAllText(sfd.FileName,
                    listBox1.SelectedItem + " — " + txtCount.Text + Environment.NewLine);

                MessageBox.Show("Записано!");
            }
        }

        private void btnShowFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileViewer fv = new FileViewer(ofd.FileName);
                fv.ShowDialog();
            }
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            AuthorDialog ad = new AuthorDialog();
            ad.ShowDialog();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            CalendarDialog cd = new CalendarDialog();
            cd.ShowDialog();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void btnExit_Click(object sender, EventArgs e) => Close();
    }
}
