namespace ITRW225_Information_System
{
    partial class UI_InventoryPlaceOrder
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
            this.btncancelorder = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblquantity = new System.Windows.Forms.Label();
            this.lblitemid = new System.Windows.Forms.Label();
            this.txtbitemid = new System.Windows.Forms.TextBox();
            this.txtbitemname = new System.Windows.Forms.TextBox();
            this.btnplaceanotherorder = new System.Windows.Forms.Button();
            this.btnplaceorder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblitemname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncancelorder
            // 
            this.btncancelorder.Location = new System.Drawing.Point(274, 95);
            this.btncancelorder.Name = "btncancelorder";
            this.btncancelorder.Size = new System.Drawing.Size(98, 23);
            this.btncancelorder.TabIndex = 23;
            this.btncancelorder.Text = "Cancel Order";
            this.btncancelorder.UseVisualStyleBackColor = true;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(539, 5);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 22;
            this.btnexit.Text = "exit";
            this.btnexit.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 210);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(612, 290);
            this.listBox1.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 20;
            // 
            // lblquantity
            // 
            this.lblquantity.AutoSize = true;
            this.lblquantity.Location = new System.Drawing.Point(14, 95);
            this.lblquantity.Name = "lblquantity";
            this.lblquantity.Size = new System.Drawing.Size(52, 13);
            this.lblquantity.TabIndex = 19;
            this.lblquantity.Text = "Quantity :";
            // 
            // lblitemid
            // 
            this.lblitemid.AutoSize = true;
            this.lblitemid.Location = new System.Drawing.Point(14, 56);
            this.lblitemid.Name = "lblitemid";
            this.lblitemid.Size = new System.Drawing.Size(47, 13);
            this.lblitemid.TabIndex = 18;
            this.lblitemid.Text = "Item ID :";
            // 
            // txtbitemid
            // 
            this.txtbitemid.Location = new System.Drawing.Point(105, 56);
            this.txtbitemid.Name = "txtbitemid";
            this.txtbitemid.Size = new System.Drawing.Size(100, 20);
            this.txtbitemid.TabIndex = 17;
            // 
            // txtbitemname
            // 
            this.txtbitemname.Location = new System.Drawing.Point(105, 14);
            this.txtbitemname.Name = "txtbitemname";
            this.txtbitemname.Size = new System.Drawing.Size(100, 20);
            this.txtbitemname.TabIndex = 16;
            // 
            // btnplaceanotherorder
            // 
            this.btnplaceanotherorder.Location = new System.Drawing.Point(32, 144);
            this.btnplaceanotherorder.Name = "btnplaceanotherorder";
            this.btnplaceanotherorder.Size = new System.Drawing.Size(137, 23);
            this.btnplaceanotherorder.TabIndex = 15;
            this.btnplaceanotherorder.Text = "Place Another Order";
            this.btnplaceanotherorder.UseVisualStyleBackColor = true;
            // 
            // btnplaceorder
            // 
            this.btnplaceorder.Location = new System.Drawing.Point(274, 14);
            this.btnplaceorder.Name = "btnplaceorder";
            this.btnplaceorder.Size = new System.Drawing.Size(104, 23);
            this.btnplaceorder.TabIndex = 14;
            this.btnplaceorder.Text = "Place Order";
            this.btnplaceorder.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Information of the order and stock items :";
            // 
            // lblitemname
            // 
            this.lblitemname.AutoSize = true;
            this.lblitemname.Location = new System.Drawing.Point(14, 14);
            this.lblitemname.Name = "lblitemname";
            this.lblitemname.Size = new System.Drawing.Size(64, 13);
            this.lblitemname.TabIndex = 12;
            this.lblitemname.Text = "Item Name :";
            // 
            // Supplierorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 516);
            this.Controls.Add(this.btncancelorder);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblquantity);
            this.Controls.Add(this.lblitemid);
            this.Controls.Add(this.txtbitemid);
            this.Controls.Add(this.txtbitemname);
            this.Controls.Add(this.btnplaceanotherorder);
            this.Controls.Add(this.btnplaceorder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblitemname);
            this.Name = "Supplierorder";
            this.Text = "Supplierorder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncancelorder;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblquantity;
        private System.Windows.Forms.Label lblitemid;
        private System.Windows.Forms.TextBox txtbitemid;
        private System.Windows.Forms.TextBox txtbitemname;
        private System.Windows.Forms.Button btnplaceanotherorder;
        private System.Windows.Forms.Button btnplaceorder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblitemname;
    }
}