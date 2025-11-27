namespace Var26_RS
{
    partial class CalendarDialog
    {
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Label lblNow;

        private void InitializeComponent()
        {
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.lblNow = new System.Windows.Forms.Label();

            this.calendar.Location = new System.Drawing.Point(20, 20);

            this.lblNow.Location = new System.Drawing.Point(20, 200);
            this.lblNow.AutoSize = true;

            this.ClientSize = new System.Drawing.Size(300, 260);
            this.Controls.Add(calendar);
            this.Controls.Add(lblNow);

            this.Text = "Календар";
        }
    }
}