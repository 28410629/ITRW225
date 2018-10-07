using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_POSViewPastOrder : Form
    {
        private List<string[]> order;
        private Form mainForm;
        private string[] userArr;

        public UI_POSViewPastOrder(Form mainForm, string[] userArr)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.userArr = userArr;
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void UI_POSViewPastOrder_Load(object sender, EventArgs e)
        {
            try
            {
                BE_DatabaseCommands commands = new BE_DatabaseCommands();
                order = commands.retrieveCustomDB("SELECT * FROM CLIENT_ORDER, CONTACT_DETAILS, PERSON WHERE CLIENT_ORDER.Client_ID = CONTACT_DETAILS.Person_ID AND CLIENT_ORDER.Client_ID = PERSON.Person_ID ORDER BY CLIENT_ORDER.Date_Created ASC");

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
                        int dayS = 1;
                        int dayE = DateTime.DaysInMonth(y, m);
                        if (y == startYear)
                        {
                            string s = order[0][5].Substring(8);
                            s = s.Remove(2);
                            dayS = Convert.ToInt32(s);
                        }
                        if (y == endYear)
                        {
                            string s = order[order.Count - 1][5].Substring(8);
                            s = s.Remove(2);
                            dayE = Convert.ToInt32(s);
                        }
                        for (int d = dayS; d <= dayE; d++)
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
                                if (Convert.ToInt32(year) == y)
                                {
                                    if (Convert.ToInt32(month) == m)
                                    {
                                        if (Convert.ToInt32(day) == d)
                                        {
                                            count++;
                                            string[] arr = new string[5];
                                            ListViewItem itm;
                                            arr[0] = order[o][0];
                                            arr[1] = order[o][20] + " " + order[o][21]; // name
                                            arr[2] = order[o][18]; // id
                                            arr[3] = y + "-" + m + "-" + d; // date
                                            arr[4] = order[o][3];
                                            itm = new ListViewItem(arr);
                                            itm.ToolTipText = "Double click an item to see the details!";
                                            listView1.Items.Add(itm);
                                        }
                                    }
                                }
                            }
                            chart1.Series["Sales"].Points.AddXY(y + "-" + m + "-" + d, count);
                        }
                    }
                }
                chart1.Series["Sales"].BorderWidth = 5;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }
    }
}
