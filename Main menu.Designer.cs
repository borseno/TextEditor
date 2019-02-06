namespace BorsenoTextEditor
{
    /*
Реализовать текстовый редактор с возможностью сохранения/загрузки файлов в/из БД.
В качестве БД использовать SQLite.

Условия выполнения задания:
- Настройки подключения к базе в файле конфигурации приложения
- Реализовать возможность загрузки файла из БД
- Реализовать возможность загрузки файла в БД
- Разработать форму ввода имени файла для сохранения
- Разработать форму выбора файла для загрузки

Дополнительные задания:
- Загрузка файла из базы и сохранение в базу асинхронно
- Обеспечить сжатие информации при хранении в БД средством любой ThirdParty библиотеки
- Для форматов json и xml обеспечить подсветку синтаксиса и форматирование
*/
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
            this.Input = new System.Windows.Forms.RichTextBox();
            this.FileChoosing = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.CurrentFileNameValue = new System.Windows.Forms.TextBox();
            this.CurrentFileNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Input.Location = new System.Drawing.Point(12, 84);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(972, 545);
            this.Input.TabIndex = 0;
            this.Input.Text = "";
            this.Input.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.InputPreviewKeyDown);
            // 
            // FileChoosing
            // 
            this.FileChoosing.Location = new System.Drawing.Point(12, 12);
            this.FileChoosing.Name = "FileChoosing";
            this.FileChoosing.Size = new System.Drawing.Size(170, 56);
            this.FileChoosing.TabIndex = 1;
            this.FileChoosing.Text = "Choose file to edit";
            this.FileChoosing.UseVisualStyleBackColor = true;
            this.FileChoosing.Click += new System.EventHandler(this.OnFileChoosing);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(814, 12);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(170, 56);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.OnClearing);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(638, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(170, 56);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.OnSaving);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 56);
            this.button1.TabIndex = 4;
            this.button1.Text = "Unchoose file (reset)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ResetCurrentFileName);
            // 
            // CurrentFileNameValue
            // 
            this.CurrentFileNameValue.Location = new System.Drawing.Point(373, 47);
            this.CurrentFileNameValue.Name = "CurrentFileNameValue";
            this.CurrentFileNameValue.ReadOnly = true;
            this.CurrentFileNameValue.Size = new System.Drawing.Size(259, 20);
            this.CurrentFileNameValue.TabIndex = 5;
            // 
            // CurrentFileNameLabel
            // 
            this.CurrentFileNameLabel.AutoSize = true;
            this.CurrentFileNameLabel.Location = new System.Drawing.Point(443, 22);
            this.CurrentFileNameLabel.Name = "CurrentFileNameLabel";
            this.CurrentFileNameLabel.Size = new System.Drawing.Size(94, 13);
            this.CurrentFileNameLabel.TabIndex = 6;
            this.CurrentFileNameLabel.Text = "Current File Name:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 632);
            this.Controls.Add(this.CurrentFileNameLabel);
            this.Controls.Add(this.CurrentFileNameValue);
            this.Controls.Add(this.button1);
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

        private System.Windows.Forms.RichTextBox Input;
        private System.Windows.Forms.Button FileChoosing;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox CurrentFileNameValue;
        private System.Windows.Forms.Label CurrentFileNameLabel;
    }
}

