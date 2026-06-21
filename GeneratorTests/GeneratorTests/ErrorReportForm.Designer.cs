namespace GeneratorTests
{
    partial class ErrorReportForm
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
            this.txtErrors = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.txtErrors.Location = new System.Drawing.Point(12, 12);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.Size = new System.Drawing.Size(600, 350);
            this.txtErrors.TabIndex = 0;
            this.txtErrors.Text = "";
            
            this.btnOk.Location = new System.Drawing.Point(260, 370);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 30);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            
            this.ClientSize = new System.Drawing.Size(624, 410);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtErrors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчет об ошибках";
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.RichTextBox txtErrors;
        public System.Windows.Forms.Button btnOk;
    }
}