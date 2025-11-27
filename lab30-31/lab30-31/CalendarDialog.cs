using System;
using System.Windows.Forms;

namespace Var26_RS
{
    public partial class CalendarDialog : Form
    {
        public CalendarDialog()
        {
            InitializeComponent();
            lblNow.Text = DateTime.Now.ToString();
        }
    }
}