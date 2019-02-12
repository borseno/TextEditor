namespace BorsenoTextEditor
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        
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
            this.FileChoosing = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.resetFileName = new System.Windows.Forms.Button();
            this.CurrentFileNameValue = new System.Windows.Forms.TextBox();
            this.CurrentFileNameLabel = new System.Windows.Forms.Label();
            this.FileMode = new System.Windows.Forms.Button();
            this.ScreenMode = new System.Windows.Forms.Button();
            this.Input = new BorsenoTextEditor.HighlightSupportRichTextBox();
            this.SuspendLayout();
            // 
            // FileChoosing
            // 
            this.FileChoosing.Location = new System.Drawing.Point(12, 12);
            this.FileChoosing.Name = "FileChoosing";
            this.FileChoosing.Size = new System.Drawing.Size(120, 32);
            this.FileChoosing.TabIndex = 1;
            this.FileChoosing.Text = "Choose file to edit";
            this.FileChoosing.UseVisualStyleBackColor = true;
            this.FileChoosing.Click += new System.EventHandler(this.OnFileChoosing);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(852, 12);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(132, 32);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.OnClearing);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(714, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(132, 32);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.OnSaving);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // resetFileName
            // 
            this.resetFileName.Location = new System.Drawing.Point(138, 12);
            this.resetFileName.Name = "resetFileName";
            this.resetFileName.Size = new System.Drawing.Size(123, 32);
            this.resetFileName.TabIndex = 4;
            this.resetFileName.Text = "Unchoose file (reset)";
            this.resetFileName.UseVisualStyleBackColor = true;
            this.resetFileName.Click += new System.EventHandler(this.ResetCurrentFileName);
            // 
            // CurrentFileNameValue
            // 
            this.CurrentFileNameValue.Location = new System.Drawing.Point(367, 19);
            this.CurrentFileNameValue.Name = "CurrentFileNameValue";
            this.CurrentFileNameValue.ReadOnly = true;
            this.CurrentFileNameValue.Size = new System.Drawing.Size(341, 20);
            this.CurrentFileNameValue.TabIndex = 5;
            // 
            // CurrentFileNameLabel
            // 
            this.CurrentFileNameLabel.AutoSize = true;
            this.CurrentFileNameLabel.Location = new System.Drawing.Point(267, 22);
            this.CurrentFileNameLabel.Name = "CurrentFileNameLabel";
            this.CurrentFileNameLabel.Size = new System.Drawing.Size(94, 13);
            this.CurrentFileNameLabel.TabIndex = 6;
            this.CurrentFileNameLabel.Text = "Current File Name:";
            // 
            // FileMode
            // 
            this.FileMode.Location = new System.Drawing.Point(12, 601);
            this.FileMode.Name = "FileMode";
            this.FileMode.Size = new System.Drawing.Size(108, 39);
            this.FileMode.TabIndex = 7;
            this.FileMode.Text = "Explorer mode";
            this.FileMode.UseVisualStyleBackColor = true;
            this.FileMode.Click += new System.EventHandler(this.FileMode_Click);
            // 
            // ScreenMode
            // 
            this.ScreenMode.Location = new System.Drawing.Point(879, 601);
            this.ScreenMode.Name = "ScreenMode";
            this.ScreenMode.Size = new System.Drawing.Size(105, 39);
            this.ScreenMode.TabIndex = 8;
            this.ScreenMode.Text = "Black mode";
            this.ScreenMode.UseVisualStyleBackColor = true;
            this.ScreenMode.Click += new System.EventHandler(this.ScreenMode_Click);
            // 
            // Input
            // 
            this.Input.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Input.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Input.Location = new System.Drawing.Point(12, 50);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(972, 545);
            this.Input.TabIndex = 0;
            this.Input.Text = "";
            this.Input.TextChanged += new System.EventHandler(this.Input_TextChanged);
            this.Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
            this.Input.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.InputPreviewKeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(998, 649);
            this.Controls.Add(this.ScreenMode);
            this.Controls.Add(this.FileMode);
            this.Controls.Add(this.CurrentFileNameLabel);
            this.Controls.Add(this.CurrentFileNameValue);
            this.Controls.Add(this.resetFileName);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.FileChoosing);
            this.Controls.Add(this.Input);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HighlightSupportRichTextBox Input;
        private System.Windows.Forms.Button FileChoosing;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button resetFileName;
        private System.Windows.Forms.TextBox CurrentFileNameValue;
        private System.Windows.Forms.Label CurrentFileNameLabel;
        private System.Windows.Forms.Button FileMode;
        private System.Windows.Forms.Button ScreenMode;
    }
}

