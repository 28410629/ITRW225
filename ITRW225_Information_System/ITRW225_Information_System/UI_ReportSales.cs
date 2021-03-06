﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ITRW225_Information_System
{
    public partial class UI_ReportSales : Form
    {
        List<string[]> payments;
        Form mainForm;
        List<string[]> daySales = new List<string[]>();
        List<string[]> nonthSales = new List<string[]>();

        public UI_ReportSales(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void UI_ReportSales_Load(object sender, EventArgs e)
        {
            try
            {
                BE_DatabaseCommands commands = new BE_DatabaseCommands();
                payments = commands.retrieveDB("PAYMENT_ORDER");
                loadGraph();
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadGraph();
            loadGraphDay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Properties.Settings.Default.ReportsSavePath))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.ReportsSavePath);
                }
                string path = Properties.Settings.Default.ReportsSavePath + "\\Sales Report Month - " + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.ToString("hmm") + ".png";
                chart1.SaveImage(path, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                BE_PDF_SalesMonthly saled = new BE_PDF_SalesMonthly();
                if (nonthSales.Count == 0)
                {
                    string[] date = new string[] { dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + "0000000", "", "" };
                    nonthSales.Add(date);
                }
                saled.createPDF(path, nonthSales);
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Properties.Settings.Default.ReportsSavePath))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.ReportsSavePath);
                }
                string path = Properties.Settings.Default.ReportsSavePath + "\\Sales Report Day - " + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.ToString("hmm") + ".png";
                chart2.SaveImage(path, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                BE_PDF_SalesDay saled = new BE_PDF_SalesDay();
                if (daySales.Count == 0)
                {
                    string[] date = new string[] { "", "", "", "", "", dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + "0000000" };
                    daySales.Add(date);
                }
                saled.createPDF(path, daySales);
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
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

        private void loadGraphDay()
        {
            try
            {
                daySales.Clear();
                chart2.ChartAreas[0].AxisX.Interval = 1;
                chart2.Titles["Title1"].Text = "Order Comparision For " + dateTimePicker1.Value.Day + " " + dateTimePicker1.Value.ToString("MMMM") + " " + dateTimePicker1.Value.Year;
                chart2.Series["Sales"].Points.Clear();
                int count = 1;
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
                    compareDay = Convert.ToString(dateTimePicker1.Value.Day);
                    if (compareDay.Length == 1)
                    {
                        compareDay = "0" + Convert.ToString(dateTimePicker1.Value.Day);
                    }
                    if (year.Contains(dateTimePicker1.Value.Year + ""))
                    {
                        if (month.Contains(dateTimePicker1.Value.Month + ""))
                        {
                            if (day.Contains(compareDay))
                            {
                                daySales.Add(payments[j]);
                                chart2.Series["Sales"].Points.AddXY(count, Convert.ToDouble(payments[j][3]));
                                count++;
                            }
                        }
                    }
                }
                chart2.Series["Sales"].BorderWidth = 5;
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
            }
        }

        private void loadGraph()
        {
            try
            {
                nonthSales.Clear();
                chart1.ChartAreas[0].AxisX.Interval = 2;
                chart1.Titles["Title1"].Text = "Daily Sales For " + dateTimePicker1.Value.ToString("MMMM") + " " + dateTimePicker1.Value.Year;
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
                    nonthSales.Add(new string[] { year + "-" + month + "-" + i, (sales * 0.15) + "", sales.ToString() });
                    chart1.Series["Sales"].Points.AddXY(i, sales);
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Series["Sales"].BorderWidth = 5;
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
