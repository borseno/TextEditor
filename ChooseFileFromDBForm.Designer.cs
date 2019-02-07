namespace BorsenoTextEditor
{
    partial class ChooseFileFromDBForm
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
            this.filesDBdataGridView = new System.Windows.Forms.DataGridView();
            this.tableDescription = new System.Windows.Forms.Label();
            this.SelectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.filesDBdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filesDBdataGridView
            // 
            this.filesDBdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesDBdataGridView.Location = new System.Drawing.Point(5, 40);
            this.filesDBdataGridView.Name = "filesDBdataGridView";
            this.filesDBdataGridView.ReadOnly = true;
            this.filesDBdataGridView.Size = new System.Drawing.Size(258, 340);
            this.filesDBdataGridView.TabIndex = 0;
 
            // 
            // tableDescription
            // 
            this.tableDescription.AutoSize = true;
            this.tableDescription.Location = new System.Drawing.Point(24, 15);
            this.tableDescription.Name = "tableDescription";
            this.tableDescription.Size = new System.Drawing.Size(213, 13);
            this.tableDescription.TabIndex = 1;
            this.tableDescription.Text = "Select name of the text you want to change";
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(12, 386);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(244, 46);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.OnSelected);
            // 
            // ChooseFileFromDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 444);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.tableDescription);
            this.Controls.Add(this.filesDBdataGridView);
            this.Name = "ChooseFileFromDBForm";
            this.Text = "ChooseFileFromDBForm";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.filesDBdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView filesDBdataGridView;
        private System.Windows.Forms.Label tableDescription;
        private System.Windows.Forms.Button SelectButton;
    }
}