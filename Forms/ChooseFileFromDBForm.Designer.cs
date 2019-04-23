using System.Windows.Forms;

namespace BorsenoTextEditor.Forms
{
    partial class ChooseFileFromDBForm : Form
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
            this.Cancel = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.filesDBdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filesDBdataGridView
            // 
            this.filesDBdataGridView.AllowDrop = true;
            this.filesDBdataGridView.AllowUserToAddRows = false;
            this.filesDBdataGridView.AllowUserToOrderColumns = true;
            this.filesDBdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesDBdataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.filesDBdataGridView.Location = new System.Drawing.Point(5, 40);
            this.filesDBdataGridView.MultiSelect = false;
            this.filesDBdataGridView.Name = "filesDBdataGridView";
            this.filesDBdataGridView.Size = new System.Drawing.Size(258, 340);
            this.filesDBdataGridView.TabIndex = 0;
            this.filesDBdataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridView_RowPostPaint);
            this.filesDBdataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseFileFromDBForm_KeyDown);
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
            this.SelectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectButton.Location = new System.Drawing.Point(5, 386);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(71, 46);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "OK";
            this.SelectButton.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(192, 386);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(71, 45);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(99, 386);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(71, 46);
            this.Delete.TabIndex = 4;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.OnDelete);
            // 
            // ChooseFileFromDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 444);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.tableDescription);
            this.Controls.Add(this.filesDBdataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChooseFileFromDBForm";
            this.Text = "ChooseFileFromDBForm";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.OnShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseFileFromDBForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.filesDBdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView filesDBdataGridView;
        private System.Windows.Forms.Label tableDescription;
        private System.Windows.Forms.Button SelectButton;
        private Button Cancel;
        private Button Delete;
    }
}