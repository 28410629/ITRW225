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
        private Form mainForm;
        private string[] arr;

        public UI_POSProcessPayment(Form mainForm, string[] arr)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.arr = arr; // this array must be a selected * from the following table order! CLIENT_ORDER, CONTACT_DETAILS, PERSON 
        }
    }
}
