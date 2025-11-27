namespace RatingPerformers
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPerformer = new System.Windows.Forms.Label();
            this.cmbPerformer = new System.Windows.Forms.ComboBox();
            this.lblRespondent = new System.Windows.Forms.Label();
            this.txtRespondent = new System.Windows.Forms.TextBox();
            this.grpListening = new System.Windows.Forms.GroupBox();
            this.rbSometimes = new System.Windows.Forms.RadioButton();
            this.rbNotListen = new System.Windows.Forms.RadioButton();
            this.rbListen = new System.Windows.Forms.RadioButton();
            this.grpPreferences = new System.Windows.Forms.GroupBox();
            this.chkRepertoire = new System.Windows.Forms.CheckBox();
            this.chkAppearance = new System.Windows.Forms.CheckBox();
            this.chkManner = new System.Windows.Forms.CheckBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.grpListening.SuspendLayout();
            this.grpPreferences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPerformer
            // 
            this.lblPerformer.AutoSize = true;
            this.lblPerformer.Location = new System.Drawing.Point(20, 150);
            this.lblPerformer.Name = "lblPerformer";
            this.lblPerformer.Size = new System.Drawing.Size(111, 13);
            this.lblPerformer.TabIndex = 1;
            this.lblPerformer.Text = "Виберіть виконавця:";
            // 
            // cmbPerformer
            // 
            this.cmbPerformer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerformer.FormattingEnabled = true;
            this.cmbPerformer.Items.AddRange(new object[] {
            "Океан Ельзи",
            "ТНМК",
            "Скрябін",
            "Друга Ріка",
            "Jamala",
            "Onuka"});
            this.cmbPerformer.Location = new System.Drawing.Point(20, 175);
            this.cmbPerformer.Name = "cmbPerformer";
            this.cmbPerformer.Size = new System.Drawing.Size(500, 21);
            this.cmbPerformer.TabIndex = 2;
            // 
            // lblRespondent
            // 
            this.lblRespondent.AutoSize = true;
            this.lblRespondent.Location = new System.Drawing.Point(20, 210);
            this.lblRespondent.Name = "lblRespondent";
            this.lblRespondent.Size = new System.Drawing.Size(156, 13);
            this.lblRespondent.TabIndex = 3;
            this.lblRespondent.Text = "Інформація про респондента:";
            // 
            // txtRespondent
            // 
            this.txtRespondent.Location = new System.Drawing.Point(20, 235);
            this.txtRespondent.Name = "txtRespondent";
            this.txtRespondent.Size = new System.Drawing.Size(500, 20);
            this.txtRespondent.TabIndex = 4;
            // 
            // grpListening
            // 
            this.grpListening.Controls.Add(this.rbSometimes);
            this.grpListening.Controls.Add(this.rbNotListen);
            this.grpListening.Controls.Add(this.rbListen);
            this.grpListening.Location = new System.Drawing.Point(20, 270);
            this.grpListening.Name = "grpListening";
            this.grpListening.Size = new System.Drawing.Size(240, 110);
            this.grpListening.TabIndex = 5;
            this.grpListening.TabStop = false;
            this.grpListening.Text = "Ви слухаєте цього виконавця?";
            // 
            // rbSometimes
            // 
            this.rbSometimes.AutoSize = true;
            this.rbSometimes.Location = new System.Drawing.Point(15, 75);
            this.rbSometimes.Name = "rbSometimes";
            this.rbSometimes.Size = new System.Drawing.Size(48, 17);
            this.rbSometimes.TabIndex = 2;
            this.rbSometimes.Tag = "1";
            this.rbSometimes.Text = "Іноді";
            this.rbSometimes.UseVisualStyleBackColor = true;
            // 
            // rbNotListen
            // 
            this.rbNotListen.AutoSize = true;
            this.rbNotListen.Location = new System.Drawing.Point(15, 50);
            this.rbNotListen.Name = "rbNotListen";
            this.rbNotListen.Size = new System.Drawing.Size(78, 17);
            this.rbNotListen.TabIndex = 1;
            this.rbNotListen.Tag = "0";
            this.rbNotListen.Text = "Не слухаю";
            this.rbNotListen.UseVisualStyleBackColor = true;
            // 
            // rbListen
            // 
            this.rbListen.AutoSize = true;
            this.rbListen.Checked = true;
            this.rbListen.Location = new System.Drawing.Point(15, 25);
            this.rbListen.Name = "rbListen";
            this.rbListen.Size = new System.Drawing.Size(62, 17);
            this.rbListen.TabIndex = 0;
            this.rbListen.TabStop = true;
            this.rbListen.Tag = "3";
            this.rbListen.Text = "Слухаю";
            this.rbListen.UseVisualStyleBackColor = true;
            // 
            // grpPreferences
            // 
            this.grpPreferences.Controls.Add(this.chkRepertoire);
            this.grpPreferences.Controls.Add(this.chkAppearance);
            this.grpPreferences.Controls.Add(this.chkManner);
            this.grpPreferences.Location = new System.Drawing.Point(280, 270);
            this.grpPreferences.Name = "grpPreferences";
            this.grpPreferences.Size = new System.Drawing.Size(240, 110);
            this.grpPreferences.TabIndex = 6;
            this.grpPreferences.TabStop = false;
            this.grpPreferences.Text = "Що вам подобається?";
            // 
            // chkRepertoire
            // 
            this.chkRepertoire.AutoSize = true;
            this.chkRepertoire.Location = new System.Drawing.Point(15, 75);
            this.chkRepertoire.Name = "chkRepertoire";
            this.chkRepertoire.Size = new System.Drawing.Size(79, 17);
            this.chkRepertoire.TabIndex = 2;
            this.chkRepertoire.Tag = "2";
            this.chkRepertoire.Text = "Репертуар";
            this.chkRepertoire.UseVisualStyleBackColor = true;
            // 
            // chkAppearance
            // 
            this.chkAppearance.AutoSize = true;
            this.chkAppearance.Location = new System.Drawing.Point(15, 50);
            this.chkAppearance.Name = "chkAppearance";
            this.chkAppearance.Size = new System.Drawing.Size(113, 17);
            this.chkAppearance.TabIndex = 1;
            this.chkAppearance.Tag = "1";
            this.chkAppearance.Text = "Зовнішній вигляд";
            this.chkAppearance.UseVisualStyleBackColor = true;
            // 
            // chkManner
            // 
            this.chkManner.AutoSize = true;
            this.chkManner.Location = new System.Drawing.Point(15, 25);
            this.chkManner.Name = "chkManner";
            this.chkManner.Size = new System.Drawing.Size(122, 17);
            this.chkManner.TabIndex = 0;
            this.chkManner.Tag = "2";
            this.chkManner.Text = "Манера виконання";
            this.chkManner.UseVisualStyleBackColor = true;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(20, 390);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(84, 13);
            this.lblRating.TabIndex = 7;
            this.lblRating.Text = "Рейтинг (бали):";
            // 
            // txtRating
            // 
            this.txtRating.BackColor = System.Drawing.Color.LightYellow;
            this.txtRating.Location = new System.Drawing.Point(145, 387);
            this.txtRating.Name = "txtRating";
            this.txtRating.ReadOnly = true;
            this.txtRating.Size = new System.Drawing.Size(375, 20);
            this.txtRating.TabIndex = 8;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.Location = new System.Drawing.Point(20, 430);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(240, 35);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "=";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(280, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(240, 35);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Закрити";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = global::lab28_29.Properties.Resources.unnamed;
            this.pictureBox.Location = new System.Drawing.Point(20, 20);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(496, 127);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 486);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.grpPreferences);
            this.Controls.Add(this.grpListening);
            this.Controls.Add(this.txtRespondent);
            this.Controls.Add(this.lblRespondent);
            this.Controls.Add(this.cmbPerformer);
            this.Controls.Add(this.lblPerformer);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рейтинг виконавців";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.grpListening.ResumeLayout(false);
            this.grpListening.PerformLayout();
            this.grpPreferences.ResumeLayout(false);
            this.grpPreferences.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblPerformer;
        private System.Windows.Forms.ComboBox cmbPerformer;
        private System.Windows.Forms.Label lblRespondent;
        private System.Windows.Forms.TextBox txtRespondent;
        private System.Windows.Forms.GroupBox grpListening;
        private System.Windows.Forms.RadioButton rbSometimes;
        private System.Windows.Forms.RadioButton rbNotListen;
        private System.Windows.Forms.RadioButton rbListen;
        private System.Windows.Forms.GroupBox grpPreferences;
        private System.Windows.Forms.CheckBox chkRepertoire;
        private System.Windows.Forms.CheckBox chkAppearance;
        private System.Windows.Forms.CheckBox chkManner;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClose;
    }
}