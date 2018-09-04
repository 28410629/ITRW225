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
        List<ListViewItem> list = new List<ListViewItem>();

        public UI_POSPlaceOrder()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void UI_POSPlaceOrder_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Unchecked)
            {
                bool add = true;
                if (listView1.Items.Count > 1)
                {
                    for (int i = 0; i < listView1.Items.Count - 1; i++)
                    {
                        if (list[i].SubItems[1].ToString().Contains(checkedListBox1.SelectedItem.ToString()))
                        {
                            add = false;
                        }
                    }
                }
                if (add)
                {
                    string[] arr = new string[2];
                    ListViewItem itm; //add items to ListView 
                    arr[0] = "100";
                    arr[1] = checkedListBox1.SelectedItem.ToString();
                    itm = new ListViewItem(arr);
                    itm.ToolTipText = "Highlight item and click once on value to change!";
                    list.Add(itm);
                    listView1.Items.Add(itm);
                }
            }
            else
            {
                MessageBox.Show("Activated Remove!");
            }
            
        }
    }
}
