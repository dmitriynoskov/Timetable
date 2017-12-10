namespace Client
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.WorkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimetableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkersToolStripMenuItem,
            this.TimetableMenuItem,
            this.AboutToolStripMenuItem,
            this.btnExitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1142, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // WorkersToolStripMenuItem
            // 
            this.WorkersToolStripMenuItem.Name = "WorkersToolStripMenuItem";
            this.WorkersToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.WorkersToolStripMenuItem.Text = "&Работники";
            this.WorkersToolStripMenuItem.Click += new System.EventHandler(this.WorkersToolStripMenuItem_Click);
            // 
            // TimetableMenuItem
            // 
            this.TimetableMenuItem.Name = "TimetableMenuItem";
            this.TimetableMenuItem.Size = new System.Drawing.Size(70, 24);
            this.TimetableMenuItem.Text = "&Табель";
            this.TimetableMenuItem.Click += new System.EventHandler(this.TimetableMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.AboutToolStripMenuItem.Text = "&О программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // btnExitToolStripMenuItem
            // 
            this.btnExitToolStripMenuItem.Name = "btnExitToolStripMenuItem";
            this.btnExitToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.btnExitToolStripMenuItem.Text = "&Выход";
            this.btnExitToolStripMenuItem.Click += new System.EventHandler(this.btnExitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 630);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Табель сотрудников";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem WorkersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TimetableMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnExitToolStripMenuItem;
    }
}

