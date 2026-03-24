namespace library.Forms
{
    partial class UserMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMainForm));
            SearchBtn = new Button();
            SearchBox = new TextBox();
            BooksDataGrid = new DataGridView();
            ProfileBtn = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)BooksDataGrid).BeginInit();
            SuspendLayout();
            // 
            // SearchBtn
            // 
            SearchBtn.BackColor = SystemColors.ButtonFace;
            SearchBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SearchBtn.Location = new Point(747, 70);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(119, 27);
            SearchBtn.TabIndex = 0;
            SearchBtn.Text = "Поиск";
            SearchBtn.UseVisualStyleBackColor = false;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(12, 70);
            SearchBox.Name = "SearchBox";
            SearchBox.PlaceholderText = "Название книги";
            SearchBox.Size = new Size(469, 27);
            SearchBox.TabIndex = 1;
            // 
            // BooksDataGrid
            // 
            BooksDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BooksDataGrid.Location = new Point(12, 113);
            BooksDataGrid.Name = "BooksDataGrid";
            BooksDataGrid.RowHeadersWidth = 51;
            BooksDataGrid.Size = new Size(854, 286);
            BooksDataGrid.TabIndex = 2;
            // 
            // ProfileBtn
            // 
            ProfileBtn.BackColor = Color.LightGray;
            ProfileBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ProfileBtn.Location = new Point(12, 12);
            ProfileBtn.Name = "ProfileBtn";
            ProfileBtn.Size = new Size(99, 43);
            ProfileBtn.TabIndex = 3;
            ProfileBtn.Text = "Профиль";
            ProfileBtn.UseVisualStyleBackColor = false;
            ProfileBtn.Click += ProfileBtn_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightGray;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Location = new Point(767, 419);
            button2.Name = "button2";
            button2.Size = new Size(99, 43);
            button2.TabIndex = 5;
            button2.Text = "Выйти";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGray;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(12, 419);
            button1.Name = "button1";
            button1.Size = new Size(244, 43);
            button1.TabIndex = 6;
            button1.Text = "Связаться с нами";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // UserMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(878, 493);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(ProfileBtn);
            Controls.Add(BooksDataGrid);
            Controls.Add(SearchBox);
            Controls.Add(SearchBtn);
            Name = "UserMainForm";
            Text = "UserMainForm";
            ((System.ComponentModel.ISupportInitialize)BooksDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchBtn;
        private TextBox SearchBox;
        private DataGridView BooksDataGrid;
        private Button ProfileBtn;
        private Button button2;
        private Button button1;
    }
}