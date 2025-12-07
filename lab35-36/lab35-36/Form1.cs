using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFChartSin1
{
    public partial class Form1 : Form
    {
        private Chart chart1;
        private TextBox textBox1, textBox2, textBox3;
        private Button button1, button2;
        private Label label1, label2, label3, label4, statusLabel;
        private Panel panel1;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 58);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(800, 472);
            this.chart1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.statusLabel);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 58);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(10, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Статус:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.Color.Green;
            this.statusLabel.Location = new System.Drawing.Point(75, 45);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(95, 13);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Готово до роботи";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(560, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Очистити";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(430, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Побудувати";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(340, 10);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(290, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Step:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(205, 10);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "6.28";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(150, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Xmax:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "-6.28";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Xmin:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Графіки функцій sin(x) та cos(x)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}