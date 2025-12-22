using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        private string currentPath = @"C:\";
        private readonly Stack<string> navigationHistory = new Stack<string>();
        private string copiedPath = null;
        private bool isCut = false;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Файловий провідник";
            this.Size = new System.Drawing.Size(900, 600);
            LoadDrives();
            RefreshFileList();
            InitializeContextMenu();
        }

        // Інітіалізація контекстного меню
        private void InitializeContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem newFolderItem = new ToolStripMenuItem("📁 Нова папка");
            newFolderItem.Click += (s, e) => buttonCreateFolder_Click(null, null);
            contextMenu.Items.Add(newFolderItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem copyItem = new ToolStripMenuItem("📋 Копіювати");
            copyItem.Click += (s, e) => buttonCopy_Click(null, null);
            contextMenu.Items.Add(copyItem);

            ToolStripMenuItem cutItem = new ToolStripMenuItem("✂️ Вирізати");
            cutItem.Click += (s, e) => buttonCut_Click(null, null);
            contextMenu.Items.Add(cutItem);

            ToolStripMenuItem pasteItem = new ToolStripMenuItem("📌 Вставити");
            pasteItem.Click += (s, e) => buttonPaste_Click(null, null);
            contextMenu.Items.Add(pasteItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem renameItem = new ToolStripMenuItem("✏️ Перейменувати");
            renameItem.Click += (s, e) => buttonRename_Click(null, null);
            contextMenu.Items.Add(renameItem);

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("🗑️ Видалити");
            deleteItem.Click += (s, e) => buttonDelete_Click(null, null);
            contextMenu.Items.Add(deleteItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem propertiesItem = new ToolStripMenuItem("ℹ️ Властивості");
            propertiesItem.Click += (s, e) => buttonProperties_Click(null, null);
            contextMenu.Items.Add(propertiesItem);

            dataGridView1.ContextMenuStrip = contextMenu;
        }

        // Завантажити диски в ComboBox
        private void LoadDrives()
        {
            try
            {
                comboBoxDrives.Items.Clear();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    comboBoxDrives.Items.Add(drive.Name.TrimEnd('\\'));
                }
                if (comboBoxDrives.Items.Count > 0)
                    comboBoxDrives.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження дисків: {ex.Message}", "Помилка");
            }
        }

        // Оновити список файлів та папок
        private void RefreshFileList()
        {
            try
            {
                if (!Directory.Exists(currentPath))
                {
                    MessageBox.Show("Папка не існує!", "Помилка");
                    currentPath = @"C:\";
                }

                dataGridView1.Rows.Clear();
                textBoxPath.Text = currentPath;

                // Додати кнопку "До верхньої папки"
                if (currentPath != Path.GetPathRoot(currentPath))
                {
                    dataGridView1.Rows.Add("📁", "..", "-", "");
                }

                var dirs = Directory.GetDirectories(currentPath);
                var files = Directory.GetFiles(currentPath);

                // Додати папки
                foreach (string dirPath in dirs)
                {
                    try
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                        dataGridView1.Rows.Add(
                            "📁",
                            dirInfo.Name,
                            "-",
                            dirInfo.LastWriteTime.ToString("dd.MM.yyyy HH:mm")
                        );
                    }
                    catch { }
                }

                // Додати файли
                foreach (string filePath in files)
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        dataGridView1.Rows.Add(
                            "📄",
                            fileInfo.Name,
                            FormatBytes(fileInfo.Length),
                            fileInfo.LastWriteTime.ToString("dd.MM.yyyy HH:mm")
                        );
                    }
                    catch { }
                }

                labelStatus.Text = $"Всього: {dataGridView1.Rows.Count} елементів";
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Доступ заборонено до цієї папки!", "Помилка доступу");
                currentPath = @"C:\";
                RefreshFileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка");
            }
        }

        // Форматувати розмір файлу в людиночитаний формат
        private string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        // Подвійний клік по файлу або папці
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                string itemName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                // Перейти до верхньої папки
                if (itemName == "..")
                {
                    DirectoryInfo parentDir = Directory.GetParent(currentPath);
                    if (parentDir != null)
                    {
                        navigationHistory.Push(currentPath);
                        currentPath = parentDir.FullName;
                        RefreshFileList();
                    }
                    return;
                }

                string fullPath = Path.Combine(currentPath, itemName);

                // Перейти в папку
                if (Directory.Exists(fullPath))
                {
                    navigationHistory.Push(currentPath);
                    currentPath = fullPath;
                    RefreshFileList();
                }
                // Відкрити файл
                else if (File.Exists(fullPath))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = fullPath,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка відкриття файлу: {ex.Message}", "Помилка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка");
            }
        }

        // Кнопка "Назад"
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (navigationHistory.Count > 0)
            {
                currentPath = navigationHistory.Pop();
                RefreshFileList();
            }
            else
            {
                MessageBox.Show("Історія навігації пуста!", "Інформація");
            }
        }

        // Кнопка "Оновити"
        public void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshFileList();
            labelStatus.Text = "Оновлено";
        }

        // Зміна вибраного диска
        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDrives.SelectedItem != null)
            {
                currentPath = comboBoxDrives.SelectedItem.ToString();
                if (!currentPath.EndsWith("\\"))
                    currentPath += "\\";
                navigationHistory.Clear();
                RefreshFileList();
            }
        }

        // Створити нову папку
        private void buttonCreateFolder_Click(object sender, EventArgs e)
        {
            string folderName = PromptDialog("Введіть ім'я нової папки:", "Створення папки");
            if (!string.IsNullOrWhiteSpace(folderName))
            {
                try
                {
                    string newPath = Path.Combine(currentPath, folderName);
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                        RefreshFileList();
                        labelStatus.Text = $"Папка '{folderName}' створена";
                    }
                    else
                    {
                        MessageBox.Show("Папка з таким іменем уже існує!", "Помилка");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка створення папки: {ex.Message}", "Помилка");
                }
            }
        }

        // Копіювати файл/папку
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string itemName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    copiedPath = Path.Combine(currentPath, itemName);
                    isCut = false;
                    labelStatus.Text = $"Скопійовано: {itemName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка копіювання: {ex.Message}", "Помилка");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл або папку!", "Увага");
            }
        }

        // Вирізати файл/папку
        private void buttonCut_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string itemName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    copiedPath = Path.Combine(currentPath, itemName);
                    isCut = true;
                    labelStatus.Text = $"Вирізано: {itemName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка вирізання: {ex.Message}", "Помилка");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл або папку!", "Увага");
            }
        }

        // Вставити файл/папку
        private void buttonPaste_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(copiedPath))
            {
                MessageBox.Show("Спочатку скопіюйте або вирізайте файл!", "Увага");
                return;
            }

            try
            {
                string itemName = Path.GetFileName(copiedPath);
                string destinationPath = Path.Combine(currentPath, itemName);

                if (File.Exists(copiedPath))
                {
                    if (File.Exists(destinationPath))
                        File.Delete(destinationPath);

                    if (isCut)
                    {
                        File.Move(copiedPath, destinationPath);
                    }
                    else
                    {
                        File.Copy(copiedPath, destinationPath, true);
                    }
                }
                else if (Directory.Exists(copiedPath))
                {
                    if (isCut)
                    {
                        if (!Directory.Exists(destinationPath))
                        {
                            Directory.Move(copiedPath, destinationPath);
                        }
                        else
                        {
                            MessageBox.Show("Папка з таким іменем уже існує!", "Помилка");
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(destinationPath))
                        {
                            CopyDirectory(copiedPath, destinationPath);
                        }
                        else
                        {
                            MessageBox.Show("Папка з таким іменем уже існує!", "Помилка");
                        }
                    }
                }

                RefreshFileList();
                copiedPath = null;
                labelStatus.Text = "Вставлено успішно";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка вставлення: {ex.Message}", "Помилка");
            }
        }

        // Копіювати папку рекурсивно
        private void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(destDir, Path.GetFileName(file)), true);
            }
            foreach (string dir in Directory.GetDirectories(sourceDir))
            {
                CopyDirectory(dir, Path.Combine(destDir, Path.GetFileName(dir)));
            }
        }

        // Видалити файл або папку
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string itemName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string fullPath = Path.Combine(currentPath, itemName);

                    DialogResult result = MessageBox.Show(
                        $"Ви впевнені, що хочете видалити '{itemName}'?",
                        "Підтвердження видалення",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        if (Directory.Exists(fullPath))
                        {
                            Directory.Delete(fullPath, true);
                        }
                        else if (File.Exists(fullPath))
                        {
                            File.Delete(fullPath);
                        }
                        RefreshFileList();
                        labelStatus.Text = $"'{itemName}' видалено";
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Доступ заборонено! Файл може бути заблокований.", "Помилка доступу");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка видалення: {ex.Message}", "Помилка");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл або папку для видалення!", "Увага");
            }
        }

        // Перейменувати файл або папку
        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string oldName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string newName = PromptDialog("Введіть нове ім'я:", "Перейменування", oldName);

                    if (!string.IsNullOrWhiteSpace(newName) && newName != oldName)
                    {
                        string oldPath = Path.Combine(currentPath, oldName);
                        string newPath = Path.Combine(currentPath, newName);

                        if (File.Exists(oldPath))
                        {
                            if (File.Exists(newPath))
                                File.Delete(newPath);
                            File.Copy(oldPath, newPath);
                            File.Delete(oldPath);
                        }
                        else if (Directory.Exists(oldPath))
                        {
                            if (Directory.Exists(newPath))
                                Directory.Delete(newPath, true);
                            CopyDirectory(oldPath, newPath);
                            Directory.Delete(oldPath, true);
                        }

                        RefreshFileList();
                        labelStatus.Text = $"'{oldName}' перейменовано в '{newName}'";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка перейменування: {ex.Message}", "Помилка");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл або папку!", "Увага");
            }
        }

        // Переглянути властивості
        private void buttonProperties_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string itemName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string fullPath = Path.Combine(currentPath, itemName);

                    string info = "";

                    if (Directory.Exists(fullPath))
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(fullPath);
                        int fileCount = dirInfo.GetFiles().Length;
                        int folderCount = dirInfo.GetDirectories().Length;

                        info = $"Ім'я: {itemName}\n" +
                               $"Тип: Папка\n" +
                               $"Шлях: {fullPath}\n" +
                               $"Файлів: {fileCount}\n" +
                               $"Папок: {folderCount}\n" +
                               $"Створено: {dirInfo.CreationTime}\n" +
                               $"Змінено: {dirInfo.LastWriteTime}\n" +
                               $"Атрибути: {dirInfo.Attributes}";
                    }
                    else if (File.Exists(fullPath))
                    {
                        FileInfo fileInfo = new FileInfo(fullPath);
                        info = $"Ім'я: {itemName}\n" +
                               $"Тип: Файл\n" +
                               $"Шлях: {fullPath}\n" +
                               $"Розмір: {FormatBytes(fileInfo.Length)}\n" +
                               $"Створено: {fileInfo.CreationTime}\n" +
                               $"Змінено: {fileInfo.LastWriteTime}\n" +
                               $"Атрибути: {fileInfo.Attributes}";
                    }
                    else
                    {
                        MessageBox.Show("Елемент не знайдено!", "Помилка");
                        return;
                    }

                    MessageBox.Show(info, "Властивості");
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Доступ заборонено до цього елемента!", "Помилка доступу");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка");
                }
            }
        }

        // Діалог для введення тексту
        private string PromptDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Text = caption,
                Width = 400,
                Height = 150,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Text = text,
                Width = 350,
                AutoSize = true
            };

            TextBox textBox = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 350,
                Text = defaultValue
            };

            Button okBtn = new Button()
            {
                Text = "ОК",
                Left = 210,
                Width = 80,
                Top = 80,
                DialogResult = DialogResult.OK
            };

            Button cancelBtn = new Button()
            {
                Text = "Скасувати",
                Left = 300,
                Width = 70,
                Top = 80,
                DialogResult = DialogResult.Cancel
            };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(okBtn);
            prompt.Controls.Add(cancelBtn);
            prompt.AcceptButton = okBtn;
            prompt.CancelButton = cancelBtn;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}