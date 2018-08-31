namespace ITRW225_Information_System
{
    partial class UI_InventoryReceiveOrder
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnchanges = new System.Windows.Forms.Button();
            this.btnreturn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblquantity = new System.Windows.Forms.Label();
            this.lblitemid = new System.Windows.Forms.Label();
            this.txtbitemid = new System.Windows.Forms.TextBox();
            this.txtbitemname = new System.Windows.Forms.TextBox();
            this.btnplaceanotherorder = new System.Windows.Forms.Button();
            this.lblitemname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 200);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(480, 186);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stock Infromation :";
            // 
            // btnchanges
            // 
            this.btnchanges.Location = new System.Drawing.Point(232, 21);
            this.btnchanges.Name = "btnchanges";
            this.btnchanges.Size = new System.Drawing.Size(135, 23);
            this.btnchanges.TabIndex = 2;
            this.btnchanges.Text = "Update Order Changes";
            this.btnchanges.UseVisualStyleBackColor = true;
            // 
            // btnreturn
            // 
            this.btnreturn.Location = new System.Drawing.Point(191, 142);
            this.btnreturn.Name = "btnreturn";
            this.btnreturn.Size = new System.Drawing.Size(98, 23);
            this.btnreturn.TabIndex = 19;
            this.btnreturn.Text = "Return Order";
            this.btnreturn.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 18;
            // 
            // lblquantity
            // 
            this.lblquantity.AutoSize = true;
            this.lblquantity.Location = new System.Drawing.Point(9, 93);
            this.lblquantity.Name = "lblquantity";
            this.lblquantity.Size = new System.Drawing.Size(52, 13);
            this.lblquantity.TabIndex = 17;
            this.lblquantity.Text = "Quantity :";
            // 
            // lblitemid
            // 
            this.lblitemid.AutoSize = true;
            this.lblitemid.Location = new System.Drawing.Point(9, 54);
            this.lblitemid.Name = "lblitemid";
            this.lblitemid.Size = new System.Drawing.Size(47, 13);
            this.lblitemid.TabIndex = 16;
            this.lblitemid.Text = "Item ID :";
            // 
            // txtbitemid
            // 
            this.txtbitemid.Location = new System.Drawing.Point(100, 54);
            this.txtbitemid.Name = "txtbitemid";
            this.txtbitemid.Size = new System.Drawing.Size(100, 20);
            this.txtbitemid.TabIndex = 15;
            // 
            // txtbitemname
            // 
            this.txtbitemname.Location = new System.Drawing.Point(100, 12);
            this.txtbitemname.Name = "txtbitemname";
            this.txtbitemname.Size = new System.Drawing.Size(100, 20);
            this.txtbitemname.TabIndex = 14;
            // 
            // btnplaceanotherorder
            // 
            this.btnplaceanotherorder.Location = new System.Drawing.Point(27, 142);
            this.btnplaceanotherorder.Name = "btnplaceanotherorder";
            this.btnplaceanotherorder.Size = new System.Drawing.Size(137, 23);
            this.btnplaceanotherorder.TabIndex = 13;
            this.btnplaceanotherorder.Text = "Place Another Order";
            this.btnplaceanotherorder.UseVisualStyleBackColor = true;
            // 
            // lblitemname
            // 
            this.lblitemname.AutoSize = true;
            this.lblitemname.Location = new System.Drawing.Point(9, 12);
            this.lblitemname.Name = "lblitemname";
            this.lblitemname.Size = new System.Drawing.Size(64, 13);
            this.lblitemname.TabIndex = 12;
            this.lblitemname.Text = "Item Name :";
            // 
            // UI_ReceivedOrderFromSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 400);
            this.Controls.Add(this.btnreturn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblquantity);
            this.Controls.Add(this.lblitemid);
            this.Controls.Add(this.txtbitemid);
            this.Controls.Add(this.txtbitemname);
            this.Controls.Add(this.btnplaceanotherorder);
            this.Controls.Add(this.lblitemname);
            this.Controls.Add(this.btnchanges);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "UI_ReceivedOrderFromSupplier";
            this.Text = "UI_ReceivedOrderFromSupplier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnchanges;
        private System.Windows.Forms.Button btnreturn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblquantity;
        private System.Windows.Forms.Label lblitemid;
        private System.Windows.Forms.TextBox txtbitemid;
        private System.Windows.Forms.TextBox txtbitemname;
        private System.Windows.Forms.Button btnplaceanotherorder;
        private System.Windows.Forms.Label lblitemname;
    }
}