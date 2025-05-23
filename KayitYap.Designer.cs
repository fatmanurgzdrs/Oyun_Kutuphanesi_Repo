namespace oyunKutuphanesi047
{
    partial class KayitYap
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
            this.kaydolBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sifreTxtBox = new System.Windows.Forms.TextBox();
            this.kAdiTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sifreTTxtBox = new System.Windows.Forms.TextBox();
            this.cikisBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kaydolBTN
            // 
            this.kaydolBTN.Location = new System.Drawing.Point(86, 187);
            this.kaydolBTN.Name = "kaydolBTN";
            this.kaydolBTN.Size = new System.Drawing.Size(100, 23);
            this.kaydolBTN.TabIndex = 10;
            this.kaydolBTN.Text = "Kaydol";
            this.kaydolBTN.UseVisualStyleBackColor = true;
            this.kaydolBTN.Click += new System.EventHandler(this.kaydolBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Şifre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // sifreTxtBox
            // 
            this.sifreTxtBox.Location = new System.Drawing.Point(86, 102);
            this.sifreTxtBox.Name = "sifreTxtBox";
            this.sifreTxtBox.PasswordChar = '•';
            this.sifreTxtBox.Size = new System.Drawing.Size(100, 20);
            this.sifreTxtBox.TabIndex = 7;
            // 
            // kAdiTxtBox
            // 
            this.kAdiTxtBox.Location = new System.Drawing.Point(86, 76);
            this.kAdiTxtBox.Name = "kAdiTxtBox";
            this.kAdiTxtBox.Size = new System.Drawing.Size(100, 20);
            this.kAdiTxtBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tekrar Şifre:";
            // 
            // sifreTTxtBox
            // 
            this.sifreTTxtBox.Location = new System.Drawing.Point(86, 128);
            this.sifreTTxtBox.Name = "sifreTTxtBox";
            this.sifreTTxtBox.PasswordChar = '•';
            this.sifreTTxtBox.Size = new System.Drawing.Size(100, 20);
            this.sifreTTxtBox.TabIndex = 11;
            // 
            // cikisBTN
            // 
            this.cikisBTN.Location = new System.Drawing.Point(14, 187);
            this.cikisBTN.Name = "cikisBTN";
            this.cikisBTN.Size = new System.Drawing.Size(64, 22);
            this.cikisBTN.TabIndex = 13;
            this.cikisBTN.Text = "Çıkış";
            this.cikisBTN.UseVisualStyleBackColor = true;
            this.cikisBTN.Click += new System.EventHandler(this.cikisBTN_Click);
            // 
            // KayitYap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(202, 225);
            this.Controls.Add(this.cikisBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sifreTTxtBox);
            this.Controls.Add(this.kaydolBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sifreTxtBox);
            this.Controls.Add(this.kAdiTxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KayitYap";
            this.Text = "Kayıt Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kaydolBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sifreTxtBox;
        private System.Windows.Forms.TextBox kAdiTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sifreTTxtBox;
        private System.Windows.Forms.Button cikisBTN;
    }
}