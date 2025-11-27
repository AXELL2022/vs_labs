using System.IO;
using System.Windows.Forms;

namespace Var26_RS
{
    public partial class FileViewer : Form
    {
        public FileViewer(string path)
        {
            InitializeComponent();
            textBox1.Text = File.ReadAllText(path);
        }
    }
}