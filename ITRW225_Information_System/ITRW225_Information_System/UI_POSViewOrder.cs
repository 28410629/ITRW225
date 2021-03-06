﻿using System;
using System.Collections.Generic;
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
        private List<string[]> order;
        private string[] userArr;
        private bool sendInvoice;

        public UI_POSViewOrder(Form mainForm, string Client_Order_Code, bool sendInvoice, string[] userArr)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Client_Order_Code = Client_Order_Code;
            this.sendInvoice = sendInvoice;
            this.userArr = userArr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmpProcessName.Text) || string.IsNullOrWhiteSpace(textBoxEmpProcessID.Text) || string.IsNullOrWhiteSpace(textBoxProcessedDate.Text))
            {
                MessageBox.Show("Order must be processed before sending invoice!");
            }
            else
            {
                BE_PDF_OrderInvoice invoice = new BE_PDF_OrderInvoice();
                List<List<string>> list = new List<List<string>>();
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    List<string> item = new List<string>();
                    for (int j = 0; j < listView2.Items[0].SubItems.Count; j++)
                    {
                        item.Add(listView2.Items[i].SubItems[j].Text);
                    }
                    list.Add(item);
                }
                string attachmentPath = invoice.createPDF(clientOrder[0][0], textBoxFN.Text, textBoxLN.Text, textBoxID.Text, textBoxCN.Text, textBoxCN2.Text, textBoxEA.Text, textBoxHN.Text, textBoxSN.Text, textBoxS.Text, textBoxCity.Text, textBoxPC.Text, textBoxEmpCreatedName.Text, textBoxOrderCreatedDate.Text, textBoxEmpProcessName.Text, textBoxProcessedDate.Text, textBoxProductsQ.Text, textBoxVAT.Text, textBoxTotal.Text, list);
                BE_SendEmail mail = new BE_SendEmail();
                string[] arr = new string[] { textBoxEA.Text };
                string body = "Good day " + textBoxFN.Text + "\n\nPlease see your attached your invoice for order " + clientOrder[0][0] + ".\n\nKind regards,\nMr Salad";
                mail.sendMailAttachment(arr, body, "Invoice, Order " + clientOrder[0][0], attachmentPath);
            }
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
                        textBoxProcessedDate.Text = "Canceled";
                        textBoxEmpProcessName.Text = "Canceled"; // name
                        textBoxEmpProcessID.Text = "Canceled";
                    }
                    textBoxOrderCreatedDate.Text = clientOrder[0][5].Remove(10);
                    textBoxProductsQ.Text = clientOrder[0][9];
                    textBoxEmpCreatedID.Text = clientOrder[0][1];
                }

                // payment order information
                try
                {
                    textBoxEmpProcessID.Text = paymentOrder[0][2];
                    textBoxProcessedDate.Text = paymentOrder[0][5].Remove(10);
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
                        if (textBoxEmpCreatedID.Text == persons[i][0])
                        {
                            textBoxEmpCreatedName.Text = persons[i][1] + " " + persons[i][2];
                        }
                        if (textBoxEmpProcessID.Text == persons[i][0])
                        {
                            textBoxEmpProcessName.Text = persons[i][1] + " " + persons[i][2];
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
                            textBoxCity.Text = contactDetails[i][6].Trim(); // city
                            textBoxEA.Text = contactDetails[i][7];
                        }
                    }
                }

                textBoxVAT.Text = (0.15 * Convert.ToDouble(textBoxTotal.Text)) + "";
                if(sendInvoice)
                {
                    button1_Click(sender, e);
                }

                if (string.IsNullOrWhiteSpace(textBoxEmpProcessName.Text) || string.IsNullOrWhiteSpace(textBoxEmpProcessID.Text) || string.IsNullOrWhiteSpace(textBoxProcessedDate.Text))
                {
                    button1.Enabled = false;
                }
                else if (textBoxEmpProcessName.Text == "Canceled")
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                }
                else
                {
                    button2.Enabled = false;
                }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                bool process = true;
                foreach (var item in mainForm.MdiChildren)
                {
                    if (item is UI_POSProcessPayment)
                    {
                        item.Focus();
                        MessageBox.Show("Please finish payment process before doing another, thank you!");
                        process = false;
                        return;
                    }
                    if (item is UI_Dashboard)
                    {
                        item.Close();
                    }
                }
                if (process)
                {
                    order = commands.retrieveCustomDB("SELECT * FROM CLIENT_ORDER, CONTACT_DETAILS, PERSON WHERE CLIENT_ORDER.Client_ID = CONTACT_DETAILS.Person_ID AND CLIENT_ORDER.Client_ID = PERSON.Person_ID AND CLIENT_ORDER.Payment_Processed = False AND CLIENT_ORDER.Order_Cancelled = False ORDER BY CLIENT_ORDER.Date_Created ASC");
                    int selected = 0;
                    for (int i = 0; i < order.Count; i++)
                    {
                        if (order[i][0] == clientOrder[0][0])
                        {
                            selected = i;
                        }
                    }
                    UI_POSProcessPayment user = new UI_POSProcessPayment(mainForm, order[selected], userArr);
                    user.MdiParent = mainForm;
                    user.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }
    }
}
