namespace library.Forms
{
    partial class AdminMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMainForm));
            AddBookBtn = new Button();
            CheckAllBooksBtn = new Button();
            AddNewUserBtn = new Button();
            label1 = new Label();
            HelpBtn = new Button();
            ExitBtn = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // AddBookBtn
            // 
            AddBookBtn.Location = new Point(34, 113);
            AddBookBtn.Name = "AddBookBtn";
            AddBookBtn.Size = new Size(264, 40);
            AddBookBtn.TabIndex = 0;
            AddBookBtn.Text = "Добавить книгу";
            AddBookBtn.UseVisualStyleBackColor = true;
            AddBookBtn.Click += AddBookBtn_Click;
            // 
            // CheckAllBooksBtn
            // 
            CheckAllBooksBtn.Location = new Point(34, 182);
            CheckAllBooksBtn.Name = "CheckAllBooksBtn";
            CheckAllBooksBtn.Size = new Size(264, 40);
            CheckAllBooksBtn.TabIndex = 1;
            CheckAllBooksBtn.Text = "Посмотреть книги";
            CheckAllBooksBtn.UseVisualStyleBackColor = true;
            CheckAllBooksBtn.Click += CheckAllBooksBtn_Click;
            // 
            // AddNewUserBtn
            // 
            AddNewUserBtn.Location = new Point(34, 244);
            AddNewUserBtn.Name = "AddNewUserBtn";
            AddNewUserBtn.Size = new Size(264, 40);
            AddNewUserBtn.TabIndex = 2;
            AddNewUserBtn.Text = "Добавить пользователя";
            AddNewUserBtn.UseVisualStyleBackColor = true;
            AddNewUserBtn.Click += AddNewUserBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(111, 22);
            label1.Name = "label1";
            label1.Size = new Size(406, 54);
            label1.TabIndex = 3;
            label1.Text = "АДМИНИСТРАЦИЯ";
            // 
            // HelpBtn
            // 
            HelpBtn.Location = new Point(318, 512);
            HelpBtn.Name = "HelpBtn";
            HelpBtn.Size = new Size(148, 29);
            HelpBtn.TabIndex = 4;
            HelpBtn.Text = "Поддержка";
            HelpBtn.UseVisualStyleBackColor = true;
            HelpBtn.Click += HelpBtn_Click;
            // 
            // ExitBtn
            // 
            ExitBtn.BackColor = SystemColors.ButtonFace;
            ExitBtn.Location = new Point(485, 512);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(135, 29);
            ExitBtn.TabIndex = 5;
            ExitBtn.Text = "Выйти";
            ExitBtn.UseVisualStyleBackColor = false;
            ExitBtn.Click += ExitBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(318, 113);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(302, 297);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(632, 553);
            Controls.Add(pictureBox1);
            Controls.Add(ExitBtn);
            Controls.Add(HelpBtn);
            Controls.Add(label1);
            Controls.Add(AddNewUserBtn);
            Controls.Add(CheckAllBooksBtn);
            Controls.Add(AddBookBtn);
            Name = "AdminMainForm";
            Text = "AdminMainForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddBookBtn;
        private Button CheckAllBooksBtn;
        private Button AddNewUserBtn;
        private Label label1;
        private Button HelpBtn;
        private Button ExitBtn;
        private PictureBox pictureBox1;
    }
}