namespace ITRW225_Information_System
{
    partial class UI_AddNewEmployee
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
            this.labelFN = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxPD = new System.Windows.Forms.GroupBox();
            this.textBoxLN = new System.Windows.Forms.TextBox();
            this.textBoxFN = new System.Windows.Forms.TextBox();
            this.groupBoxCI = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxAD = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxCN = new System.Windows.Forms.ComboBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.errorProviderALL = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxPD.SuspendLayout();
            this.groupBoxCI.SuspendLayout();
            this.groupBoxAD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderALL)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFN
            // 
            this.labelFN.AutoSize = true;
            this.labelFN.Location = new System.Drawing.Point(25, 20);
            this.labelFN.Name = "labelFN";
            this.labelFN.Size = new System.Drawing.Size(63, 13);
            this.labelFN.TabIndex = 0;
            this.labelFN.Text = "First Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cell Number :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID Number :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "VAT Number :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email Address :";
            // 
            // groupBoxPD
            // 
            this.groupBoxPD.Controls.Add(this.textBoxLN);
            this.groupBoxPD.Controls.Add(this.textBoxFN);
            this.groupBoxPD.Controls.Add(this.label2);
            this.groupBoxPD.Controls.Add(this.labelFN);
            this.groupBoxPD.Location = new System.Drawing.Point(11, 12);
            this.groupBoxPD.Name = "groupBoxPD";
            this.groupBoxPD.Size = new System.Drawing.Size(317, 76);
            this.groupBoxPD.TabIndex = 12;
            this.groupBoxPD.TabStop = false;
            this.groupBoxPD.Text = "Personal Details";
            // 
            // textBoxLN
            // 
            this.textBoxLN.Location = new System.Drawing.Point(93, 43);
            this.textBoxLN.Name = "textBoxLN";
            this.textBoxLN.Size = new System.Drawing.Size(197, 20);
            this.textBoxLN.TabIndex = 9;
            // 
            // textBoxFN
            // 
            this.textBoxFN.Location = new System.Drawing.Point(94, 17);
            this.textBoxFN.Name = "textBoxFN";
            this.textBoxFN.Size = new System.Drawing.Size(197, 20);
            this.textBoxFN.TabIndex = 8;
            this.textBoxFN.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxFN_Validating);
            // 
            // groupBoxCI
            // 
            this.groupBoxCI.Controls.Add(this.textBox5);
            this.groupBoxCI.Controls.Add(this.textBox4);
            this.groupBoxCI.Controls.Add(this.textBox3);
            this.groupBoxCI.Controls.Add(this.textBox2);
            this.groupBoxCI.Controls.Add(this.label3);
            this.groupBoxCI.Controls.Add(this.label5);
            this.groupBoxCI.Controls.Add(this.label6);
            this.groupBoxCI.Controls.Add(this.label4);
            this.groupBoxCI.Location = new System.Drawing.Point(11, 94);
            this.groupBoxCI.Name = "groupBoxCI";
            this.groupBoxCI.Size = new System.Drawing.Size(317, 123);
            this.groupBoxCI.TabIndex = 13;
            this.groupBoxCI.TabStop = false;
            this.groupBoxCI.Text = "Contact Information";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(93, 97);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(197, 20);
            this.textBox5.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(93, 71);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(197, 20);
            this.textBox4.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(93, 45);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(197, 20);
            this.textBox3.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(197, 20);
            this.textBox2.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Street Name :";
            // 
            // groupBoxAD
            // 
            this.groupBoxAD.Controls.Add(this.label1);
            this.groupBoxAD.Controls.Add(this.textBox1);
            this.groupBoxAD.Controls.Add(this.comboBoxCN);
            this.groupBoxAD.Controls.Add(this.textBox9);
            this.groupBoxAD.Controls.Add(this.textBox7);
            this.groupBoxAD.Controls.Add(this.textBox6);
            this.groupBoxAD.Controls.Add(this.label10);
            this.groupBoxAD.Controls.Add(this.label9);
            this.groupBoxAD.Controls.Add(this.label8);
            this.groupBoxAD.Controls.Add(this.label7);
            this.groupBoxAD.Location = new System.Drawing.Point(11, 223);
            this.groupBoxAD.Name = "groupBoxAD";
            this.groupBoxAD.Size = new System.Drawing.Size(317, 151);
            this.groupBoxAD.TabIndex = 14;
            this.groupBoxAD.TabStop = false;
            this.groupBoxAD.Text = "Address Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Suburb :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 20);
            this.textBox1.TabIndex = 22;
            // 
            // comboBoxCN
            // 
            this.comboBoxCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCN.FormattingEnabled = true;
            this.comboBoxCN.Location = new System.Drawing.Point(96, 95);
            this.comboBoxCN.Name = "comboBoxCN";
            this.comboBoxCN.Size = new System.Drawing.Size(197, 21);
            this.comboBoxCN.TabIndex = 21;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(96, 121);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(197, 20);
            this.textBox9.TabIndex = 20;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(96, 43);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(197, 20);
            this.textBox7.TabIndex = 18;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(96, 17);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(197, 20);
            this.textBox6.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "House Number :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Postal Code :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "City Name :";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(11, 380);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(127, 23);
            this.buttonClose.TabIndex = 15;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(201, 380);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(127, 23);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // errorProviderALL
            // 
            this.errorProviderALL.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderALL.ContainerControl = this;
            // 
            // UI_AddNewEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(340, 411);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxAD);
            this.Controls.Add(this.groupBoxCI);
            this.Controls.Add(this.groupBoxPD);
            this.MaximizeBox = false;
            this.Name = "UI_AddNewEmployee";
            this.ShowIcon = false;
            this.Text = "Add Employee";
            this.groupBoxPD.ResumeLayout(false);
            this.groupBoxPD.PerformLayout();
            this.groupBoxCI.ResumeLayout(false);
            this.groupBoxCI.PerformLayout();
            this.groupBoxAD.ResumeLayout(false);
            this.groupBoxAD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderALL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelFN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxPD;
        private System.Windows.Forms.GroupBox groupBoxCI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxAD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxLN;
        private System.Windows.Forms.TextBox textBoxFN;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ErrorProvider errorProviderALL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxCN;
    }
}