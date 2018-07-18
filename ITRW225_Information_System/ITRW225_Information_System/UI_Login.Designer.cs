namespace ITRW225_Information_System
{
    partial class UI_Login
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
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelForgot = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxUser.Location = new System.Drawing.Point(183, 289);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(206, 20);
            this.textBoxUser.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(183, 315);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(206, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // labelForgot
            // 
            this.labelForgot.AutoSize = true;
            this.labelForgot.Location = new System.Drawing.Point(242, 338);
            this.labelForgot.Name = "labelForgot";
            this.labelForgot.Size = new System.Drawing.Size(92, 13);
            this.labelForgot.TabIndex = 2;
            this.labelForgot.Text = "Forgot Password?";
            this.labelForgot.Click += new System.EventHandler(this.labelForgot_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(180, 260);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(565, 231);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // UI_Login
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(589, 370);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelForgot);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUser);
            this.Name = "UI_Login";
            this.Text = "Mr Salad - Login";
            this.Load += new System.EventHandler(this.UI_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelForgot;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}