using System;
using System.Drawing;
using System.Windows.Forms;

namespace RatingPerformers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCustomLogic();
        }

        private void InitializeCustomLogic()
        {
            // Налаштування заголовка, які не можна зробити в дизайнері
            this.Text = "Рейтинг виконавців. Ясиняцький К.М.";
            this.KeyPreview = true; // Для обробки натискання клавіш
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRespondent.Text))
            {
                MessageBox.Show("Будь ласка, введіть інформацію про респондента!",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPerformer.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, оберіть виконавця!",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalRating = 0;

            // Примітка: Тепер Tag приходить як object (string), тому конвертуємо спочатку в string, потім в int
            if (rbListen.Checked)
                totalRating += Convert.ToInt32(rbListen.Tag);
            else if (rbNotListen.Checked)
                totalRating += Convert.ToInt32(rbNotListen.Tag);
            else if (rbSometimes.Checked)
                totalRating += Convert.ToInt32(rbSometimes.Tag);

            if (chkManner.Checked)
                totalRating += Convert.ToInt32(chkManner.Tag);
            if (chkAppearance.Checked)
                totalRating += Convert.ToInt32(chkAppearance.Tag);
            if (chkRepertoire.Checked)
                totalRating += Convert.ToInt32(chkRepertoire.Tag);

            txtRating.Text = totalRating + " балів (Виконавець: " + cmbPerformer.SelectedItem.ToString() + ")";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.H)
            {
                ShowAuthorInfo();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ShowAuthorInfo();
        }

        private void ShowAuthorInfo()
        {
            MessageBox.Show(
                "Розробник: Ясиняцький К.М.\n" +
                "Група: БІКСб22440д\n" +
                "Спеціальність: Кібербезпека\n" +
                "Варіант: 26\n" +
                "Лабораторна робота №28-29",
                "Про автора",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}