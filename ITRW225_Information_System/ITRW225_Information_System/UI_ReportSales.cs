using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_ReportSales : Form
    {
        List<string[]> payments;
        Form mainForm;

        public UI_ReportSales(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void UI_ReportSales_Load(object sender, EventArgs e)
        {
            BE_DatabaseCommands commands = new BE_DatabaseCommands();
            payments = commands.retrieveDB("PAYMENT_ORDER");
            loadGraph();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void UI_ReportSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((mainForm.MdiChildren.Length - 1) == 0)
            {
                UI_Dashboard dashboard = new UI_Dashboard();
                dashboard.MdiParent = mainForm;
                dashboard.Show();
            }
        }
        private void loadGraph()
        {
            chart1.Titles["Title1"].Text = dateTimePicker1.Value.ToString("MMMM") + " " + dateTimePicker1.Value.Year;
            chart1.Series["Sales"].Points.Clear();
            for (int i = 1; i <= DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month); i++)
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
                    if (year.Contains(dateTimePicker1.Value.Year + ""))
                    {
                        if (month.Contains(dateTimePicker1.Value.Month + ""))
                        {
                            if (day.Contains(compareDay))
                            {
                                sales += Convert.ToDouble(payments[j][3]);
                            }
                        }
                    }
                }
                chart1.Series["Sales"].Points.AddXY(i, sales);
                chart1.ChartAreas[0].AxisX.Title = "Day Of Month";
                chart1.ChartAreas[0].AxisY.Title = "R";
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series["Sales"].BorderWidth = 5;
            }
        }
    }
}
