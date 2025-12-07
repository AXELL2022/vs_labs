using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFChartSin1
{
    public partial class Form1 : Form
    {
        private Chart chart1;
        private TextBox textBox1, textBox2, textBox3;
        private Button button1, button2, buttonAbout;
        private Label label1, label2, label3, label4, statusLabel;
        private Panel panel1;

        private const string STUDENT_SURNAME = "Ясиняцький К.М.";
        private const string STUDENT_GROUP = "БІКСб22440д";
        private const string LAB_NUMBER = "35-36";

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.chart1 = new Chart();
            this.panel1 = new Panel();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.label2 = new Label();
            this.textBox2 = new TextBox();
            this.label3 = new Label();
            this.textBox3 = new TextBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.buttonAbout = new Button();
            this.label4 = new Label();
            this.statusLabel = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            // chart1
            ChartArea chartArea1 = new ChartArea();
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);

            Legend legend1 = new Legend();
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);

            this.chart1.Dock = DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 80);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(800, 450);
            this.chart1.TabIndex = 0;

            // panel1
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.statusLabel);
            this.panel1.Controls.Add(this.buttonAbout);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 80);

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Text = "Xmin:";

            // textBox1
            this.textBox1.Location = new System.Drawing.Point(65, 10);
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.Text = "-6.28";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(150, 10);
            this.label2.Text = "Xmax:";

            // textBox2
            this.textBox2.Location = new System.Drawing.Point(205, 10);
            this.textBox2.Size = new System.Drawing.Size(75, 20);
            this.textBox2.Text = "6.28";

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(290, 10);
            this.label3.Text = "Step:";

            // textBox3
            this.textBox3.Location = new System.Drawing.Point(340, 10);
            this.textBox3.Size = new System.Drawing.Size(75, 20);
            this.textBox3.Text = "0.1";

            // button1 - Побудувати
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(430, 10);
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.Text = "Побудувати";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.button1_Click);

            // button2 - Очистити
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(540, 10);
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.Text = "Очистити";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new EventHandler(this.button2_Click);

            // buttonAbout - Про автора
            this.buttonAbout.BackColor = System.Drawing.Color.Blue;
            this.buttonAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.buttonAbout.ForeColor = System.Drawing.Color.White;
            this.buttonAbout.Location = new System.Drawing.Point(650, 10);
            this.buttonAbout.Size = new System.Drawing.Size(130, 30);
            this.buttonAbout.Text = "Про автора";
            this.buttonAbout.UseVisualStyleBackColor = false;
            this.buttonAbout.Click += new EventHandler(this.buttonAbout_Click);

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(10, 45);
            this.label4.Text = "Статус:";

            // statusLabel
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.Color.Green;
            this.statusLabel.Location = new System.Drawing.Point(75, 45);
            this.statusLabel.Text = "Готово до роботи";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = $"Лабораторна робота №{LAB_NUMBER} - Графіки функцій (Студент: {STUDENT_SURNAME})";
            this.Load += new EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Налаштування графіка при завантаженні форми
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";
            chart1.Titles.Add("Графіки функцій sin(x) та cos(x)");

            // Додавання першої Series (sin(x))
            Series series1 = new Series("sin(x)");
            series1.ChartType = SeriesChartType.Spline;
            series1.BorderWidth = 3;
            series1.Color = System.Drawing.Color.Blue;
            chart1.Series.Add(series1);

            // Додавання другої Series (cos(x))
            Series series2 = new Series("cos(x)");
            series2.ChartType = SeriesChartType.Spline;
            series2.BorderWidth = 3;
            series2.Color = System.Drawing.Color.Red;
            chart1.Series.Add(series2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Читаємо значення з текстових полів
                double Xmin = double.Parse(textBox1.Text);
                double Xmax = double.Parse(textBox2.Text);
                double Step = double.Parse(textBox3.Text);

                // Перевірка коректності даних
                if (Xmin >= Xmax)
                {
                    MessageBox.Show("Xmin повинно бути менше за Xmax!", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Step <= 0)
                {
                    MessageBox.Show("Step повинен бути більше за 0!", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Розраховуємо кількість точок графіка
                int count = (int)Math.Ceiling((Xmax - Xmin) / Step) + 1;

                // Створюємо масиви для значень X та Y
                double[] x = new double[count];
                double[] y1 = new double[count];
                double[] y2 = new double[count];

                // Обчислюємо точки функцій
                for (int i = 0; i < count; i++)
                {
                    x[i] = Xmin + Step * i;
                    y1[i] = Math.Sin(x[i]);
                    y2[i] = Math.Cos(x[i]);
                }

                // Налаштовуємо осі графіка
                chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax;

                // Встановлюємо крок сітки
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step * 2;

                // Очищуємо попередні точки
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                // Додаємо обчислені значення у графік
                chart1.Series[0].Points.DataBindXY(x, y1);
                chart1.Series[1].Points.DataBindXY(x, y2);

                statusLabel.Text = "Графіки побудовані успішно";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть коректні числові значення!", "Помилка формату",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очищуємо графіки
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            statusLabel.Text = "Графіки очищені";
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            // Відкриємо вікно про автора
            Form aboutForm = new Form();
            aboutForm.Text = "Про автора";
            aboutForm.Width = 450;
            aboutForm.Height = 300;
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.BackColor = System.Drawing.Color.LightBlue;

            // Панель для тексту
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = System.Drawing.Color.LightBlue;
            panel.Padding = new Padding(20);

            // Текст про автора
            Label infoLabel = new Label();
            infoLabel.AutoSize = false;
            infoLabel.Dock = DockStyle.Fill;
            infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11, System.Drawing.FontStyle.Regular);
            infoLabel.ForeColor = System.Drawing.Color.DarkBlue;
            infoLabel.Text = $@"
ЛАБОРАТОРНА РОБОТА №{LAB_NUMBER}

""Проектування та реалізація об'єктно-орієнтованих 
прикладних програм з використанням класу Chart 
бібліотеки Windows Forms: побудова графіку функцій""

Навчальна дисципліна:
""Технології безпечного програмування""

Студент: {STUDENT_SURNAME}
Група: {STUDENT_GROUP}

Завдання: Написати програму, яка показує графіки 
функцій sin(x) та cos(x) на вказаному інтервалі 
з можливістю змінювання розмітки координатних осей 
та кроку побудови.

Дата виконання: {DateTime.Now:dd.MM.yyyy}
";

            panel.Controls.Add(infoLabel);
            aboutForm.Controls.Add(panel);

            aboutForm.ShowDialog(this);
        }
    }
}