namespace TIFF_Crypter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OpenAfterCheckBox = new System.Windows.Forms.CheckBox();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.OperationProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.FilePathTextBox);
            this.panel1.Controls.Add(this.FilePathLabel);
            this.panel1.Controls.Add(this.OpenFileButton);
            this.panel1.Name = "panel1";
            // 
            // FilePathTextBox
            // 
            resources.ApplyResources(this.FilePathTextBox, "FilePathTextBox");
            this.FilePathTextBox.Name = "FilePathTextBox";
            // 
            // FilePathLabel
            // 
            resources.ApplyResources(this.FilePathLabel, "FilePathLabel");
            this.FilePathLabel.Name = "FilePathLabel";
            // 
            // OpenFileButton
            // 
            resources.ApplyResources(this.OpenFileButton, "OpenFileButton");
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.OpenAfterCheckBox);
            this.panel2.Controls.Add(this.EncryptButton);
            this.panel2.Controls.Add(this.DecryptButton);
            this.panel2.Controls.Add(this.SaveFileButton);
            this.panel2.Controls.Add(this.OperationProgressBar);
            this.panel2.Name = "panel2";
            // 
            // OpenAfterCheckBox
            // 
            resources.ApplyResources(this.OpenAfterCheckBox, "OpenAfterCheckBox");
            this.OpenAfterCheckBox.Name = "OpenAfterCheckBox";
            this.OpenAfterCheckBox.UseVisualStyleBackColor = true;
            // 
            // EncryptButton
            // 
            resources.ApplyResources(this.EncryptButton, "EncryptButton");
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.UseVisualStyleBackColor = true;
            // 
            // DecryptButton
            // 
            resources.ApplyResources(this.DecryptButton, "DecryptButton");
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.UseVisualStyleBackColor = true;
            // 
            // SaveFileButton
            // 
            resources.ApplyResources(this.SaveFileButton, "SaveFileButton");
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            // 
            // OperationProgressBar
            // 
            resources.ApplyResources(this.OperationProgressBar, "OperationProgressBar");
            this.OperationProgressBar.Name = "OperationProgressBar";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.ProgressBar OperationProgressBar;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.CheckBox OpenAfterCheckBox;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.TextBox FilePathTextBox;
    }
}

