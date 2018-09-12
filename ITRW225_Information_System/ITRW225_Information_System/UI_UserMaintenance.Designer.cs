namespace ITRW225_Information_System
{
    partial class UI_UserMaintenance
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
            this.textBoxP1 = new System.Windows.Forms.TextBox();
            this.textBoxP2 = new System.Windows.Forms.TextBox();
            this.checkBoxCM = new System.Windows.Forms.CheckBox();
            this.checkBoxEM = new System.Windows.Forms.CheckBox();
            this.checkBoxPOS = new System.Windows.Forms.CheckBox();
            this.checkBoxR = new System.Windows.Forms.CheckBox();
            this.checkBoxUM = new System.Windows.Forms.CheckBox();
            this.checkBoxS = new System.Windows.Forms.CheckBox();
            this.comboBoxEmployee = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonAllow = new System.Windows.Forms.Button();
            this.buttonDeny = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxP1
            // 
            this.textBoxP1.Location = new System.Drawing.Point(71, 16);
            this.textBoxP1.Name = "textBoxP1";
            this.textBoxP1.PasswordChar = '*';
            this.textBoxP1.Size = new System.Drawing.Size(197, 20);
            this.textBoxP1.TabIndex = 0;
            // 
            // textBoxP2
            // 
            this.textBoxP2.Location = new System.Drawing.Point(71, 42);
            this.textBoxP2.Name = "textBoxP2";
            this.textBoxP2.PasswordChar = '*';
            this.textBoxP2.Size = new System.Drawing.Size(197, 20);
            this.textBoxP2.TabIndex = 1;
            // 
            // checkBoxCM
            // 
            this.checkBoxCM.AutoSize = true;
            this.checkBoxCM.Location = new System.Drawing.Point(6, 19);
            this.checkBoxCM.Name = "checkBoxCM";
            this.checkBoxCM.Size = new System.Drawing.Size(117, 17);
            this.checkBoxCM.TabIndex = 2;
            this.checkBoxCM.Text = "Client Maintenance";
            this.checkBoxCM.UseVisualStyleBackColor = true;
            // 
            // checkBoxEM
            // 
            this.checkBoxEM.AutoSize = true;
            this.checkBoxEM.Location = new System.Drawing.Point(6, 43);
            this.checkBoxEM.Name = "checkBoxEM";
            this.checkBoxEM.Size = new System.Drawing.Size(137, 17);
            this.checkBoxEM.TabIndex = 3;
            this.checkBoxEM.Text = "Employee Maintenance";
            this.checkBoxEM.UseVisualStyleBackColor = true;
            // 
            // checkBoxPOS
            // 
            this.checkBoxPOS.AutoSize = true;
            this.checkBoxPOS.Location = new System.Drawing.Point(6, 67);
            this.checkBoxPOS.Name = "checkBoxPOS";
            this.checkBoxPOS.Size = new System.Drawing.Size(91, 17);
            this.checkBoxPOS.TabIndex = 4;
            this.checkBoxPOS.Text = "Points of Sale";
            this.checkBoxPOS.UseVisualStyleBackColor = true;
            // 
            // checkBoxR
            // 
            this.checkBoxR.AutoSize = true;
            this.checkBoxR.Location = new System.Drawing.Point(6, 91);
            this.checkBoxR.Name = "checkBoxR";
            this.checkBoxR.Size = new System.Drawing.Size(63, 17);
            this.checkBoxR.TabIndex = 5;
            this.checkBoxR.Text = "Reports";
            this.checkBoxR.UseVisualStyleBackColor = true;
            // 
            // checkBoxUM
            // 
            this.checkBoxUM.AutoSize = true;
            this.checkBoxUM.Location = new System.Drawing.Point(6, 115);
            this.checkBoxUM.Name = "checkBoxUM";
            this.checkBoxUM.Size = new System.Drawing.Size(113, 17);
            this.checkBoxUM.TabIndex = 6;
            this.checkBoxUM.Text = "User Maintenance";
            this.checkBoxUM.UseVisualStyleBackColor = true;
            // 
            // checkBoxS
            // 
            this.checkBoxS.AutoSize = true;
            this.checkBoxS.Location = new System.Drawing.Point(6, 138);
            this.checkBoxS.Name = "checkBoxS";
            this.checkBoxS.Size = new System.Drawing.Size(64, 17);
            this.checkBoxS.TabIndex = 7;
            this.checkBoxS.Text = "Settings";
            this.checkBoxS.UseVisualStyleBackColor = true;
            // 
            // comboBoxEmployee
            // 
            this.comboBoxEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmployee.FormattingEnabled = true;
            this.comboBoxEmployee.Location = new System.Drawing.Point(6, 18);
            this.comboBoxEmployee.Name = "comboBoxEmployee";
            this.comboBoxEmployee.Size = new System.Drawing.Size(262, 21);
            this.comboBoxEmployee.TabIndex = 8;
            this.comboBoxEmployee.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmployee_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxCM);
            this.groupBox1.Controls.Add(this.checkBoxEM);
            this.groupBox1.Controls.Add(this.checkBoxS);
            this.groupBox1.Controls.Add(this.checkBoxPOS);
            this.groupBox1.Controls.Add(this.checkBoxUM);
            this.groupBox1.Controls.Add(this.checkBoxR);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 162);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Access Granted on System";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(161, 368);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(127, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(12, 368);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(127, 23);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 19);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(59, 13);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Confirm :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxEmployee);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 48);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelPassword);
            this.groupBox3.Controls.Add(this.textBoxP1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxP2);
            this.groupBox3.Location = new System.Drawing.Point(12, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 70);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Password Details";
            // 
            // buttonAllow
            // 
            this.buttonAllow.Location = new System.Drawing.Point(12, 310);
            this.buttonAllow.Name = "buttonAllow";
            this.buttonAllow.Size = new System.Drawing.Size(276, 23);
            this.buttonAllow.TabIndex = 16;
            this.buttonAllow.Text = "Activate Credentials";
            this.buttonAllow.UseVisualStyleBackColor = true;
            this.buttonAllow.Click += new System.EventHandler(this.buttonAllow_Click);
            // 
            // buttonDeny
            // 
            this.buttonDeny.Location = new System.Drawing.Point(12, 339);
            this.buttonDeny.Name = "buttonDeny";
            this.buttonDeny.Size = new System.Drawing.Size(276, 23);
            this.buttonDeny.TabIndex = 17;
            this.buttonDeny.Text = "Deactivate Credentials ";
            this.buttonDeny.UseVisualStyleBackColor = true;
            this.buttonDeny.Click += new System.EventHandler(this.buttonDeny_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 398);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(16, 13);
            this.labelStatus.TabIndex = 18;
            this.labelStatus.Text = "...";
            // 
            // UI_UserMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 421);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonDeny);
            this.Controls.Add(this.buttonAllow);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(317, 460);
            this.MinimumSize = new System.Drawing.Size(317, 460);
            this.Name = "UI_UserMaintenance";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Maintenance";
            this.Load += new System.EventHandler(this.UI_UserMaintenance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxP1;
        private System.Windows.Forms.TextBox textBoxP2;
        private System.Windows.Forms.CheckBox checkBoxCM;
        private System.Windows.Forms.CheckBox checkBoxEM;
        private System.Windows.Forms.CheckBox checkBoxPOS;
        private System.Windows.Forms.CheckBox checkBoxR;
        private System.Windows.Forms.CheckBox checkBoxUM;
        private System.Windows.Forms.CheckBox checkBoxS;
        private System.Windows.Forms.ComboBox comboBoxEmployee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonAllow;
        private System.Windows.Forms.Button buttonDeny;
        private System.Windows.Forms.Label labelStatus;
    }
}