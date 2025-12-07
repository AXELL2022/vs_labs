using System;
using System.Windows.Forms;

namespace WinFChartSin1
{
    static class Program
    {
        /// <summary>
        /// Точка входу для програми.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}