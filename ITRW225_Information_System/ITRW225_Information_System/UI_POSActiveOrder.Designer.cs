namespace ITRW225_Information_System
{
    partial class UI_POSActiveOrder
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnOC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnOC,
            this.columnN,
            this.columnCID,
            this.columnDC,
            this.columnDD,
            this.columnP});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(751, 294);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnOC
            // 
            this.columnOC.Text = "Order Code";
            this.columnOC.Width = 79;
            // 
            // columnN
            // 
            this.columnN.Text = "Client";
            this.columnN.Width = 200;
            // 
            // columnCID
            // 
            this.columnCID.Text = "Client ID";
            this.columnCID.Width = 149;
            // 
            // columnDC
            // 
            this.columnDC.Text = "Date Created";
            this.columnDC.Width = 100;
            // 
            // columnDD
            // 
            this.columnDD.Text = "Due Date";
            this.columnDD.Width = 100;
            // 
            // columnP
            // 
            this.columnP.Text = "Price (R)";
            this.columnP.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 349);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Active Orders";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(339, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Process Payment For Selected Order";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(339, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel Selected Active Order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UI_POSActiveOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 372);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "UI_POSActiveOrder";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS - Active Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_POSActiveOrder_FormClosing);
            this.Load += new System.EventHandler(this.UI_POSActiveOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnN;
        private System.Windows.Forms.ColumnHeader columnDC;
        private System.Windows.Forms.ColumnHeader columnDD;
        private System.Windows.Forms.ColumnHeader columnP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnCID;
        private System.Windows.Forms.ColumnHeader columnOC;
        private System.Windows.Forms.Button button2;
    }
}