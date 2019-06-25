namespace projectChess
{
    partial class mainmenu
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.game = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // game
            // 
            this.game.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F);
            this.game.Location = new System.Drawing.Point(182, 48);
            this.game.Name = "game";
            this.game.Size = new System.Drawing.Size(555, 130);
            this.game.TabIndex = 0;
            this.game.Text = "Играть";
            this.game.UseVisualStyleBackColor = true;
            this.game.Click += new System.EventHandler(this.game_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F);
            this.button1.Location = new System.Drawing.Point(182, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(555, 130);
            this.button1.TabIndex = 1;
            this.button1.Text = "Настройки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F);
            this.button2.Location = new System.Drawing.Point(182, 396);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(555, 130);
            this.button2.TabIndex = 2;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::projectChess.Properties.Resources.imagenajedrez;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(876, 584);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.game);
            this.Name = "mainmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button game;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

