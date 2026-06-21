namespace GeneratorTests
{
    partial class TeacherForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTopic = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.lblVariants = new System.Windows.Forms.Label();
            this.cmbTopics = new System.Windows.Forms.ComboBox();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.numQuestions = new System.Windows.Forms.NumericUpDown();
            this.numVariants = new System.Windows.Forms.NumericUpDown();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGenerateVariants = new System.Windows.Forms.Button();
            this.btnSaveWord = new System.Windows.Forms.Button();
            this.btnEditQuestion = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.listBoxQuestions = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariants)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.Location = new System.Drawing.Point(12, 15);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(37, 13);
            this.lblTopic.TabIndex = 0;
            this.lblTopic.Text = "Тема:";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(212, 15);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(66, 13);
            this.lblDifficulty.TabIndex = 1;
            this.lblDifficulty.Text = "Сложность:";
            // 
            // lblQuestions
            // 
            this.lblQuestions.AutoSize = true;
            this.lblQuestions.Location = new System.Drawing.Point(382, 15);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(59, 13);
            this.lblQuestions.TabIndex = 2;
            this.lblQuestions.Text = "Вопросов:";
            // 
            // lblVariants
            // 
            this.lblVariants.AutoSize = true;
            this.lblVariants.Location = new System.Drawing.Point(532, 15);
            this.lblVariants.Name = "lblVariants";
            this.lblVariants.Size = new System.Drawing.Size(64, 13);
            this.lblVariants.TabIndex = 3;
            this.lblVariants.Text = "Вариантов:";
            // 
            // cmbTopics
            // 
            this.cmbTopics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopics.Location = new System.Drawing.Point(72, 12);
            this.cmbTopics.Name = "cmbTopics";
            this.cmbTopics.Size = new System.Drawing.Size(120, 21);
            this.cmbTopics.TabIndex = 4;
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.Items.AddRange(new object[] {
            "Все",
            "лёгкий",
            "средний",
            "сложный"});
            this.cmbDifficulty.Location = new System.Drawing.Point(282, 12);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(80, 21);
            this.cmbDifficulty.TabIndex = 5;
            // 
            // numQuestions
            // 
            this.numQuestions.Location = new System.Drawing.Point(452, 12);
            this.numQuestions.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numQuestions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuestions.Name = "numQuestions";
            this.numQuestions.Size = new System.Drawing.Size(60, 20);
            this.numQuestions.TabIndex = 6;
            this.numQuestions.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numVariants
            // 
            this.numVariants.Location = new System.Drawing.Point(602, 12);
            this.numVariants.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numVariants.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVariants.Name = "numVariants";
            this.numVariants.Size = new System.Drawing.Size(60, 20);
            this.numVariants.TabIndex = 7;
            this.numVariants.Value = new decimal(new int[] {
            2,0,0,0});
            
            this.btnLoad.Location = new System.Drawing.Point(12, 45);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            
            this.btnGenerateVariants.Location = new System.Drawing.Point(118, 45);
            this.btnGenerateVariants.Name = "btnGenerateVariants";
            this.btnGenerateVariants.Size = new System.Drawing.Size(100, 30);
            this.btnGenerateVariants.TabIndex = 9;
            this.btnGenerateVariants.Text = "Варианты";
            this.btnGenerateVariants.UseVisualStyleBackColor = true;
            this.btnGenerateVariants.Click += new System.EventHandler(this.btnGenerateVariants_Click);
             
            this.btnSaveWord.Location = new System.Drawing.Point(224, 45);
            this.btnSaveWord.Name = "btnSaveWord";
            this.btnSaveWord.Size = new System.Drawing.Size(100, 30);
            this.btnSaveWord.TabIndex = 10;
            this.btnSaveWord.Text = "Сохранить";
            this.btnSaveWord.UseVisualStyleBackColor = true;
            this.btnSaveWord.Click += new System.EventHandler(this.btnSaveWord_Click);
            
            this.btnEditQuestion.Location = new System.Drawing.Point(330, 45);
            this.btnEditQuestion.Name = "btnEditQuestion";
            this.btnEditQuestion.Size = new System.Drawing.Size(100, 30);
            this.btnEditQuestion.TabIndex = 11;
            this.btnEditQuestion.Text = "Ред.";
            this.btnEditQuestion.UseVisualStyleBackColor = true;
            this.btnEditQuestion.Click += new System.EventHandler(this.btnEditQuestion_Click);
            
            this.btnExit.Location = new System.Drawing.Point(594, 45);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            
            this.listBoxQuestions.Font = new System.Drawing.Font("Courier New", 9F);
            this.listBoxQuestions.ItemHeight = 15;
            this.listBoxQuestions.Location = new System.Drawing.Point(12, 85);
            this.listBoxQuestions.Name = "listBoxQuestions";
            this.listBoxQuestions.Size = new System.Drawing.Size(660, 349);
            this.listBoxQuestions.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 440);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(660, 30);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Режим: Преподаватель";
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 480);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listBoxQuestions);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEditQuestion);
            this.Controls.Add(this.btnSaveWord);
            this.Controls.Add(this.btnGenerateVariants);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.numVariants);
            this.Controls.Add(this.numQuestions);
            this.Controls.Add(this.cmbDifficulty);
            this.Controls.Add(this.cmbTopics);
            this.Controls.Add(this.lblVariants);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lblTopic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Преподаватель";
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblQuestions;
        private System.Windows.Forms.Label lblVariants;
        private System.Windows.Forms.ComboBox cmbTopics;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.NumericUpDown numQuestions;
        private System.Windows.Forms.NumericUpDown numVariants;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnGenerateVariants;
        private System.Windows.Forms.Button btnSaveWord;
        private System.Windows.Forms.Button btnEditQuestion;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox listBoxQuestions;
        private System.Windows.Forms.Label lblStatus;
    }
}