namespace GeneratorTests
{
    partial class StudentForm
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
            this.listBoxQuestions = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFinishTest = new System.Windows.Forms.Button();
            this.btnSubmitAnswer = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.lableInput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxQuestions
            // 
            this.listBoxQuestions.Font = new System.Drawing.Font("Courier New", 9F);
            this.listBoxQuestions.ItemHeight = 15;
            this.listBoxQuestions.Location = new System.Drawing.Point(12, 6);
            this.listBoxQuestions.Name = "listBoxQuestions";
            this.listBoxQuestions.Size = new System.Drawing.Size(660, 364);
            this.listBoxQuestions.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 444);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(660, 30);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Студент";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Enabled = false;
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtAnswer.Location = new System.Drawing.Point(131, 410);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(200, 29);
            this.txtAnswer.TabIndex = 13;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(330, 379);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnFinishTest
            // 
            this.btnFinishTest.Enabled = false;
            this.btnFinishTest.Location = new System.Drawing.Point(224, 379);
            this.btnFinishTest.Name = "btnFinishTest";
            this.btnFinishTest.Size = new System.Drawing.Size(100, 30);
            this.btnFinishTest.TabIndex = 11;
            this.btnFinishTest.Text = "Завершить";
            this.btnFinishTest.UseVisualStyleBackColor = true;
            // 
            // btnSubmitAnswer
            // 
            this.btnSubmitAnswer.Enabled = false;
            this.btnSubmitAnswer.Location = new System.Drawing.Point(118, 379);
            this.btnSubmitAnswer.Name = "btnSubmitAnswer";
            this.btnSubmitAnswer.Size = new System.Drawing.Size(100, 30);
            this.btnSubmitAnswer.TabIndex = 10;
            this.btnSubmitAnswer.Text = "Ответить";
            this.btnSubmitAnswer.UseVisualStyleBackColor = true;
            this.btnSubmitAnswer.Click += new System.EventHandler(this.btnSubmitAnswer_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(12, 379);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(100, 30);
            this.btnStartTest.TabIndex = 9;
            this.btnStartTest.Text = "Начать тест";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // lableInput
            // 
            this.lableInput.AutoSize = true;
            this.lableInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lableInput.Location = new System.Drawing.Point(12, 414);
            this.lableInput.Name = "lableInput";
            this.lableInput.Size = new System.Drawing.Size(113, 18);
            this.lableInput.TabIndex = 8;
            this.lableInput.Text = "Введите ответ:";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 480);
            this.Controls.Add(this.listBoxQuestions);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnFinishTest);
            this.Controls.Add(this.btnSubmitAnswer);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.lableInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Студент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox listBoxQuestions;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFinishTest;
        private System.Windows.Forms.Button btnSubmitAnswer;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Label lableInput;
    }
}