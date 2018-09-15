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
    public partial class UI_POSProcessPayment : Form
    {
        private BE_DatabaseCommands commands = new BE_DatabaseCommands();
        private Form mainForm;
        string clientOrderCode = "";
        private string[] arr;
        private List<string[]> orderP;
        private List<string[]> products;

        public UI_POSProcessPayment(Form mainForm, string[] arr)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.arr = arr; // this array must be a selected * from the following table order! CLIENT_ORDER, CONTACT_DETAILS, PERSON 
        }

        private void UI_POSProcessPayment_Load(object sender, EventArgs e)
        {
            textBoxID.Text = arr[19];
            textBoxN.Text = arr[20] + " " + arr[21];
            textBoxCN1.Text = arr[13];
            textBoxEA.Text = arr[17];
            clientOrderCode = arr[0];
            try
            {
                if (string.IsNullOrWhiteSpace(arr[9]) || arr[9] == "0")
                {
                    MessageBox.Show("No products on this order!");
                }
                else
                {
                    string query = "SELECT * FROM ORDER_PRODUCTS WHERE Client_Order_Code = " + clientOrderCode;
                    orderP = commands.retrieveCustomDB(query);
                    products = commands.retrieveDB("PRODUCT");

                    for (int i = 0; i < orderP.Count; i++)
                    {
                        for (int j = 0; j < products.Count; j++)
                        {
                            if (orderP[i][2] == products[j][0])
                            {
                                string[] arr = new string[3];
                                ListViewItem itm;
                                arr[0] = orderP[i][3];
                                arr[1] = products[j][1];
                                arr[2] = products[j][2];
                                itm = new ListViewItem(arr);
                                listView2.Items.Add(itm);
                            }
                        }
                    }
                    calculateCost();
                }
                comboBox1.SelectedIndex = 0;
                textBox3.Text = textBoxTotal.Text;
                textBox2.Text = textBoxTotal.Text;
                calculateMoneyGiven();
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void calculateCost()
        {
            double price = 0;
            int products = 0;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                price += (Convert.ToDouble(listView2.Items[i].SubItems[0].Text) * Convert.ToDouble(listView2.Items[i].SubItems[2].Text));
                products += (Convert.ToInt32(listView2.Items[i].SubItems[0].Text));
            }
            textBoxTotal.Text = Convert.ToString(price);
            textBoxProductsQ.Text = Convert.ToString(products);
            textBoxVAT.Text = Convert.ToString(price * 0.15);
        }

        private void calculateMoneyGiven()
        {
            double price = 0;
            bool fix = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (!string.IsNullOrEmpty(listView1.Items[i].SubItems[0].Text))
                {
                    if (Double.TryParse(listView1.Items[i].SubItems[0].Text, out double tempP))
                    {
                        price += tempP;
                    }
                    else
                    {
                        fix = true;
                        listView1.Items[i].SubItems[0].Text = "0";
                    }
                }
            }
            textBox1.Text = Convert.ToString(price);
            if (fix)
            {
                MessageBox.Show("Please enter only numbers in amount field!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arr = new string[2];
            ListViewItem itm;
            arr[0] = "";
            arr[1] = comboBox1.SelectedItem.ToString();
            itm = new ListViewItem(arr);
            itm.ToolTipText = "Highlight item and click once on value to change add amount given!";
            listView1.Items.Add(itm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBoxTotal.Text)
            {

            }
            else
            {
                MessageBox.Show("Not sufficient given money to cover order!");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateMoneyGiven();
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            calculateMoneyGiven();
        }
    }
}
