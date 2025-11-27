using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Початкові значення для елементів управління
            checkBox1.Checked = true;
            textBox1.Text = "0,0";
            textBox2.Text = "0,0";
            textBox3.Text = "0,0";
            comboBox1.Text = "+";
            radioButton1.Checked = true;

            // Додаємо додаткову операцію % до списку
            comboBox1.Items.Add("%");

            // Увімкнення обробки подій клавіатури для форми
            this.KeyPreview = true;
        }

        // Обробник натискання кнопки "=" (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            double res = 0.0;

            // Перевіряємо, чи встановлено прапорець "Відображати результат"
            if (checkBox1.Checked == true)
            {
                try
                {
                    // Отримуємо значення з полів введення
                    double num1 = Convert.ToDouble(textBox1.Text.Replace(".", ","));
                    double num2 = Convert.ToDouble(textBox2.Text.Replace(".", ","));

                    // Виконуємо операцію залежно від вибраного пункту в списку
                    if (comboBox1.Text == "+")
                    {
                        res = num1 + num2;
                    }
                    else if (comboBox1.Text == "-")
                    {
                        res = num1 - num2;
                    }
                    else if (comboBox1.Text == "*")
                    {
                        res = num1 * num2;
                    }
                    else if (comboBox1.Text == "/")
                    {
                        if (num2 != 0)
                            res = num1 / num2;
                        else
                        {
                            MessageBox.Show("Ділення на нуль неможливе!", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else if (comboBox1.Text == "%")
                    {
                        res = num1 % num2;
                    }

                    // Множимо результат залежно від вибраної радіо кнопки
                    if (radioButton1.Checked == true)
                        res = res * 1;
                    else if (radioButton2.Checked == true)
                        res = res * 10;
                    else if (radioButton3.Checked == true)
                        res = res * 100;

                    // Виводимо результат
                    textBox3.Text = res.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка введення даних: " + ex.Message, "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Якщо прапорець не встановлено, виводимо 0,0
                textBox3.Text = "0,0";
            }
        }

        // Обробник натискання кнопки "Закрити" (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            // Закриваємо форму
            this.Close();
        }

        // Обробник натискання кнопки "Очистити" (button3)
        private void button3_Click(object sender, EventArgs e)
        {
            // Очищаємо всі поля введення/виведення
            textBox1.Text = "0,0";
            textBox2.Text = "0,0";
            textBox3.Text = "0,0";
            comboBox1.Text = "+";
            checkBox1.Checked = true;
            radioButton1.Checked = true;
        }

        // Обробник клацання мишкою по формі
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Відображаємо інформацію про автора
            MessageBox.Show("Автор: Ясиняцький К.М.\nГрупа: БІКСб22440д\nСпеціальність: Кібербезпека",
                "Про автора програми Калькулятор",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Обробник натискання клавіш клавіатури
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Перевіряємо натискання комбінації Shift+T
            if (e.KeyCode == Keys.T && e.Modifiers == Keys.Shift)
            {
                MessageBox.Show("Автор: Ясиняцький К.М.\nГрупа: БІКСб22440д\nСпеціальність: Кібербезпека",
                    "Інформація про автора",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}