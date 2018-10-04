using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_POSPlaceOrder : Form
    {
        BE_DatabaseCommands commands = new BE_DatabaseCommands();
        List<string[]> listProducts;
        List<string[]> listClient;
        List<string[]> listEmployee;
        string[] employeeArr;

        Form mainForm;
        public UI_POSPlaceOrder(Form mainForm, string[] employeeArr)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.employeeArr = employeeArr;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void UI_POSPlaceOrder_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker2.CustomFormat = "HH:mm";
                dateTimePicker2.Value = dateTimePicker2.Value.AddHours(1);

                listProducts = commands.retrieveCustomDB("SELECT * FROM PRODUCT ORDER BY Product_Name ASC");
                listClient = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID AND PERSON.Person_Is_Employee = False ORDER BY Person_Name ASC");
                listEmployee = commands.retrieveCustomDB("SELECT * FROM PERSON, CONTACT_DETAILS WHERE PERSON.Person_ID = CONTACT_DETAILS.Person_ID AND PERSON.Person_Is_Employee = True ORDER BY Person_Name ASC");

                for (int i = 0; i < listProducts.Count; i++)
                {
                    listBox1.Items.Add(listProducts[i][1] + " (R" + listProducts[i][2] + ")");
                }

                for (int i = 0; i < listClient.Count; i++)
                {
                    comboBox2.Items.Add(listClient[i][1] + " " + listClient[i][2]);
                }
                comboBox2.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {

        }

        private void listViewAdd(bool addItem, string item, string price)
        {
            listBox1.Enabled = false;
            if (addItem)
            {
                string[] arr = new string[3];
                ListViewItem itm;
                arr[0] = "1";
                arr[1] = item;
                arr[2] = price;
                itm = new ListViewItem(arr);
                itm.ToolTipText = "Highlight item and click once on value to change!";
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
            string price = "";
            for (int i = 0; i < listProducts.Count; i++)
            {

                if (itemString.Contains(listProducts[i][1]))
                {
                    price = listProducts[i][2];
                    itemString = listProducts[i][1];
                }
            }
            if (listView1.Items.Count == 0)
            {
                listViewAdd(true, itemString, price);
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

                listViewAdd(add, itemString, price);
            }
            calculateCost();
        }

        private void calculateCost()
        {
            double price = 0;
            int products = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                price += (Convert.ToDouble(listView1.Items[i].SubItems[0].Text) * Convert.ToDouble(listView1.Items[i].SubItems[2].Text));
                products += (Convert.ToInt32(listView1.Items[i].SubItems[0].Text));
            }
            textBox3.Text = Convert.ToString(price);
            textBox1.Text = Convert.ToString(products);
            textBox2.Text = Convert.ToString(price * 0.15);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            calculateCost();
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            calculateCost();
        }

        private void UI_POSPlaceOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            calculateCost();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please add products to order!");
            }
            else
            {
                string eID = "";
                for (int i = 0; i < listEmployee.Count; i++)
                {
                    if (employeeArr[1] == listEmployee[i][14])
                    {
                        eID = listEmployee[i][0];
                    }
                }
                try
                {
                    DateTime dueDate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, 0);
                    string query = String.Format("INSERT INTO CLIENT_ORDER (Employee_ID, Client_ID, Payment_Required, Payment_Order_Code, Date_Created, Order_Cancelled, Payment_Processed, Due_Date, Products) VALUES('" + eID + "', '" + listClient[comboBox2.SelectedIndex][0] + "', " + textBox3.Text + ", 0, @1, False, False, @2, " + textBox1.Text + ")");
                    string query2 = "Select @@Identity";
                    int ID;
                    using (OleDbConnection db = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                    {
                        db.Open();
                        OleDbDataAdapter adpt = new OleDbDataAdapter("SELECT * FROM CLIENT_ORDER", db);
                        OleDbCommand cmd = new OleDbCommand(query, db);
                        cmd.Parameters.Add("@1", OleDbType.Date).Value = DateTime.Today;
                        cmd.Parameters.Add("@2", OleDbType.Date).Value = dueDate;
                        adpt.InsertCommand = cmd;
                        adpt.InsertCommand.ExecuteNonQuery();
                        cmd.CommandText = query2;
                        ID = (int)cmd.ExecuteScalar();
                        db.Close();
                    }
                    bool add = false;
                    int pID = 0;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        add = false;
                        for (int j = 0; j < listProducts.Count; j++)
                        {
                            if (listProducts[j][1] == listView1.Items[i].SubItems[1].Text)
                            {
                                add = true;
                                pID = j;
                            }
                        }
                        if (add)
                        {
                            commands.addDB("INSERT INTO ORDER_PRODUCTS (Client_Order_Code, Product_Number, Product_Amount) VALUES(" + ID + ", " + listProducts[pID][0] + ", " + listView1.Items[i].SubItems[0].Text + ")", "ORDER_PRODUCTS");
                        }
                    }
                    MessageBox.Show("Successfully added order!");
                }
                catch (Exception ex)
                {
                    BE_LogSystem log = new BE_LogSystem(ex);
                    log.saveError();
                    MessageBox.Show("Failed adding order!");
                }
            }
        }
    }
}
