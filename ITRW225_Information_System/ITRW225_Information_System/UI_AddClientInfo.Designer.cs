﻿namespace ITRW225_Information_System
{
    partial class UI_AddClientInfo
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
            this.txtBFirstName = new System.Windows.Forms.TextBox();
            this.txtBLastName = new System.Windows.Forms.TextBox();
            this.txtBClientNum = new System.Windows.Forms.TextBox();
            this.txtBBackUp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBClientEmail = new System.Windows.Forms.TextBox();
            this.btnUpdateClientInfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter client first name:";
            // 
            // txtBFirstName
            // 
            this.txtBFirstName.Location = new System.Drawing.Point(215, 19);
            this.txtBFirstName.Name = "txtBFirstName";
            this.txtBFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtBFirstName.TabIndex = 1;
            // 
            // txtBLastName
            // 
            this.txtBLastName.Location = new System.Drawing.Point(215, 45);
            this.txtBLastName.Name = "txtBLastName";
            this.txtBLastName.Size = new System.Drawing.Size(100, 20);
            this.txtBLastName.TabIndex = 2;
            // 
            // txtBClientNum
            // 
            this.txtBClientNum.Location = new System.Drawing.Point(212, 16);
            this.txtBClientNum.Name = "txtBClientNum";
            this.txtBClientNum.Size = new System.Drawing.Size(100, 20);
            this.txtBClientNum.TabIndex = 3;
            // 
            // txtBBackUp
            // 
            this.txtBBackUp.Location = new System.Drawing.Point(212, 42);
            this.txtBBackUp.Name = "txtBBackUp";
            this.txtBBackUp.Size = new System.Drawing.Size(100, 20);
            this.txtBBackUp.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter client surname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Enter client number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Enter client\'s back-up number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Enter client\'s email address:";
            // 
            // txtBClientEmail
            // 
            this.txtBClientEmail.Location = new System.Drawing.Point(212, 68);
            this.txtBClientEmail.Name = "txtBClientEmail";
            this.txtBClientEmail.Size = new System.Drawing.Size(100, 20);
            this.txtBClientEmail.TabIndex = 9;
            // 
            // btnUpdateClientInfo
            // 
            this.btnUpdateClientInfo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnUpdateClientInfo.Location = new System.Drawing.Point(185, 193);
            this.btnUpdateClientInfo.Name = "btnUpdateClientInfo";
            this.btnUpdateClientInfo.Size = new System.Drawing.Size(159, 23);
            this.btnUpdateClientInfo.TabIndex = 10;
            this.btnUpdateClientInfo.Text = "Add client info";
            this.btnUpdateClientInfo.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Location = new System.Drawing.Point(6, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBLastName);
            this.groupBox1.Controls.Add(this.txtBFirstName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 78);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtBClientNum);
            this.groupBox2.Controls.Add(this.txtBBackUp);
            this.groupBox2.Controls.Add(this.txtBClientEmail);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 99);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ContactInfo";
            // 
            // UI_AddClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(366, 225);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUpdateClientInfo);
            this.Name = "UI_AddClientInfo";
            this.Text = "UI_AddClientInfo";
            this.Load += new System.EventHandler(this.UI_ClientMaintenance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBFirstName;
        private System.Windows.Forms.TextBox txtBLastName;
        private System.Windows.Forms.TextBox txtBClientNum;
        private System.Windows.Forms.TextBox txtBBackUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBClientEmail;
        private System.Windows.Forms.Button btnUpdateClientInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}