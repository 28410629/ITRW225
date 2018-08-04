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
    public partial class UI_UserMaintenance : Form
    {
        private BE_UserMaintenance maintenance;
        private List<string[]> listE;
        private List<string[]> listL;

        public UI_UserMaintenance()
        {
            this.maintenance = new BE_UserMaintenance();
            InitializeComponent();
        }

        private void UI_UserMaintenance_Load(object sender, EventArgs e)
        {
            listE = maintenance.loadEmployee();
            listL = maintenance.loadLogin();
            for (int i = 0; i < listE.Count; i++)
            {
                comboBoxEmployee.Items.Add(listE[i][1]);
            }
            comboBoxEmployee.SelectedIndex = 0;
        }

        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listE.Count; i++)
            {
                if (listE[i][1] == comboBoxEmployee.SelectedItem.ToString())
                {
                    checkBoxCM.Checked = Convert.ToBoolean(listL[i][2]);
                    checkBoxEM.Checked = Convert.ToBoolean(listL[i][3]);
                    checkBoxPOS.Checked = Convert.ToBoolean(listL[i][4]);
                    checkBoxR.Checked = Convert.ToBoolean(listL[i][5]);
                    checkBoxUM.Checked = Convert.ToBoolean(listL[i][6]);
                    checkBoxS.Checked = Convert.ToBoolean(listL[i][7]);
                    if (Convert.ToBoolean(listL[i][8]))
                    {
                        labelStatus.Text = "User can access system.";
                    }
                    else
                    {
                        labelStatus.Text = "User is denied access to system.";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBoxP1.Text))
            {
                if (textBoxP1.Text == textBoxP2.Text)
                {
                    for (int i = 0; i < listE.Count; i++)
                    {
                        if (listE[i][1] == comboBoxEmployee.SelectedItem.ToString())
                        {
                            bool[] arr = new bool[] { checkBoxCM.Checked, checkBoxEM.Checked, checkBoxPOS.Checked, checkBoxR.Checked, checkBoxUM.Checked, checkBoxS.Checked };
                            MessageBox.Show(maintenance.updatePassCheckDB(arr, listE[i][0], textBoxP1.Text));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure passwords are the same, thank you.");
                }
            }
            else
            {
                for (int i = 0; i < listE.Count; i++)
                {
                    if (listE[i][1] == comboBoxEmployee.SelectedItem.ToString())
                    {
                        bool[] arr = new bool[] { checkBoxCM.Checked, checkBoxEM.Checked, checkBoxPOS.Checked, checkBoxR.Checked, checkBoxUM.Checked, checkBoxS.Checked };
                        MessageBox.Show(maintenance.updateCheckDB(arr, listE[i][0]));
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAllow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listE.Count; i++)
            {
                if (listE[i][1] == comboBoxEmployee.SelectedItem.ToString())
                {
                    MessageBox.Show(maintenance.accessSystemDB(listL[i][8], listE[i][0]));
                    labelStatus.Text = "User can access system.";
                }
            }
        }

        private void buttonDeny_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listE.Count; i++)
            {
                if (listE[i][1] == comboBoxEmployee.SelectedItem.ToString())
                {
                    MessageBox.Show(maintenance.accessSystemDB(listL[i][8], listE[i][0]));
                    labelStatus.Text = "User is denied access to system.";
                }
            }
        }
    }
}
