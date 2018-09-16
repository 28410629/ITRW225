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
    public partial class UI_POSViewOrder : Form
    {
        private Form mainForm;
        private string Client_Order_Code;
        private BE_DatabaseCommands commands = new BE_DatabaseCommands();
        private List<string[]> clientOrder;
        private List<string[]> paymentOrder;
        private List<string[]> orderProducts;
        private List<string[]> persons;
        private List<string[]> contactDetails;
        private List<string[]> products;

        public UI_POSViewOrder(Form mainForm, string Client_Order_Code)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Client_Order_Code = Client_Order_Code;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BE_PDF_OrderInvoice invoice = new BE_PDF_OrderInvoice();
        }

        private void UI_POSViewOrder_Load(object sender, EventArgs e)
        {
            try
            {
                persons = commands.retrieveDB("PERSON");
                orderProducts = commands.retrieveCustomDB("SELECT * FROM ORDER_PRODUCTS WHERE Client_Order_Code = " + Client_Order_Code);
                products = commands.retrieveDB("PRODUCT");
                paymentOrder = commands.retrieveCustomDB("SELECT * FROM PAYMENT_ORDER WHERE Client_Order_Code = " + Client_Order_Code);
                clientOrder = commands.retrieveCustomDB("SELECT * FROM CLIENT_ORDER WHERE Client_Order_Code = " + Client_Order_Code);
                contactDetails = commands.retrieveDB("CONTACT_DETAILS");
                
                // client order information                
                if (clientOrder != null)
                {
                    Text += clientOrder[0][0];
                    textBoxTotal.Text = clientOrder[0][3];
                    if (clientOrder[0][6] == "True")
                    {
                        groupBox7.Text = "Order Was Cancelled";
                        textBox7.Text = "Canceled";
                        textBox6.Text = "Canceled"; // name
                        textBox4.Text = "Canceled";
                    }
                    textBox5.Text = clientOrder[0][5].Remove(10);
                    textBoxProductsQ.Text = clientOrder[0][9];
                    textBox1.Text = clientOrder[0][1];
                }

                // payment order information
                try
                {
                    textBox4.Text = paymentOrder[0][2];
                    textBox7.Text = paymentOrder[0][5].Remove(10);
                }
                catch (Exception)
                {
                }

                // order products information
                if (orderProducts != null && products != null)
                {
                    for (int i = 0; i < orderProducts.Count; i++)
                    {
                        for (int j = 0; j < products.Count; j++)
                        {
                            if (orderProducts[i][2] == products[j][0])
                            {
                                string[] arr = new string[3];
                                ListViewItem itm;
                                arr[0] = orderProducts[i][3];
                                arr[1] = products[j][1];
                                arr[2] = products[j][2];
                                itm = new ListViewItem(arr);
                                listView2.Items.Add(itm);
                            }
                        }
                    }
                }

                // order persons information
                if (persons != null)
                {
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (textBox1.Text == persons[i][0])
                        {
                            textBox3.Text = persons[i][1] + " " + persons[i][2];
                        }
                        if (textBox4.Text == persons[i][0])
                        {
                            textBox6.Text = persons[i][1] + " " + persons[i][2];
                        }
                        if (clientOrder[0][2] == persons[i][0])
                        {
                            textBoxFN.Text = persons[i][1];
                            textBoxLN.Text = persons[i][2];
                        }
                    }
                }

                // contact details
                if (contactDetails != null)
                {
                    for (int i = 0; i < contactDetails.Count; i++)
                    {
                        if (clientOrder[0][2] == contactDetails[i][8])
                        {
                            textBoxID.Text = clientOrder[0][2];
                            textBoxHN.Text = contactDetails[i][0];
                            textBoxSN.Text = contactDetails[i][1];
                            textBoxPC.Text = contactDetails[i][2];
                            textBoxCN.Text = contactDetails[i][3];
                            textBoxCN2.Text = contactDetails[i][4];
                            textBoxS.Text = contactDetails[i][5];
                            textBox2.Text = contactDetails[i][6].Trim(); // city
                            textBoxEA.Text = contactDetails[i][7];
                        }
                    }
                }

                textBoxVAT.Text = (0.15 * Convert.ToDouble(textBoxTotal.Text)) + "";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void UI_POSViewOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }
    }
}
