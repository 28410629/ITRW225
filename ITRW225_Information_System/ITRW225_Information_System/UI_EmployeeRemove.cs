﻿using System;
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
    public partial class UI_EmployeeRemove : Form
    {
        private string[] userArr;

        public UI_EmployeeRemove(string[] userArr)
        {
            this.userArr = userArr;
            InitializeComponent();
        }
    }
}
