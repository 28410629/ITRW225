using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;

namespace ITRW225_Information_System
{
    public class BE_PDF_SalesDay
    {

        public string createPDF(string chartPath, List<string[]> listSales)
        {
            try
            {
                // define page Size
                Rectangle rec = new Rectangle(PageSize.A4);

                // Setting Background Color of PDF Document
                rec.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);

                string appRootDir = Properties.Settings.Default.ReportsSavePath;

                // Step 1: Creating System.IO.FileStream object
                string day = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.ToString("hmm");
                using (FileStream fs = new FileStream(appRootDir + "\\Sales Report Day - " + day + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None))

                // Step 2: Creating iTextSharp.text.Document object

                // NOTE: In iTextSharp library, 72 points = 1 inch
                // Left Margin:		36pt	=> 0.5 inch
                // Right Margin:	72pt	=> 1 inch
                // Top Margin:		108pt	=> 1.5 inch
                // Bottom Margini:	180pt	=> 2.5 inch
                using (Document doc = new Document(rec, 72, 72, 72, 72))

                // Step 3: Creating iTextSharp.text.pdf.PdfWriter object
                // It helps to write the Document to the Specified FileStream
                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    doc.AddTitle("Sales Report Day - " + day);
                    doc.AddSubject("Created On " + DateTime.Today.ToLongDateString() + " " + DateTime.Today.TimeOfDay.ToString());
                    doc.AddKeywords("Mr Salad, Invoice, Order," + day);
                    doc.AddCreator("Mr Salad");
                    doc.AddAuthor("Mr Salad");
                    doc.AddHeader("Nothing", "No Header");

                    // Openning the Document
                    doc.Open();

                    // add image
                    Image png = Image.GetInstance(Properties.Resources.logo_465x320__1_, ImageFormat.Png);
                    png.ScaleToFit(150f, 150f);
                    png.Alignment = Image.TEXTWRAP | Image.ALIGN_LEFT;
                    png.IndentationLeft = 9f;
                    png.SpacingAfter = 9f;
                    doc.Add(png);

                    // mr salad details
                    doc.Add(new Chunk("\n"));
                    doc.Add(new Chunk("\n"));
                    Paragraph salad = new Paragraph("    Address : C/O Harrington and");
                    salad.Alignment = Element.ALIGN_LEFT;
                    doc.Add(salad);

                    salad = new Paragraph("    St Monica Road, Hartebeespoort");
                    salad.Alignment = Element.ALIGN_LEFT;
                    doc.Add(salad);

                    salad = new Paragraph("    Contact Number: 012 253 1100");
                    salad.Alignment = Element.ALIGN_LEFT;
                    doc.Add(salad);

                    salad = new Paragraph("    Email Address : mrsaladharties@gmail.com");
                    salad.Alignment = Element.ALIGN_LEFT;

                    doc.Add(salad);

                    doc.Add(new Chunk("\n"));
                    doc.Add(new Chunk("\n"));
                    //doc.Add(new Chunk("\n"));
                    //doc.Add(new Chunk("\n"));

                    // chart
                    Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    doc.Add(p);

                    Paragraph client = new Paragraph(@"DAY SALES REPORT - " + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + " AT " + DateTime.Now.ToString("h:mm tt"));
                    client.Alignment = Element.ALIGN_CENTER;
                    doc.Add(client);

                    doc.Add(p);

                    doc.Add(new Chunk("\n"));

                    png = Image.GetInstance(chartPath);
                    png.ScaleToFit(500f, 500f);
                    png.Alignment = Image.ALIGN_CENTER;
                    png.IndentationLeft = 9f;
                    png.SpacingAfter = 9f;
                    doc.Add(png);

                    doc.NewPage();
                    // invoice details
                    doc.Add(p);

                    Paragraph invoice = new Paragraph(@"SALES");
                    invoice.Alignment = Element.ALIGN_CENTER;
                    doc.Add(invoice);

                    doc.Add(p);

                    doc.Add(new Chunk("\n"));

                    float[] widths = new float[] { 3f, 3f, 3f };
                    PdfPTable table = new PdfPTable(widths);

                    PdfPCell cell;
                    double price;
                    double count = 0;
                    double priceTotal = 0;

                    cell = new PdfPCell(new Phrase("Order Number"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("VAT"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Total Price"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    for (int i = 0; i < listSales.Count; i++)
                    {

                    }

                    cell = new PdfPCell(new Phrase(Convert.ToString(count)));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("TOTALS"));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("R " + Convert.ToString(priceTotal * 0.15)));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("R " + Convert.ToString(priceTotal)));
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);

                    doc.Add(table);

                    doc.Add(new Chunk("\n"));

                    // Closing the Document
                    doc.Close();
                }
                System.Diagnostics.Process.Start(appRootDir + "\\Sales Report Day - " + day + ".pdf");
                return "Report Generated";
            }
            catch (Exception ex)
            {
                BE_LogSystem log = new BE_LogSystem(ex);
                log.saveError();
                return "Error, try again.";
            }
        }
    }
}
