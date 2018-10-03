namespace ITRW225_Information_System
{
    partial class UI_ProductAdd
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
            this.groupBoxPD = new System.Windows.Forms.GroupBox();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.textBoxPN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFN = new System.Windows.Forms.Label();
            this.errorProviderPN = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderP = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxPD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderP)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(202, 93);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(127, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Add";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(12, 93);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(127, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBoxPD
            // 
            this.groupBoxPD.Controls.Add(this.textBoxP);
            this.groupBoxPD.Controls.Add(this.textBoxPN);
            this.groupBoxPD.Controls.Add(this.label2);
            this.groupBoxPD.Controls.Add(this.labelFN);
            this.groupBoxPD.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPD.Name = "groupBoxPD";
            this.groupBoxPD.Size = new System.Drawing.Size(317, 75);
            this.groupBoxPD.TabIndex = 1;
            this.groupBoxPD.TabStop = false;
            this.groupBoxPD.Text = "Product Details";
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(93, 43);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(197, 20);
            this.textBoxP.TabIndex = 1;
            this.textBoxP.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxP_Validating);
            // 
            // textBoxPN
            // 
            this.textBoxPN.Location = new System.Drawing.Point(93, 17);
            this.textBoxPN.Name = "textBoxPN";
            this.textBoxPN.Size = new System.Drawing.Size(197, 20);
            this.textBoxPN.TabIndex = 0;
            this.textBoxPN.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPN_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Price :";
            // 
            // labelFN
            // 
            this.labelFN.AutoSize = true;
            this.labelFN.Location = new System.Drawing.Point(6, 20);
            this.labelFN.Name = "labelFN";
            this.labelFN.Size = new System.Drawing.Size(81, 13);
            this.labelFN.TabIndex = 2;
            this.labelFN.Text = "Product Name :";
            // 
            // errorProviderPN
            // 
            this.errorProviderPN.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderPN.ContainerControl = this;
            // 
            // errorProviderP
            // 
            this.errorProviderP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderP.ContainerControl = this;
            // 
            // UI_ProductAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 127);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxPD);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 166);
            this.MinimumSize = new System.Drawing.Size(358, 166);
            this.Name = "UI_ProductAdd";
            this.ShowIcon = false;
            this.Text = "Add New Product";
            this.groupBoxPD.ResumeLayout(false);
            this.groupBoxPD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxPD;
        private System.Windows.Forms.TextBox textBoxP;
        private System.Windows.Forms.TextBox textBoxPN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFN;
        private System.Windows.Forms.ErrorProvider errorProviderPN;
        private System.Windows.Forms.ErrorProvider errorProviderP;
    }
}