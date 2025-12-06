using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace StudentApp
{
    class Student
    {
        string name;
        int year;
        double rating;

        public Student()
        {
            name = "New";
            year = 2018;
            rating = 90.5;
        }

        public Student(string n, int y, double r)
        {
            name = n;
            year = y;
            rating = r;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }
    }

    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();
        private string authorSurname = "Ясиняцький";

        public Form1()
        {
            InitializeComponent();
            LoadStudentsFromFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Student s = new Student(
                    textBox1.Text,
                    int.Parse(textBox2.Text),
                    double.Parse(textBox3.Text.Replace(",", ".")));

                students.Add(s);
                dataGridView1.Rows.Add(s.Name, s.Year, s.Rating);

                // Оновлюємо заголовок вікна з прізвищем останнього студента
                if (students.Count > 0)
                {
                    this.Text = "Керування студентами - " + students[students.Count - 1].Name;
                }

                MessageBox.Show("Студент додан!");
                textBox1.Text = "Name";
                textBox2.Text = "2018";
                textBox3.Text = "90,5";
            }
            catch
            {
                MessageBox.Show("Помилка! Перевірте введені дані.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("student.txt", false, Encoding.Default))
                {
                    foreach (Student s in students)
                    {
                        sw.WriteLine(s.Name + " " + s.Year + " " + s.Rating);
                    }
                }
                MessageBox.Show("Дані збережено в файл student.txt!");
            }
            catch
            {
                MessageBox.Show("Помилка при збереженні!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                textBox4.Text = "0";
                return;
            }

            double sum = 0;
            foreach (Student s in students)
            {
                sum += s.Rating;
            }
            textBox4.Text = (sum / students.Count).ToString("F2");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowAboutForm()
        {
            Form aboutForm = new Form();
            aboutForm.Text = "Про автора";
            aboutForm.Width = 400;
            aboutForm.Height = 300;
            aboutForm.StartPosition = FormStartPosition.CenterParent;

            Label label = new Label();
            label.Text = "Програма для керування студентами\n\n" +
                        "Автор:" + authorSurname + " К.М.\n" +
                        "Группа: БІКСб22440д\n" +
                        "Спеціальність: Кібербезпека\n" +
                        "Семестр: 3\n\n" +
                        "Версія: 1.0\n" +
                        "Рік: 2025\n\n" +
                        "Лабораторна робота №34";
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = new System.Drawing.Font("Arial", 10);

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Width = 100;
            okButton.Height = 30;
            okButton.Dock = DockStyle.Bottom;
            okButton.Click += (s, e) => aboutForm.Close();

            aboutForm.Controls.Add(label);
            aboutForm.Controls.Add(okButton);
            aboutForm.ShowDialog(this);
        }

        private void LoadStudentsFromFile()
        {
            try
            {
                if (!File.Exists("student.txt"))
                    return;

                using (StreamReader sr = new StreamReader("student.txt", Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length >= 3)
                        {
                            Student s = new Student(
                                parts[0],
                                int.Parse(parts[1]),
                                double.Parse(parts[2].Replace(",", ".")));
                            students.Add(s);
                            dataGridView1.Rows.Add(s.Name, s.Year, s.Rating);
                        }
                    }
                }

                // Оновлюємо заголовок з прізвищем першого завантаженого студента
                if (students.Count > 0)
                {
                    this.Text = "Керування студентами -  " + students[0].Name;
                }
            }
            catch { }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            ShowAboutForm();
        }
    }
}