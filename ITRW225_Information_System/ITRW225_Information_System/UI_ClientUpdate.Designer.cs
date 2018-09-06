namespace ITRW225_Information_System
{
    partial class UI_ClientUpdate
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxSE = new System.Windows.Forms.ComboBox();
            this.groupBoxAD = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxS = new System.Windows.Forms.TextBox();
            this.comboBoxCN = new System.Windows.Forms.ComboBox();
            this.textBoxPC = new System.Windows.Forms.TextBox();
            this.textBoxSN = new System.Windows.Forms.TextBox();
            this.textBoxHN = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxPD = new System.Windows.Forms.GroupBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLN = new System.Windows.Forms.TextBox();
            this.textBoxFN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFN = new System.Windows.Forms.Label();
            this.groupBoxCI = new System.Windows.Forms.GroupBox();
            this.textBoxCN2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxEA = new System.Windows.Forms.TextBox();
            this.textBoxCN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProviderFN = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderLN = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderCN = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderVAT = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderEA = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderHN = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderSN = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderS = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPC = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderCN2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBoxAD.SuspendLayout();
            this.groupBoxPD.SuspendLayout();
            this.groupBoxCI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderVAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderHN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCN2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(202, 430);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(127, 23);
            this.buttonSave.TabIndex = 28;
            this.buttonSave.Text = "Update";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(12, 430);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(127, 23);
            this.buttonClose.TabIndex = 27;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxSE);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 46);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Client";
            // 
            // comboBoxSE
            // 
            this.comboBoxSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSE.FormattingEnabled = true;
            this.comboBoxSE.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSE.Name = "comboBoxSE";
            this.comboBoxSE.Size = new System.Drawing.Size(305, 21);
            this.comboBoxSE.TabIndex = 0;
            this.comboBoxSE.SelectedIndexChanged += new System.EventHandler(this.comboBoxSE_SelectedIndexChanged);
            // 
            // groupBoxAD
            // 
            this.groupBoxAD.Controls.Add(this.label1);
            this.groupBoxAD.Controls.Add(this.textBoxS);
            this.groupBoxAD.Controls.Add(this.comboBoxCN);
            this.groupBoxAD.Controls.Add(this.textBoxPC);
            this.groupBoxAD.Controls.Add(this.textBoxSN);
            this.groupBoxAD.Controls.Add(this.textBoxHN);
            this.groupBoxAD.Controls.Add(this.label10);
            this.groupBoxAD.Controls.Add(this.label9);
            this.groupBoxAD.Controls.Add(this.label8);
            this.groupBoxAD.Controls.Add(this.label7);
            this.groupBoxAD.Location = new System.Drawing.Point(12, 273);
            this.groupBoxAD.Name = "groupBoxAD";
            this.groupBoxAD.Size = new System.Drawing.Size(317, 151);
            this.groupBoxAD.TabIndex = 26;
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
            // textBoxS
            // 
            this.textBoxS.Location = new System.Drawing.Point(96, 69);
            this.textBoxS.Name = "textBoxS";
            this.textBoxS.Size = new System.Drawing.Size(197, 20);
            this.textBoxS.TabIndex = 22;
            this.textBoxS.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxS_Validating);
            // 
            // comboBoxCN
            // 
            this.comboBoxCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCN.FormattingEnabled = true;
            this.comboBoxCN.Items.AddRange(new object[] {
            "Please select location.",
            "",
            "Eastern Cape",
            "    Alice",
            "    Butterworth",
            "    East London",
            "    Graaff-Reinet",
            "    Grahamstown",
            "    King William’s Town",
            "    Mthatha",
            "    Port Elizabeth",
            "    Queenstown",
            "    Uitenhage",
            "    Zwelitsha",
            "Free State",
            "    Bethlehem",
            "    Bloemfontein",
            "    Jagersfontein",
            "    Kroonstad",
            "    Odendaalsrus",
            "    Parys",
            "    Phuthaditjhaba",
            "    Sasolburg",
            "    Virginia",
            "    Welkom",
            "Gauteng",
            "    Benoni",
            "    Boksburg",
            "    Brakpan",
            "    Carletonville",
            "    Germiston",
            "    Johannesburg",
            "    Krugersdorp",
            "    Pretoria",
            "    Randburg",
            "    Randfontein",
            "    Roodepoort",
            "    Soweto",
            "    Springs",
            "    Vanderbijlpark",
            "    Vereeniging",
            "KwaZulu-Natal",
            "    Durban",
            "    Empangeni",
            "    Ladysmith",
            "    Newcastle",
            "    Pietermaritzburg",
            "    Pinetown",
            "    Ulundi",
            "    Umlazi",
            "Limpopo",
            "    Giyani",
            "    Lebowakgomo",
            "    Musina",
            "    Phalaborwa",
            "    Polokwane",
            "    Seshego",
            "    Sibasa",
            "    Thabazimbi",
            "Mpumalanga",
            "    Emalahleni",
            "    Nelspruit",
            "    Secunda",
            "North West",
            "    Klerksdorp",
            "    Mahikeng",
            "    Mmabatho",
            "    Potchefstroom",
            "    Rustenburg",
            "Northern Cape",
            "    Kimberley",
            "    Kuruman",
            "    Port Nolloth",
            "Western Cape",
            "    Bellville",
            "    Cape Town",
            "    Constantia",
            "    George",
            "    Hopefield",
            "    Oudtshoorn",
            "    Paarl",
            "    Simon’s Town",
            "    Stellenbosch",
            "    Swellendam",
            "    Worcester"});
            this.comboBoxCN.Location = new System.Drawing.Point(96, 95);
            this.comboBoxCN.Name = "comboBoxCN";
            this.comboBoxCN.Size = new System.Drawing.Size(197, 21);
            this.comboBoxCN.TabIndex = 21;
            // 
            // textBoxPC
            // 
            this.textBoxPC.Location = new System.Drawing.Point(96, 121);
            this.textBoxPC.Name = "textBoxPC";
            this.textBoxPC.Size = new System.Drawing.Size(197, 20);
            this.textBoxPC.TabIndex = 20;
            this.textBoxPC.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPC_Validating);
            // 
            // textBoxSN
            // 
            this.textBoxSN.Location = new System.Drawing.Point(96, 43);
            this.textBoxSN.Name = "textBoxSN";
            this.textBoxSN.Size = new System.Drawing.Size(197, 20);
            this.textBoxSN.TabIndex = 18;
            this.textBoxSN.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSN_Validating);
            // 
            // textBoxHN
            // 
            this.textBoxHN.Location = new System.Drawing.Point(96, 17);
            this.textBoxHN.Name = "textBoxHN";
            this.textBoxHN.Size = new System.Drawing.Size(197, 20);
            this.textBoxHN.TabIndex = 16;
            this.textBoxHN.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxHN_Validating);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Street Name :";
            // 
            // groupBoxPD
            // 
            this.groupBoxPD.Controls.Add(this.textBoxID);
            this.groupBoxPD.Controls.Add(this.label4);
            this.groupBoxPD.Controls.Add(this.textBoxLN);
            this.groupBoxPD.Controls.Add(this.textBoxFN);
            this.groupBoxPD.Controls.Add(this.label2);
            this.groupBoxPD.Controls.Add(this.labelFN);
            this.groupBoxPD.Location = new System.Drawing.Point(12, 64);
            this.groupBoxPD.Name = "groupBoxPD";
            this.groupBoxPD.Size = new System.Drawing.Size(317, 98);
            this.groupBoxPD.TabIndex = 24;
            this.groupBoxPD.TabStop = false;
            this.groupBoxPD.Text = "Personal Details";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(93, 69);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(197, 20);
            this.textBoxID.TabIndex = 15;
            this.textBoxID.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxID_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "ID Number :";
            // 
            // textBoxLN
            // 
            this.textBoxLN.Location = new System.Drawing.Point(93, 43);
            this.textBoxLN.Name = "textBoxLN";
            this.textBoxLN.Size = new System.Drawing.Size(197, 20);
            this.textBoxLN.TabIndex = 9;
            this.textBoxLN.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxLN_Validating);
            // 
            // textBoxFN
            // 
            this.textBoxFN.Location = new System.Drawing.Point(94, 17);
            this.textBoxFN.Name = "textBoxFN";
            this.textBoxFN.Size = new System.Drawing.Size(197, 20);
            this.textBoxFN.TabIndex = 8;
            this.textBoxFN.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxFN_Validating);
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
            // labelFN
            // 
            this.labelFN.AutoSize = true;
            this.labelFN.Location = new System.Drawing.Point(25, 20);
            this.labelFN.Name = "labelFN";
            this.labelFN.Size = new System.Drawing.Size(63, 13);
            this.labelFN.TabIndex = 0;
            this.labelFN.Text = "First Name :";
            // 
            // groupBoxCI
            // 
            this.groupBoxCI.Controls.Add(this.textBoxCN2);
            this.groupBoxCI.Controls.Add(this.label11);
            this.groupBoxCI.Controls.Add(this.textBoxEA);
            this.groupBoxCI.Controls.Add(this.textBoxCN);
            this.groupBoxCI.Controls.Add(this.label3);
            this.groupBoxCI.Controls.Add(this.label6);
            this.groupBoxCI.Location = new System.Drawing.Point(12, 168);
            this.groupBoxCI.Name = "groupBoxCI";
            this.groupBoxCI.Size = new System.Drawing.Size(317, 99);
            this.groupBoxCI.TabIndex = 25;
            this.groupBoxCI.TabStop = false;
            this.groupBoxCI.Text = "Contact Information";
            // 
            // textBoxCN2
            // 
            this.textBoxCN2.Location = new System.Drawing.Point(93, 45);
            this.textBoxCN2.Name = "textBoxCN2";
            this.textBoxCN2.Size = new System.Drawing.Size(197, 20);
            this.textBoxCN2.TabIndex = 15;
            this.textBoxCN2.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCN2_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Cell Number 2 :";
            // 
            // textBoxEA
            // 
            this.textBoxEA.Location = new System.Drawing.Point(93, 71);
            this.textBoxEA.Name = "textBoxEA";
            this.textBoxEA.Size = new System.Drawing.Size(197, 20);
            this.textBoxEA.TabIndex = 13;
            this.textBoxEA.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEA_Validating);
            // 
            // textBoxCN
            // 
            this.textBoxCN.Location = new System.Drawing.Point(93, 19);
            this.textBoxCN.Name = "textBoxCN";
            this.textBoxCN.Size = new System.Drawing.Size(197, 20);
            this.textBoxCN.TabIndex = 10;
            this.textBoxCN.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCN_Validating);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email Address :";
            // 
            // errorProviderFN
            // 
            this.errorProviderFN.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderFN.ContainerControl = this;
            // 
            // errorProviderLN
            // 
            this.errorProviderLN.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderLN.ContainerControl = this;
            // 
            // errorProviderCN
            // 
            this.errorProviderCN.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderCN.ContainerControl = this;
            // 
            // errorProviderID
            // 
            this.errorProviderID.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderID.ContainerControl = this;
            // 
            // errorProviderVAT
            // 
            this.errorProviderVAT.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderVAT.ContainerControl = this;
            // 
            // errorProviderEA
            // 
            this.errorProviderEA.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderEA.ContainerControl = this;
            // 
            // errorProviderHN
            // 
            this.errorProviderHN.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderHN.ContainerControl = this;
            // 
            // errorProviderSN
            // 
            this.errorProviderSN.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderSN.ContainerControl = this;
            // 
            // errorProviderS
            // 
            this.errorProviderS.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderS.ContainerControl = this;
            // 
            // errorProviderPC
            // 
            this.errorProviderPC.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderPC.ContainerControl = this;
            // 
            // errorProviderCN2
            // 
            this.errorProviderCN2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderCN2.ContainerControl = this;
            // 
            // UI_ClientUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 464);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAD);
            this.Controls.Add(this.groupBoxPD);
            this.Controls.Add(this.groupBoxCI);
            this.Name = "UI_ClientUpdate";
            this.ShowIcon = false;
            this.Text = "Client Update";
            this.Load += new System.EventHandler(this.UI_ClientUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxAD.ResumeLayout(false);
            this.groupBoxAD.PerformLayout();
            this.groupBoxPD.ResumeLayout(false);
            this.groupBoxPD.PerformLayout();
            this.groupBoxCI.ResumeLayout(false);
            this.groupBoxCI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderVAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderHN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCN2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxSE;
        private System.Windows.Forms.GroupBox groupBoxAD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxS;
        private System.Windows.Forms.ComboBox comboBoxCN;
        private System.Windows.Forms.TextBox textBoxPC;
        private System.Windows.Forms.TextBox textBoxSN;
        private System.Windows.Forms.TextBox textBoxHN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxPD;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLN;
        private System.Windows.Forms.TextBox textBoxFN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFN;
        private System.Windows.Forms.GroupBox groupBoxCI;
        private System.Windows.Forms.TextBox textBoxCN2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxEA;
        private System.Windows.Forms.TextBox textBoxCN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProviderFN;
        private System.Windows.Forms.ErrorProvider errorProviderLN;
        private System.Windows.Forms.ErrorProvider errorProviderCN;
        private System.Windows.Forms.ErrorProvider errorProviderID;
        private System.Windows.Forms.ErrorProvider errorProviderVAT;
        private System.Windows.Forms.ErrorProvider errorProviderEA;
        private System.Windows.Forms.ErrorProvider errorProviderHN;
        private System.Windows.Forms.ErrorProvider errorProviderSN;
        private System.Windows.Forms.ErrorProvider errorProviderS;
        private System.Windows.Forms.ErrorProvider errorProviderPC;
        private System.Windows.Forms.ErrorProvider errorProviderCN2;
    }
}