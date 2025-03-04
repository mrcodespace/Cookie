namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pbCookie = new System.Windows.Forms.PictureBox();
            this.lblCookies = new System.Windows.Forms.Label();
            this.btnBuyAutoClicker = new System.Windows.Forms.Button();
            this.btnBuyMultiplier = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbCookie)).BeginInit();
            this.SuspendLayout();

            // pbCookie
            this.pbCookie.Image = global::WindowsFormsApp1.Properties.Resources.cookie;
            this.pbCookie.Location = new System.Drawing.Point(75, 50);
            this.pbCookie.Name = "pbCookie";
            this.pbCookie.Size = new System.Drawing.Size(150, 150);
            this.pbCookie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCookie.TabIndex = 0;
            this.pbCookie.TabStop = false;
            this.pbCookie.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbCookie_MouseDown);

            // lblCookies
            this.lblCookies.AutoSize = true;
            this.lblCookies.Font = new System.Drawing.Font("Arial", 14F);
            this.lblCookies.Location = new System.Drawing.Point(50, 200);
            this.lblCookies.Name = "lblCookies";
            this.lblCookies.Size = new System.Drawing.Size(200, 30);
            this.lblCookies.TabIndex = 1;
            this.lblCookies.Text = "0 Cookies";

            // btnBuyAutoClicker
            this.btnBuyAutoClicker.Location = new System.Drawing.Point(50, 250);
            this.btnBuyAutoClicker.Name = "btnBuyAutoClicker";
            this.btnBuyAutoClicker.Size = new System.Drawing.Size(200, 30);
            this.btnBuyAutoClicker.TabIndex = 2;
            this.btnBuyAutoClicker.Text = "Autoklicker kaufen (15)";
            this.btnBuyAutoClicker.UseVisualStyleBackColor = true;
            this.btnBuyAutoClicker.Click += new System.EventHandler(this.BtnBuyAutoClicker_Click);

            // btnBuyMultiplier
            this.btnBuyMultiplier.Location = new System.Drawing.Point(50, 300);
            this.btnBuyMultiplier.Name = "btnBuyMultiplier";
            this.btnBuyMultiplier.Size = new System.Drawing.Size(200, 30);
            this.btnBuyMultiplier.TabIndex = 3;
            this.btnBuyMultiplier.Text = "Multiplier x2 (100)";
            this.btnBuyMultiplier.UseVisualStyleBackColor = true;
            this.btnBuyMultiplier.Click += new System.EventHandler(this.BtnBuyMultiplier_Click);

            // gameTimer
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.btnBuyMultiplier);
            this.Controls.Add(this.btnBuyAutoClicker);
            this.Controls.Add(this.lblCookies);
            this.Controls.Add(this.pbCookie);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Cookie Clicker";
            ((System.ComponentModel.ISupportInitialize)(this.pbCookie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pbCookie;
        private System.Windows.Forms.Label lblCookies;
        private System.Windows.Forms.Button btnBuyAutoClicker;
        private System.Windows.Forms.Button btnBuyMultiplier;
        private System.Windows.Forms.Timer gameTimer;
    }
}
