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
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Input
            // 
            this.Input.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Input.Location = new System.Drawing.Point(12, 49);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(776, 389);
            this.Input.TabIndex = 0;
            this.Input.Text = "";
            this.Input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onKeyPress);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(155, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Read from NewFile1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ReadFromNewFile1OnClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(420, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Write to NewFile0";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.WriteToNewFile0OnClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Input;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

