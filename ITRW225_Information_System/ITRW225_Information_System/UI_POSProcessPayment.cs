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
            clientOrderCode = arr[9];
            try
            {
                orderP = commands.retrieveCustomDB("SELECT * FROM ORDER_PRODUCTS WHERE Client_Order_Code = " + clientOrderCode);
                products = commands.retrieveDB("PRODUCT");

                for (int i = 0; i < orderP.Count; i++)
                {
                    for (int j = 0; j < products.Count; j++)
                    {
                        if (orderP[i][2] == products[j][0])
                        {
                            //listView2
                        }
                    }
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
