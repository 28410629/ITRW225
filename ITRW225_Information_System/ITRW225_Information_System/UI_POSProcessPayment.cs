using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
        List<string[]> listEmployee;
        string[] userArr;

        public UI_POSProcessPayment(Form mainForm, string[] arr, string[] userArr)
        {
            this.userArr = userArr;
            InitializeComponent();
            this.mainForm = mainForm;
            this.arr = arr; // this array must be a selected * from the following table order! CLIENT_ORDER, CONTACT_DETAILS, PERSON 
        }

        private void UI_POSProcessPayment_Load(object sender, EventArgs e)
        {
            try
            {
                Text += " " + arr[0];
                listEmployee = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID AND PERSON.Person_Is_Employee = True ORDER BY Person_Name ASC");
                textBoxID.Text = arr[19];
                textBoxN.Text = arr[20] + " " + arr[21];
                textBoxCN1.Text = arr[13];
                textBoxEA.Text = arr[17];
                clientOrderCode = arr[0];

                if (string.IsNullOrWhiteSpace(arr[9]) || arr[9] == "0")
                {
                    MessageBox.Show("No products on this order!");
                    textBoxTotal.Text = "0";
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
                try
                {
                    string eID = "";
                    for (int i = 0; i < listEmployee.Count; i++)
                    {
                        if (userArr[1] == listEmployee[i][14])
                        {
                            eID = listEmployee[i][0];
                        }
                    }
                    string msg = "";
                    listView1.Sort();
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (i == 0)
                        {
                            msg += listView1.Items[i].SubItems[1].Text;
                        }
                        else
                        {
                            msg += ", " + listView1.Items[i].SubItems[1].Text;
                        }
                        
                    }
                    DateTime dueDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, 0);
                    string query = String.Format("INSERT INTO PAYMENT_ORDER (Client_Order_Code, Employee_ID, Payment_Amount, Payment_Type, Date_Created) VALUES({0}, '{1}', {2}, '{3}', @1)", arr[0], eID, arr[3], msg);
                    string query2 = "Select @@Identity";
                    int ID;
                    using (OleDbConnection db = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                    {
                        db.Open();
                        OleDbDataAdapter adpt = new OleDbDataAdapter("SELECT * FROM PAYMENT_ORDER", db);
                        OleDbCommand cmd = new OleDbCommand(query, db);
                        cmd.Parameters.Add("@1", OleDbType.Date).Value = DateTime.Today;
                        adpt.InsertCommand = cmd;
                        adpt.InsertCommand.ExecuteNonQuery();
                        cmd.CommandText = query2;
                        ID = (int)cmd.ExecuteScalar();
                        db.Close();
                    }
                    commands.updateDB("UPDATE CLIENT_ORDER SET Payment_Processed = True, Payment_Order_Code = " + ID +" WHERE Client_Order_Code = " + clientOrderCode, "CLIENT_ORDER");
                    MessageBox.Show("Successfully processed payment!");
                }
                catch (Exception ex)
                {
                    BE_LogSystem log = new BE_LogSystem(ex);
                    log.saveError();
                    MessageBox.Show("Failed processing payment!");
                }
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

        private void UI_POSProcessPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            calculateMoneyGiven();
        }
    }
}
