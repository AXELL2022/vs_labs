using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Linq;

namespace FileExplorer
{
    public class MainForm : Form
    {
        private TreeView treeView;
        private ListView listView;
        private TextBox pathBox;
        private TextBox searchBox;
        private Button btnBack, btnForward, btnUp, btnRefresh, btnSearch;
        private ImageList imageList;
        private string currentPath = "";
        private System.Collections.Generic.Stack<string> backHistory = new System.Collections.Generic.Stack<string>();
        private System.Collections.Generic.Stack<string> forwardHistory = new System.Collections.Generic.Stack<string>();
        private ContextMenuStrip listContextMenu;
        private Logger logger;

        public MainForm()
        {
            logger = new Logger();
            logger.Log("Програма запущена");
            InitializeComponents();
            LoadDrives();
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)))
            {
                NavigateTo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            }
        }

        private void InitializeComponents()
        {
            this.Text = "Провідник файлів";
            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Панель інструментів
            Panel toolPanel = new Panel { Dock = DockStyle.Top, Height = 75, Padding = new Padding(5) };

            // Перший ряд кнопок
            btnBack = new Button { Text = "←", Width = 40, Height = 30, Left = 5, Top = 5, Font = new Font("Arial", 12) };
            btnBack.Click += (s, e) => GoBack();

            btnForward = new Button { Text = "→", Width = 40, Height = 30, Left = 50, Top = 5, Font = new Font("Arial", 12) };
            btnForward.Click += (s, e) => GoForward();

            btnUp = new Button { Text = "↑", Width = 40, Height = 30, Left = 95, Top = 5, Font = new Font("Arial", 12) };
            btnUp.Click += (s, e) => GoUp();

            btnRefresh = new Button { Text = "⟳", Width = 40, Height = 30, Left = 140, Top = 5, Font = new Font("Arial", 12) };
            btnRefresh.Click += (s, e) => RefreshView();

            pathBox = new TextBox { Left = 185, Top = 8, Width = 800, Height = 25 };
            pathBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) NavigateTo(pathBox.Text); };

            // Другий ряд - пошук
            Label lblSearch = new Label { Text = "Пошук:", Left = 5, Top = 45, Width = 50 };
            searchBox = new TextBox { Left = 60, Top = 42, Width = 300, Height = 25 };
            btnSearch = new Button { Text = "Знайти", Left = 365, Top = 40, Width = 80, Height = 28 };
            btnSearch.Click += (s, e) => SearchFiles();

            toolPanel.Controls.AddRange(new Control[] { btnBack, btnForward, btnUp, btnRefresh, pathBox, lblSearch, searchBox, btnSearch });

            // Розділювач
            SplitContainer splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 250,
                BorderStyle = BorderStyle.Fixed3D
            };

            // TreeView
            treeView = new TreeView { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9) };
            treeView.AfterSelect += TreeView_AfterSelect;
            treeView.BeforeExpand += TreeView_BeforeExpand;

            // ListView
            imageList = new ImageList { ImageSize = new Size(32, 32) };
            imageList.Images.Add("folder", SystemIcons.Shield.ToBitmap());
            imageList.Images.Add("file", SystemIcons.Application.ToBitmap());

            listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                LargeImageList = imageList,
                SmallImageList = imageList,
                FullRowSelect = true,
                Font = new Font("Segoe UI", 9)
            };
            listView.Columns.Add("Ім'я", 300);
            listView.Columns.Add("Тип", 150);
            listView.Columns.Add("Розмір", 100);
            listView.Columns.Add("Дата зміни", 150);
            listView.DoubleClick += ListView_DoubleClick;
            listView.KeyDown += ListView_KeyDown;

            // Контекстне меню
            CreateContextMenu();
            listView.ContextMenuStrip = listContextMenu;

            splitContainer.Panel1.Controls.Add(treeView);
            splitContainer.Panel2.Controls.Add(listView);

            this.Controls.Add(splitContainer);
            this.Controls.Add(toolPanel);

            // Статус бар
            StatusStrip statusStrip = new StatusStrip();
            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel("Готово");
            statusStrip.Items.Add(statusLabel);
            this.Controls.Add(statusStrip);
        }

        private void CreateContextMenu()
        {
            listContextMenu = new ContextMenuStrip();

            ToolStripMenuItem newFolder = new ToolStripMenuItem("Створити папку");
            newFolder.Click += (s, e) => CreateNewFolder();

            ToolStripMenuItem copy = new ToolStripMenuItem("Копіювати");
            copy.Click += (s, e) => CopyItem();

            ToolStripMenuItem cut = new ToolStripMenuItem("Вирізати");
            cut.Click += (s, e) => CutItem();

            ToolStripMenuItem paste = new ToolStripMenuItem("Вставити");
            paste.Click += (s, e) => PasteItem();

            ToolStripMenuItem rename = new ToolStripMenuItem("Перейменувати");
            rename.Click += (s, e) => RenameItem();

            ToolStripMenuItem delete = new ToolStripMenuItem("Видалити");
            delete.Click += (s, e) => DeleteItem();

            ToolStripMenuItem properties = new ToolStripMenuItem("Властивості");
            properties.Click += (s, e) => ShowProperties();

            listContextMenu.Items.AddRange(new ToolStripItem[] {
                newFolder,
                new ToolStripSeparator(),
                copy,
                cut,
                paste,
                new ToolStripSeparator(),
                rename,
                delete,
                new ToolStripSeparator(),
                properties
            });
        }

        private void LoadDrives()
        {
            try
            {
                treeView.Nodes.Clear();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady)
                    {
                        TreeNode node = new TreeNode($"{drive.Name} ({drive.DriveType})") { Tag = drive.Name };
                        node.Nodes.Add("");
                        treeView.Nodes.Add(node);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Помилка завантаження дисків", ex);
                MessageBox.Show($"Помилка завантаження дисків: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "")
            {
                e.Node.Nodes.Clear();
                LoadSubDirectories(e.Node);
            }
        }

        private void LoadSubDirectories(TreeNode node)
        {
            string path = node.Tag.ToString();
            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    DirectoryInfo di = new DirectoryInfo(dir);
                    if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        TreeNode subNode = new TreeNode(di.Name) { Tag = di.FullName };
                        subNode.Nodes.Add("");
                        node.Nodes.Add(subNode);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                logger.Log($"Немає доступу до папки: {path}");
            }
            catch (Exception ex)
            {
                logger.LogError($"Помилка завантаження підпапок: {path}", ex);
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag.ToString();
            NavigateTo(path);
        }

        private void NavigateTo(string path)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Папка не існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(currentPath) && currentPath != path)
            {
                backHistory.Push(currentPath);
                forwardHistory.Clear();
            }

            currentPath = path;
            pathBox.Text = path;
            LoadDirectory(path);
            logger.Log($"Навігація до: {path}");
        }

        private void LoadDirectory(string path)
        {
            listView.Items.Clear();

            try
            {
                // Папки
                foreach (string dir in Directory.GetDirectories(path))
                {
                    DirectoryInfo di = new DirectoryInfo(dir);
                    if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        ListViewItem item = new ListViewItem(di.Name, "folder");
                        item.SubItems.Add("Папка");
                        item.SubItems.Add("");
                        item.SubItems.Add(di.LastWriteTime.ToString("dd.MM.yyyy HH:mm"));
                        item.Tag = di.FullName;
                        listView.Items.Add(item);
                    }
                }

                // Файли
                foreach (string file in Directory.GetFiles(path))
                {
                    FileInfo fi = new FileInfo(file);
                    if ((fi.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        ListViewItem item = new ListViewItem(fi.Name, "file");
                        item.SubItems.Add(fi.Extension);
                        item.SubItems.Add(FormatSize(fi.Length));
                        item.SubItems.Add(fi.LastWriteTime.ToString("dd.MM.yyyy HH:mm"));
                        item.Tag = fi.FullName;
                        listView.Items.Add(item);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Немає прав доступу до цієї папки", "Помилка доступу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                logger.Log($"Немає доступу: {path}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.LogError($"Помилка завантаження папки: {path}", ex);
            }
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                string path = listView.SelectedItems[0].Tag.ToString();
                if (Directory.Exists(path))
                {
                    NavigateTo(path);
                }
                else if (File.Exists(path))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                        logger.Log($"Відкрито файл: {path}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не вдалося відкрити файл: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.LogError($"Помилка відкриття файлу: {path}", ex);
                    }
                }
            }
        }

        private void ListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteItem();
            }
            else if (e.KeyCode == Keys.F2)
            {
                RenameItem();
            }
        }

        private void CreateNewFolder()
        {
            try
            {
                string folderName = PromptInput("Створення папки", "Введіть ім'я папки:");
                if (!string.IsNullOrWhiteSpace(folderName))
                {
                    string newPath = Path.Combine(currentPath, folderName);
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                        logger.Log($"Створено папку: {newPath}");
                        RefreshView();
                    }
                    else
                    {
                        MessageBox.Show("Папка з таким іменем вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка створення папки: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.LogError("Помилка створення папки", ex);
            }
        }

        private string clipboardPath = "";
        private bool isCutOperation = false;

        private void CopyItem()
        {
            if (listView.SelectedItems.Count > 0)
            {
                clipboardPath = listView.SelectedItems[0].Tag.ToString();
                isCutOperation = false;
                logger.Log($"Скопійовано: {clipboardPath}");
                MessageBox.Show("Об'єкт скопійовано", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CutItem()
        {
            if (listView.SelectedItems.Count > 0)
            {
                clipboardPath = listView.SelectedItems[0].Tag.ToString();
                isCutOperation = true;
                logger.Log($"Вирізано: {clipboardPath}");
                MessageBox.Show("Об'єкт вирізано", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PasteItem()
        {
            if (string.IsNullOrEmpty(clipboardPath))
            {
                MessageBox.Show("Буфер обміну порожній!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string name = Path.GetFileName(clipboardPath);
                string destPath = Path.Combine(currentPath, name);

                if (File.Exists(clipboardPath))
                {
                    if (isCutOperation)
                    {
                        File.Move(clipboardPath, destPath);
                        logger.Log($"Переміщено файл: {clipboardPath} -> {destPath}");
                    }
                    else
                    {
                        File.Copy(clipboardPath, destPath, true);
                        logger.Log($"Скопійовано файл: {clipboardPath} -> {destPath}");
                    }
                }
                else if (Directory.Exists(clipboardPath))
                {
                    if (isCutOperation)
                    {
                        Directory.Move(clipboardPath, destPath);
                        logger.Log($"Переміщено папку: {clipboardPath} -> {destPath}");
                    }
                    else
                    {
                        CopyDirectory(clipboardPath, destPath);
                        logger.Log($"Скопійовано папку: {clipboardPath} -> {destPath}");
                    }
                }

                clipboardPath = "";
                isCutOperation = false;
                RefreshView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка операції: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.LogError("Помилка вставки", ex);
            }
        }

        private void CopyDirectory(string source, string destination)
        {
            Directory.CreateDirectory(destination);
            foreach (string file in Directory.GetFiles(source))
            {
                File.Copy(file, Path.Combine(destination, Path.GetFileName(file)), true);
            }
            foreach (string dir in Directory.GetDirectories(source))
            {
                CopyDirectory(dir, Path.Combine(destination, Path.GetFileName(dir)));
            }
        }

        private void RenameItem()
        {
            if (listView.SelectedItems.Count == 0) return;

            try
            {
                string oldPath = listView.SelectedItems[0].Tag.ToString();
                string oldName = Path.GetFileName(oldPath);
                string newName = PromptInput("Перейменування", "Нове ім'я:", oldName);

                if (!string.IsNullOrWhiteSpace(newName) && newName != oldName)
                {
                    string newPath = Path.Combine(Path.GetDirectoryName(oldPath), newName);

                    if (File.Exists(oldPath))
                    {
                        File.Move(oldPath, newPath);
                    }
                    else if (Directory.Exists(oldPath))
                    {
                        Directory.Move(oldPath, newPath);
                    }

                    logger.Log($"Перейменовано: {oldPath} -> {newPath}");
                    RefreshView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка перейменування: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.LogError("Помилка перейменування", ex);
            }
        }

        private void DeleteItem()
        {
            if (listView.SelectedItems.Count == 0) return;

            if (MessageBox.Show("Ви впевнені, що хочете видалити вибраний об'єкт?", "Підтвердження",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string path = listView.SelectedItems[0].Tag.ToString();

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        logger.Log($"Видалено файл: {path}");
                    }
                    else if (Directory.Exists(path))
                    {
                        Directory.Delete(path, true);
                        logger.Log($"Видалено папку: {path}");
                    }

                    RefreshView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка видалення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.LogError("Помилка видалення", ex);
                }
            }
        }

        private void ShowProperties()
        {
            if (listView.SelectedItems.Count == 0) return;

            try
            {
                string path = listView.SelectedItems[0].Tag.ToString();
                string info = "";

                if (File.Exists(path))
                {
                    FileInfo fi = new FileInfo(path);
                    info = $"Ім'я: {fi.Name}\n" +
                           $"Шлях: {fi.FullName}\n" +
                           $"Розмір: {FormatSize(fi.Length)}\n" +
                           $"Створено: {fi.CreationTime}\n" +
                           $"Змінено: {fi.LastWriteTime}\n" +
                           $"Атрибути: {fi.Attributes}";
                }
                else if (Directory.Exists(path))
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    int fileCount = di.GetFiles().Length;
                    int dirCount = di.GetDirectories().Length;
                    long totalSize = di.GetFiles("*", SearchOption.AllDirectories).Sum(f => f.Length);

                    info = $"Ім'я: {di.Name}\n" +
                           $"Шлях: {di.FullName}\n" +
                           $"Створено: {di.CreationTime}\n" +
                           $"Змінено: {di.LastWriteTime}\n" +
                           $"Файлів: {fileCount}\n" +
                           $"Папок: {dirCount}\n" +
                           $"Загальний розмір: {FormatSize(totalSize)}";
                }

                MessageBox.Show(info, "Властивості", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка отримання властивостей: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.LogError("Помилка властивостей", ex);
            }
        }

        private void SearchFiles()
        {
            string searchQuery = searchBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("Введіть текст для пошуку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                listView.Items.Clear();
                logger.Log($"Пошук файлів: {searchQuery} в {currentPath}");

                var files = Directory.GetFiles(currentPath, $"*{searchQuery}*", SearchOption.AllDirectories);
                var dirs = Directory.GetDirectories(currentPath, $"*{searchQuery}*", SearchOption.AllDirectories);

                foreach (string dir in dirs)
                {
                    DirectoryInfo di = new DirectoryInfo(dir);
                    ListViewItem item = new ListViewItem(di.FullName, "folder");
                    item.SubItems.Add("Папка");
                    item.SubItems.Add("");
                    item.SubItems.Add(di.LastWriteTime.ToString("dd.MM.yyyy HH:mm"));
                    item.Tag = di.FullName;
                    listView.Items.Add(item);
                }

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    ListViewItem item = new ListViewItem(fi.FullName, "file");
                    item.SubItems.Add(fi.Extension);
                    item.SubItems.Add(FormatSize(fi.Length));
                    item.SubItems.Add(fi.LastWriteTime.ToString("dd.MM.yyyy HH:mm"));
                    item.Tag = fi.FullName;
                    listView.Items.Add(item);
                }

                MessageBox.Show($"Знайдено результатів: {listView.Items.Count}", "Пошук", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка пошуку: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.LogError("Помилка пошуку", ex);
            }
        }

        private void GoBack()
        {
            if (backHistory.Count > 0)
            {
                forwardHistory.Push(currentPath);
                string path = backHistory.Pop();
                currentPath = path;
                pathBox.Text = path;
                LoadDirectory(path);
            }
        }

        private void GoForward()
        {
            if (forwardHistory.Count > 0)
            {
                backHistory.Push(currentPath);
                string path = forwardHistory.Pop();
                currentPath = path;
                pathBox.Text = path;
                LoadDirectory(path);
            }
        }

        private void GoUp()
        {
            DirectoryInfo parent = Directory.GetParent(currentPath);
            if (parent != null)
            {
                NavigateTo(parent.FullName);
            }
        }

        private void RefreshView()
        {
            LoadDirectory(currentPath);
            logger.Log($"Оновлено вигляд: {currentPath}");
        }

        private string FormatSize(long bytes)
        {
            string[] sizes = { "Б", "КБ", "МБ", "ГБ", "ТБ" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        private string PromptInput(string title, string prompt, string defaultValue = "")
        {
            Form promptForm = new Form
            {
                Width = 400,
                Height = 150,
                Text = title,
                StartPosition = FormStartPosition.CenterParent
            };

            Label label = new Label { Left = 10, Top = 10, Text = prompt, Width = 360 };
            TextBox textBox = new TextBox { Left = 10, Top = 40, Width = 360, Text = defaultValue };
            Button okButton = new Button { Text = "OK", Left = 210, Top = 75, DialogResult = DialogResult.OK };
            Button cancelButton = new Button { Text = "Скасувати", Left = 290, Top = 75, DialogResult = DialogResult.Cancel };

            promptForm.Controls.AddRange(new Control[] { label, textBox, okButton, cancelButton });
            promptForm.AcceptButton = okButton;
            promptForm.CancelButton = cancelButton;

            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            logger.Log("Програма закрита");
            base.OnFormClosing(e);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    // Клас для логування операцій
    public class Logger
    {
        private string logPath;

        public Logger()
        {
            string logDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileExplorer");
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
            logPath = Path.Combine(logDir, $"log_{DateTime.Now:yyyyMMdd}.txt");
        }

        public void Log(string message)
        {
            try
            {
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(logPath, logEntry + Environment.NewLine);
            }
            catch { }
        }

        public void LogError(string message, Exception ex)
        {
            try
            {
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ПОМИЛКА: {message} - {ex.Message}\n{ex.StackTrace}";
                File.AppendAllText(logPath, logEntry + Environment.NewLine);
            }
            catch { }
        }
    }
}