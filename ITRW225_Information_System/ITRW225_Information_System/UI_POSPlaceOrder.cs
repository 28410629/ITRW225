using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_POSPlaceOrder : Form
    {
        public UI_POSPlaceOrder()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void UI_POSPlaceOrder_Load(object sender, EventArgs e)
        {
            string[] arr = new string[2];
            ListViewItem itm; //add items to ListView 
            arr[0] = "100";
            arr[1] = "Product Something";
            itm = new ListViewItem(arr);
            itm.ToolTipText = "Highlight item and click once on value to change!";
            listView1.Items.Add(itm);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string[] arr = new string[2];
            ListViewItem itm; //add items to ListView 
            arr[0] = "100";
            arr[1] = checkedListBox1.SelectedItem.ToString();
            itm = new ListViewItem(arr);
            itm.ToolTipText = "Highlight item and click once on value to change!";
            listView1.Items.Add(itm);
        }
    }
}
