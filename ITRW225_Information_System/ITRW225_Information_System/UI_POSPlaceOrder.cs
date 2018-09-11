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
            dateTimePicker2.CustomFormat = "HH:mm";
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void listViewAdd(bool addItem, string item)
        {
            listBox1.Enabled = false;
            if (addItem)
            {
                string[] arr = new string[2];
                ListViewItem itm; 
                arr[0] = "100";
                arr[1] = item;
                itm = new ListViewItem(arr);
                itm.ToolTipText = "Highlight item and click once on value to change!";
                list.Add(itm);
                listView1.Items.Add(itm);
            }
            if (listView1.Items.Count > 0 && addItem == false)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == item)
                    {
                        listView1.Items[i].Remove();
                    }
                }
            }
            listBox1.Enabled = true;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string itemString = (string)listBox1.SelectedItem;
            if (listView1.Items.Count == 0)
            {
                listViewAdd(true, itemString);
            }
            else
            {
                bool add = true;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == itemString)
                    {
                        add = false;
                    }
                }
                listViewAdd(add, itemString);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            
            int count = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                count += Convert.ToInt32(listView1.Items[i].SubItems[0].Text);
            }
            textBox1.Text = count.ToString();
        }
    }
}
