namespace Client
{
    partial class StaffForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PersonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPatronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonId,
            this.PersonLastName,
            this.PersonFirstName,
            this.PersonPatronymic,
            this.PersonGender,
            this.PersonBirthDate});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1138, 453);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // PersonId
            // 
            this.PersonId.HeaderText = "Табельный номер";
            this.PersonId.Name = "PersonId";
            this.PersonId.ReadOnly = true;
            // 
            // PersonLastName
            // 
            this.PersonLastName.HeaderText = "Фамилия";
            this.PersonLastName.Name = "PersonLastName";
            this.PersonLastName.ReadOnly = true;
            this.PersonLastName.Width = 250;
            // 
            // PersonFirstName
            // 
            this.PersonFirstName.HeaderText = "Имя";
            this.PersonFirstName.Name = "PersonFirstName";
            this.PersonFirstName.ReadOnly = true;
            this.PersonFirstName.Width = 150;
            // 
            // PersonPatronymic
            // 
            this.PersonPatronymic.HeaderText = "Отчество";
            this.PersonPatronymic.Name = "PersonPatronymic";
            this.PersonPatronymic.ReadOnly = true;
            this.PersonPatronymic.Width = 150;
            // 
            // PersonGender
            // 
            this.PersonGender.HeaderText = "Пол";
            this.PersonGender.Name = "PersonGender";
            this.PersonGender.ReadOnly = true;
            // 
            // PersonBirthDate
            // 
            this.PersonBirthDate.HeaderText = "Дата рождения";
            this.PersonBirthDate.Name = "PersonBirthDate";
            this.PersonBirthDate.ReadOnly = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(3, 478);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(158, 51);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(193, 478);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(176, 51);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(399, 478);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(184, 51);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 630);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StaffForm";
            this.Text = "Список работников";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Staff_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPatronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonBirthDate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
    }
}