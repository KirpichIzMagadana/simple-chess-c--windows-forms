namespace projectChess
{
    partial class settings
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
            this.back = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.time2 = new System.Windows.Forms.RadioButton();
            this.time1 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F);
            this.back.Location = new System.Drawing.Point(186, 309);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(249, 62);
            this.back.TabIndex = 0;
            this.back.Text = "назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.time2);
            this.groupBox1.Controls.Add(this.time1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F);
            this.groupBox1.Location = new System.Drawing.Point(166, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 199);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вемя игры";
            // 
            // time2
            // 
            this.time2.AutoSize = true;
            this.time2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.time2.Location = new System.Drawing.Point(20, 141);
            this.time2.Name = "time2";
            this.time2.Size = new System.Drawing.Size(275, 48);
            this.time2.TabIndex = 1;
            this.time2.TabStop = true;
            this.time2.Text = "Со временем";
            this.time2.UseVisualStyleBackColor = true;
            this.time2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // time1
            // 
            this.time1.AutoSize = true;
            this.time1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.time1.Location = new System.Drawing.Point(20, 75);
            this.time1.Name = "time1";
            this.time1.Size = new System.Drawing.Size(226, 48);
            this.time1.TabIndex = 0;
            this.time1.TabStop = true;
            this.time1.Text = "Бессрочно";
            this.time1.UseVisualStyleBackColor = true;
            this.time1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.textBox1.Location = new System.Drawing.Point(157, 252);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 35);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Введите_время_в_минутах";
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::projectChess.Properties.Resources.imagenajedrez;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(602, 404);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.back);
            this.Name = "settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton time2;
        private System.Windows.Forms.RadioButton time1;
        private System.Windows.Forms.TextBox textBox1;
    }
}