namespace oyunKutuphanesi047
{
    partial class ZorlukSecimi
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
            this.label1 = new System.Windows.Forms.Label();
            this.kolayBTN = new System.Windows.Forms.Button();
            this.ortaBTN = new System.Windows.Forms.Button();
            this.zorBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lütfen Zorluk Seçiniz";
            // 
            // kolayBTN
            // 
            this.kolayBTN.BackColor = System.Drawing.Color.LightCoral;
            this.kolayBTN.Location = new System.Drawing.Point(12, 58);
            this.kolayBTN.Name = "kolayBTN";
            this.kolayBTN.Size = new System.Drawing.Size(58, 23);
            this.kolayBTN.TabIndex = 1;
            this.kolayBTN.Text = "Kolay";
            this.kolayBTN.UseVisualStyleBackColor = false;
            this.kolayBTN.Click += new System.EventHandler(this.kolayBTN_Click);
            // 
            // ortaBTN
            // 
            this.ortaBTN.BackColor = System.Drawing.Color.LightCoral;
            this.ortaBTN.Location = new System.Drawing.Point(76, 58);
            this.ortaBTN.Name = "ortaBTN";
            this.ortaBTN.Size = new System.Drawing.Size(58, 23);
            this.ortaBTN.TabIndex = 2;
            this.ortaBTN.Text = "Orta";
            this.ortaBTN.UseVisualStyleBackColor = false;
            this.ortaBTN.Click += new System.EventHandler(this.ortaBTN_Click);
            // 
            // zorBTN
            // 
            this.zorBTN.BackColor = System.Drawing.Color.LightCoral;
            this.zorBTN.Location = new System.Drawing.Point(141, 58);
            this.zorBTN.Name = "zorBTN";
            this.zorBTN.Size = new System.Drawing.Size(58, 23);
            this.zorBTN.TabIndex = 3;
            this.zorBTN.Text = "Zor";
            this.zorBTN.UseVisualStyleBackColor = false;
            this.zorBTN.Click += new System.EventHandler(this.zorBTN_Click);
            // 
            // ZorlukSecimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(211, 108);
            this.Controls.Add(this.zorBTN);
            this.Controls.Add(this.ortaBTN);
            this.Controls.Add(this.kolayBTN);
            this.Controls.Add(this.label1);
            this.Name = "ZorlukSecimi";
            this.Text = "zorlukSecimi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kolayBTN;
        private System.Windows.Forms.Button ortaBTN;
        private System.Windows.Forms.Button zorBTN;
    }
}