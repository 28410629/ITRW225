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
    public partial class UI_Dashboard : Form
    {
        List<string[]> people;
        int countClient = 0;
        int countEmployee = 0;
        int countNewEmployee = 0;

        public UI_Dashboard()
        {
            InitializeComponent();
        }

        private void UI_Dashboard_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Properties.Resources.logo_465x320__1_;

            // get data for employees
            BE_DatabaseCommands commands = new BE_DatabaseCommands();
            people = commands.retrieveDB("PERSON");

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i][4] == "True" && people[i][3] == "False")
                {
                    countEmployee++;
                }
                if (people[i][4] == "False" && people[i][3] == "False")
                {
                    countClient++;
                }
                string some = "";
                for (int j = 0; j < people[0].Length; j++)
                {
                    some += people[i][j] + "\n";
                }
                MessageBox.Show(some);
            }
            labelClients.Text = "" + countClient;
            labelEmployees.Text = "" + countEmployee;
        }
    }
}
