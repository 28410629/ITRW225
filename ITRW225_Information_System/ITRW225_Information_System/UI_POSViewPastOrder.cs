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
    public partial class UI_POSViewPastOrder : Form
    {
        private List<string[]> order;
        Form mainForm;
        public UI_POSViewPastOrder(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void UI_POSViewPastOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("It works");
        }

        private void UI_POSViewPastOrder_Load(object sender, EventArgs e)
        {
            BE_DatabaseCommands commands = new BE_DatabaseCommands();
            order = commands.retrieveCustomDB("SELECT * FROM CLIENT_ORDER ORDER BY [Date_Created] ASC");

            chart1.ChartAreas[0].AxisX.Title = "Date";
            chart1.ChartAreas[0].AxisY.Title = "Orders Quantity";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            int startYear = Convert.ToInt32(order[0][5].Remove(4));
            int endYear = Convert.ToInt32(order[order.Count - 1][5].Remove(4));

            for (int y = startYear; y <= endYear; y++)
            {
                int mth = 1;
                int mthE = 12;
                if (y == startYear)
                {
                    string s = order[0][5].Substring(5);
                    s = s.Remove(2);
                    mth = Convert.ToInt32(s);
                }
                if (y == endYear)
                {
                    string s = order[order.Count - 1][5].Substring(5);
                    s = s.Remove(2);
                    mthE = Convert.ToInt32(s);
                }
                for (int m = mth; m <= mthE; m++)
                {
                    for (int d = 1; d < DateTime.DaysInMonth(y, m); d++)
                    {
                        double count = 0;
                        string year = "";
                        string month = "";
                        string day = "";
                        for (int o = 0; o < order.Count; o++)
                        {
                            year = order[o][5].Remove(4);
                            month = order[o][5].Substring(5);
                            month = month.Remove(2);
                            day = order[o][5].Substring(8);
                            day = day.Remove(2);
                            //MessageBox.Show("date: " + y + m + d + "\ncompare:" + year + month + day + "\ncount:" + count);
                            if (Convert.ToInt32(year) == y)
                            {
                                if (Convert.ToInt32(month) == m)
                                {
                                    if (Convert.ToInt32(day) == d)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                        chart1.Series["Sales"].Points.AddXY(y + "-" + m + "-" + d, count);
                        //MessageBox.Show("date: " + y + m + d + "\ncount:" + count);
                    }
                }
            }
        }
    }
}
