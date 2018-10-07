using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_POSActiveOrder : Form
    {
        Form mainForm;
        List<string[]> order;
        List<string> cancel = new List<string>();
        BE_DatabaseCommands commands = new BE_DatabaseCommands();
        private string[] userArr;

        public UI_POSActiveOrder(Form mainForm, string[] userArr)
        {
            this.userArr = userArr;
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageBox.Show(this, "Are you sure you want to cancel the order?", "Cancel Order", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        break;
                    case DialogResult.Yes:
                        if (listView1.SelectedItems.Count == 1)
                        {
                            string query = "UPDATE CLIENT_ORDER SET Order_Cancelled = True, Date_Created = @1 WHERE Client_Order_Code = ";
                            while (listView1.SelectedItems.Count > 0)
                            {
                                query += listView1.SelectedItems[0].SubItems[0].Text.ToString();
                                listView1.Items.Remove(listView1.SelectedItems[0]);
                            }
                            using (OleDbConnection db = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                            {
                                db.Open();
                                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM CLIENT_ORDER", db);
                                OleDbCommand command = new OleDbCommand(query, db);
                                command.Parameters.Add("@1", OleDbType.Date).Value = DateTime.Today;
                                adapter.InsertCommand = command;
                                adapter.InsertCommand.ExecuteNonQuery();
                                db.Close();
                            }
                        }
                        else if (listView1.SelectedItems.Count == 0)
                        {
                            MessageBox.Show("Please select an order to cancel.");
                        }
                        else
                        {
                            MessageBox.Show("Multiple cancelations are not allowed!");
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void UI_POSActiveOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }

        private void UI_POSActiveOrder_Load(object sender, EventArgs e)
        {
            try
            {
                order = commands.retrieveCustomDB("SELECT * FROM CLIENT_ORDER, CONTACT_DETAILS, PERSON WHERE CLIENT_ORDER.Client_ID = CONTACT_DETAILS.Person_ID AND CLIENT_ORDER.Client_ID = PERSON.Person_ID AND CLIENT_ORDER.Payment_Processed = False AND CLIENT_ORDER.Order_Cancelled = False ORDER BY CLIENT_ORDER.Date_Created ASC");

                for (int i = 0; i < order.Count; i++)
                {
                    string[] arr = new string[6];
                    ListViewItem itm;
                    arr[0] = order[i][0]; // order code
                    arr[1] = order[i][20] + " " + order[i][21]; // name
                    arr[2] = order[i][2]; // id
                    arr[3] = order[i][5].Remove(10); ; // date created
                    arr[4] = order[i][8].Remove(10); ; // date due
                    arr[5] = order[i][3]; // price
                    itm = new ListViewItem(arr);
                    itm.ToolTipText = "Use checkbox and cancel button to cancel an active order, otherwise double-click for details!";
                    listView1.Items.Add(itm);
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    foreach (var item in mainForm.MdiChildren)
                    {
                        if (item is UI_POSProcessPayment)
                        {
                            item.Focus();
                            MessageBox.Show("Please finish payment process before doing another, thank you!");
                            return;
                        }
                        if (item is UI_Dashboard)
                        {
                            item.Close();
                        }
                    }
                    int selected = 0;
                    for (int i = 0; i < order.Count; i++)
                    {
                        if (order[i][0] == listView1.SelectedItems[0].SubItems[0].Text.ToString())
                        {
                            selected = i;
                        }
                    }
                    UI_POSProcessPayment user = new UI_POSProcessPayment(mainForm, order[selected], userArr);
                    user.MdiParent = mainForm;
                    user.Show();
                    Close();
                }
                else if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select an order to process.");
                }
                else
                {
                    MessageBox.Show("Multiple cancelations are not allowed!");
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int selected = 0;
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i][0] == listView1.SelectedItems[0].SubItems[0].Text.ToString())
                {
                    selected = i;
                }
            }
            UI_POSViewOrder user = new UI_POSViewOrder(mainForm, order[selected][0], false, userArr);
            user.MdiParent = mainForm;
            user.Show();
            Close();
        }
    }
}
