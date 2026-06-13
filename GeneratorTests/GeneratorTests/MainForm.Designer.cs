namespace GeneratorTests
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
            this.lableInput = new System.Windows.Forms.Label();
            this.lblTopic = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.lblVariants = new System.Windows.Forms.Label();
            this.cmbTopics = new System.Windows.Forms.ComboBox();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.numQuestions = new System.Windows.Forms.NumericUpDown();
            this.numVariants = new System.Windows.Forms.NumericUpDown();
            this.btnLoginTeacher = new System.Windows.Forms.Button();
            this.btnLoginStudent = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGenerateVariants = new System.Windows.Forms.Button();
            this.btnSaveWord = new System.Windows.Forms.Button();
            this.btnEditQuestion = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.btnSubmitAnswer = new System.Windows.Forms.Button();
            this.btnFinishTest = new System.Windows.Forms.Button();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.listBoxQuestions = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariants)).BeginInit();
            this.SuspendLayout();
            // 
            // lableInput
            // 
            this.lableInput.AutoSize = true;
            this.lableInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lableInput.Location = new System.Drawing.Point(426, 429);
            this.lableInput.Name = "lableInput";
            this.lableInput.Size = new System.Drawing.Size(113, 18);
            this.lableInput.TabIndex = 43;
            this.lableInput.Text = "Введите ответ:";
            // 
            // lblTopic
            // 
            this.lblTopic.Location = new System.Drawing.Point(14, 14);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(50, 20);
            this.lblTopic.TabIndex = 22;
            this.lblTopic.Text = "Тема:";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.Location = new System.Drawing.Point(214, 14);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(70, 20);
            this.lblDifficulty.TabIndex = 23;
            this.lblDifficulty.Text = "Сложность:";
            // 
            // lblQuestions
            // 
            this.lblQuestions.Location = new System.Drawing.Point(384, 14);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(70, 20);
            this.lblQuestions.TabIndex = 24;
            this.lblQuestions.Text = "Вопросов:";
            // 
            // lblVariants
            // 
            this.lblVariants.Location = new System.Drawing.Point(534, 14);
            this.lblVariants.Name = "lblVariants";
            this.lblVariants.Size = new System.Drawing.Size(70, 20);
            this.lblVariants.TabIndex = 25;
            this.lblVariants.Text = "Вариантов:";
            // 
            // cmbTopics
            // 
            this.cmbTopics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopics.Location = new System.Drawing.Point(74, 12);
            this.cmbTopics.Name = "cmbTopics";
            this.cmbTopics.Size = new System.Drawing.Size(120, 21);
            this.cmbTopics.TabIndex = 26;
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.Items.AddRange(new object[] {
            "Все",
            "лёгкий",
            "средний",
            "сложный"});
            this.cmbDifficulty.Location = new System.Drawing.Point(284, 12);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(80, 21);
            this.cmbDifficulty.TabIndex = 27;
            // 
            // numQuestions
            // 
            this.numQuestions.Location = new System.Drawing.Point(454, 12);
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
            this.numQuestions.TabIndex = 28;
            this.numQuestions.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numVariants
            // 
            this.numVariants.Location = new System.Drawing.Point(604, 12);
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
            this.numVariants.TabIndex = 29;
            this.numVariants.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnLoginTeacher
            // 
            this.btnLoginTeacher.Location = new System.Drawing.Point(13, 41);
            this.btnLoginTeacher.Name = "btnLoginTeacher";
            this.btnLoginTeacher.Size = new System.Drawing.Size(100, 30);
            this.btnLoginTeacher.TabIndex = 30;
            this.btnLoginTeacher.Text = "Вход (учитель)";
            // 
            // btnLoginStudent
            // 
            this.btnLoginStudent.Location = new System.Drawing.Point(123, 41);
            this.btnLoginStudent.Name = "btnLoginStudent";
            this.btnLoginStudent.Size = new System.Drawing.Size(100, 30);
            this.btnLoginStudent.TabIndex = 31;
            this.btnLoginStudent.Text = "Вход (студент)";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(233, 41);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 30);
            this.btnLoad.TabIndex = 32;
            this.btnLoad.Text = "Загрузить";
            // 
            // btnGenerateVariants
            // 
            this.btnGenerateVariants.Location = new System.Drawing.Point(324, 41);
            this.btnGenerateVariants.Name = "btnGenerateVariants";
            this.btnGenerateVariants.Size = new System.Drawing.Size(80, 30);
            this.btnGenerateVariants.TabIndex = 34;
            this.btnGenerateVariants.Text = "Варианты";
            // 
            // btnSaveWord
            // 
            this.btnSaveWord.Location = new System.Drawing.Point(414, 41);
            this.btnSaveWord.Name = "btnSaveWord";
            this.btnSaveWord.Size = new System.Drawing.Size(80, 30);
            this.btnSaveWord.TabIndex = 35;
            this.btnSaveWord.Text = "Сохранить";
            // 
            // btnEditQuestion
            // 
            this.btnEditQuestion.Location = new System.Drawing.Point(504, 41);
            this.btnEditQuestion.Name = "btnEditQuestion";
            this.btnEditQuestion.Size = new System.Drawing.Size(80, 30);
            this.btnEditQuestion.TabIndex = 36;
            this.btnEditQuestion.Text = "Ред.";
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(13, 421);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(100, 30);
            this.btnStartTest.TabIndex = 37;
            this.btnStartTest.Text = "Начать тест";
            // 
            // btnSubmitAnswer
            // 
            this.btnSubmitAnswer.Location = new System.Drawing.Point(123, 421);
            this.btnSubmitAnswer.Name = "btnSubmitAnswer";
            this.btnSubmitAnswer.Size = new System.Drawing.Size(100, 30);
            this.btnSubmitAnswer.TabIndex = 38;
            this.btnSubmitAnswer.Text = "Ответить";
            // 
            // btnFinishTest
            // 
            this.btnFinishTest.Location = new System.Drawing.Point(233, 421);
            this.btnFinishTest.Name = "btnFinishTest";
            this.btnFinishTest.Size = new System.Drawing.Size(100, 30);
            this.btnFinishTest.TabIndex = 39;
            this.btnFinishTest.Text = "Завершить";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAnswer.Location = new System.Drawing.Point(545, 422);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(128, 29);
            this.txtAnswer.TabIndex = 41;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(13, 461);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(660, 40);
            this.lblStatus.TabIndex = 42;
            // 
            // listBoxQuestions
            // 
            this.listBoxQuestions.Font = new System.Drawing.Font("Courier New", 9F);
            this.listBoxQuestions.ItemHeight = 15;
            this.listBoxQuestions.Location = new System.Drawing.Point(13, 81);
            this.listBoxQuestions.Name = "listBoxQuestions";
            this.listBoxQuestions.Size = new System.Drawing.Size(660, 319);
            this.listBoxQuestions.TabIndex = 40;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 510);
            this.Controls.Add(this.lableInput);
            this.Controls.Add(this.lblTopic);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.lblVariants);
            this.Controls.Add(this.cmbTopics);
            this.Controls.Add(this.cmbDifficulty);
            this.Controls.Add(this.numQuestions);
            this.Controls.Add(this.numVariants);
            this.Controls.Add(this.btnLoginTeacher);
            this.Controls.Add(this.btnLoginStudent);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnGenerateVariants);
            this.Controls.Add(this.btnSaveWord);
            this.Controls.Add(this.btnEditQuestion);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.btnSubmitAnswer);
            this.Controls.Add(this.btnFinishTest);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listBoxQuestions);
            this.Name = "MainForm";
            this.Text = "Программа для создания тестов";
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVariants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lableInput;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblQuestions;
        private System.Windows.Forms.Label lblVariants;
        private System.Windows.Forms.ComboBox cmbTopics;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.NumericUpDown numQuestions;
        private System.Windows.Forms.NumericUpDown numVariants;
        private System.Windows.Forms.Button btnLoginTeacher;
        private System.Windows.Forms.Button btnLoginStudent;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnGenerateVariants;
        private System.Windows.Forms.Button btnSaveWord;
        private System.Windows.Forms.Button btnEditQuestion;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Button btnSubmitAnswer;
        private System.Windows.Forms.Button btnFinishTest;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox listBoxQuestions;
    }
}

