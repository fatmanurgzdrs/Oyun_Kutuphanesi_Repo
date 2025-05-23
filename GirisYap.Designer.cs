namespace oyunKutuphanesi047
{
    partial class GirisYap
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
            this.kAdiTxtBox = new System.Windows.Forms.TextBox();
            this.sifreTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.girisYapBTN = new System.Windows.Forms.Button();
            this.kaydolBTN = new System.Windows.Forms.Button();
            this.cikisBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kAdiTxtBox
            // 
            this.kAdiTxtBox.Location = new System.Drawing.Point(88, 96);
            this.kAdiTxtBox.Name = "kAdiTxtBox";
            this.kAdiTxtBox.Size = new System.Drawing.Size(100, 20);
            this.kAdiTxtBox.TabIndex = 0;
            // 
            // sifreTxtBox
            // 
            this.sifreTxtBox.Location = new System.Drawing.Point(88, 122);
            this.sifreTxtBox.Name = "sifreTxtBox";
            this.sifreTxtBox.PasswordChar = '•';
            this.sifreTxtBox.Size = new System.Drawing.Size(100, 20);
            this.sifreTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre:";
            // 
            // girisYapBTN
            // 
            this.girisYapBTN.Location = new System.Drawing.Point(88, 158);
            this.girisYapBTN.Name = "girisYapBTN";
            this.girisYapBTN.Size = new System.Drawing.Size(100, 23);
            this.girisYapBTN.TabIndex = 4;
            this.girisYapBTN.Text = "Giriş Yap";
            this.girisYapBTN.UseVisualStyleBackColor = true;
            this.girisYapBTN.Click += new System.EventHandler(this.girisYapBTN_Click);
            // 
            // kaydolBTN
            // 
            this.kaydolBTN.Location = new System.Drawing.Point(88, 188);
            this.kaydolBTN.Name = "kaydolBTN";
            this.kaydolBTN.Size = new System.Drawing.Size(100, 23);
            this.kaydolBTN.TabIndex = 5;
            this.kaydolBTN.Text = "Kaydol";
            this.kaydolBTN.UseVisualStyleBackColor = true;
            this.kaydolBTN.Click += new System.EventHandler(this.kaydolBTN_Click);
            // 
            // cikisBTN
            // 
            this.cikisBTN.Location = new System.Drawing.Point(12, 189);
            this.cikisBTN.Name = "cikisBTN";
            this.cikisBTN.Size = new System.Drawing.Size(68, 22);
            this.cikisBTN.TabIndex = 6;
            this.cikisBTN.Text = "Çıkış";
            this.cikisBTN.UseVisualStyleBackColor = true;
            this.cikisBTN.Click += new System.EventHandler(this.cikisBTN_Click);
            // 
            // GirisYap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(201, 238);
            this.Controls.Add(this.cikisBTN);
            this.Controls.Add(this.kaydolBTN);
            this.Controls.Add(this.girisYapBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sifreTxtBox);
            this.Controls.Add(this.kAdiTxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GirisYap";
            this.Text = "Giriş Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox kAdiTxtBox;
        private System.Windows.Forms.TextBox sifreTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button girisYapBTN;
        private System.Windows.Forms.Button kaydolBTN;
        private System.Windows.Forms.Button cikisBTN;
    }
}

