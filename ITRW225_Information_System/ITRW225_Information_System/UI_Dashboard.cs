using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_Dashboard : Form
    {
        List<string[]> people;
        List<string[]> payments;
        List<string[]> orders;
        int countClient = 0;
        int countEmployee = 0;
        int countNewClient = 0;
        double countPayment = 0;
        int countOrdersToday = 0;
        int countActiveOrders = 0;
        int countCancelledOrder = 0;
        int countCompletedOrder = 0; 

        public UI_Dashboard()
        {
            InitializeComponent();
        }

        private void UI_Dashboard_Load(object sender, EventArgs e)
        {
            try
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
                    if (people[i][6].Contains(DateTime.Today.ToShortDateString()) && people[i][4] == "False" && people[i][3] == "False")
                    {
                        countNewClient++;
                    }
                }

                payments = commands.retrieveDB("PAYMENT_ORDER");

                for (int i = 0; i < payments.Count; i++)
                {
                    if (payments[i][5].Contains(DateTime.Today.ToShortDateString()))
                    {
                        countPayment += Convert.ToDouble(payments[i][3]);
                        countCompletedOrder++;
                    }
                }

                orders = commands.retrieveDB("CLIENT_ORDER");

                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i][7] == "False" && orders[i][6] == "False")
                    {
                        countActiveOrders++;
                    }
                    if (orders[i][5].Contains(DateTime.Today.ToShortDateString()))
                    {
                        countOrdersToday++;
                    }
                    if (orders[i][5].Contains(DateTime.Today.ToShortDateString()) && orders[i][6] == "True")
                    {
                        countCancelledOrder++;
                    }
                }

                textBoxOrdersDone.AppendText("\n");
                textBoxOrdersDone.AppendText("" + countCompletedOrder);

                textBoxCancelledOrder.AppendText("\n");
                textBoxCancelledOrder.AppendText("" + countCancelledOrder);

                textBoxActiveOrders.AppendText("\n");
                textBoxActiveOrders.AppendText("" + countActiveOrders);

                textBoxOrdersToday.AppendText("\n");
                textBoxOrdersToday.AppendText("" + countOrdersToday);

                textBoxClient.AppendText("\n");
                textBoxClient.AppendText("" + countClient);

                textBoxEmployee.AppendText("\n");
                textBoxEmployee.AppendText("" + countEmployee);

                textBoxClientToday.AppendText("\n");
                textBoxClientToday.AppendText("" + countNewClient);

                textBoxPayment.AppendText("\n");
                textBoxPayment.AppendText("R\n");
                textBoxPayment.AppendText("" + countPayment);

                for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month); i++)
                {
                    double sales = 0;
                    string year = "";
                    string month = "";
                    string day = "";
                    string compareDay = "";
                    for (int j = 0; j < payments.Count; j++)
                    {
                        year = payments[j][5].Remove(4);
                        month = payments[j][5].Substring(5);
                        month = month.Remove(2);
                        day = payments[j][5].Substring(8);
                        day = day.Remove(2);
                        compareDay = Convert.ToString(i);
                        if (compareDay.Length == 1)
                        {
                            compareDay = "0" + Convert.ToString(i);
                        }
                        if (year.Contains(DateTime.Today.Year + ""))
                        {
                            if (month.Contains(DateTime.Today.Month + ""))
                            {
                                if (day.Contains(compareDay))
                                {
                                    sales += Convert.ToDouble(payments[j][3]);
                                }
                            }
                        }
                    }
                    chart1.ChartAreas[0].AxisX.Interval = 3;
                    chart1.Series["Sales"].Points.AddXY(i, sales);
                    chart1.ChartAreas[0].AxisX.Title = "Day Of Month";
                    chart1.ChartAreas[0].AxisY.Title = "R";
                    chart1.Series["Sales"].BorderWidth = 3;
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    pictureBox1.Focus();
                }

                textBoxOrdersDone.Enabled = false;
                textBoxCancelledOrder.Enabled = false;
                textBoxActiveOrders.Enabled = false;
                textBoxOrdersToday.Enabled = false;
                textBoxClient.Enabled = false;
                textBoxEmployee.Enabled = false;
                textBoxClientToday.Enabled = false;
                textBoxPayment.Enabled = false;

            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }
    }
}
