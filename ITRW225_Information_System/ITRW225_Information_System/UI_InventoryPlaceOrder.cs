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
    public partial class UI_InventoryPlaceOrder : Form
    {
        public UI_InventoryPlaceOrder()
        {
            InitializeComponent();
            string[] item = new string[2];
            item[0] = "Apples";
            item[1] = "20";
            ListViewItem viewItem = new ListViewItem(item);
            listView1.Items.Add(viewItem);
        }
    }
}
