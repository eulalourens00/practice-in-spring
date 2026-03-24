namespace library.Forms
{
    partial class BookEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookEditForm));
            OneBookDataGrid = new DataGridView();
            DeleteBookBtn = new Button();
            ChangeBookBtn = new Button();
            ExitBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)OneBookDataGrid).BeginInit();
            SuspendLayout();
            // 
            // OneBookDataGrid
            // 
            OneBookDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OneBookDataGrid.Location = new Point(26, 64);
            OneBookDataGrid.Name = "OneBookDataGrid";
            OneBookDataGrid.RowHeadersWidth = 51;
            OneBookDataGrid.Size = new Size(581, 343);
            OneBookDataGrid.TabIndex = 0;
            // 
            // DeleteBookBtn
            // 
            DeleteBookBtn.BackColor = Color.LightCoral;
            DeleteBookBtn.Location = new Point(463, 502);
            DeleteBookBtn.Name = "DeleteBookBtn";
            DeleteBookBtn.Size = new Size(144, 29);
            DeleteBookBtn.TabIndex = 1;
            DeleteBookBtn.Text = "Удалить";
            DeleteBookBtn.UseVisualStyleBackColor = false;
            DeleteBookBtn.Click += DeleteBookBtn_Click;
            // 
            // ChangeBookBtn
            // 
            ChangeBookBtn.BackColor = Color.CadetBlue;
            ChangeBookBtn.Location = new Point(463, 424);
            ChangeBookBtn.Name = "ChangeBookBtn";
            ChangeBookBtn.Size = new Size(144, 60);
            ChangeBookBtn.TabIndex = 2;
            ChangeBookBtn.Text = "Редактировать";
            ChangeBookBtn.UseVisualStyleBackColor = false;
            ChangeBookBtn.Click += ChangeBookBtn_Click;
            // 
            // ExitBtn
            // 
            ExitBtn.BackColor = SystemColors.ActiveCaption;
            ExitBtn.Location = new Point(26, 12);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(94, 29);
            ExitBtn.TabIndex = 3;
            ExitBtn.Text = "Назад";
            ExitBtn.UseVisualStyleBackColor = false;
            ExitBtn.Click += ExitBtn_Click;
            // 
            // BookEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(632, 553);
            Controls.Add(ExitBtn);
            Controls.Add(ChangeBookBtn);
            Controls.Add(DeleteBookBtn);
            Controls.Add(OneBookDataGrid);
            Name = "BookEditForm";
            Text = "BookEditForm";
            ((System.ComponentModel.ISupportInitialize)OneBookDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView OneBookDataGrid;
        private Button DeleteBookBtn;
        private Button ChangeBookBtn;
        private Button ExitBtn;
    }
}