using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;

namespace ITRW225_Information_System
{
    public class BE_PDF_OrderInvoice
    {
        public string createPDF(string clientOrderCode, string clientFN, string clientLN, string clientID, string clientCN1, string clientCN2, string clientEA,
                                string clientHN, string clientSN, string clientS, string clientC, string clientPC, string cEmpName,
                                string cEmpDate, string pEmpName, string pEmpDate, string productsAmount, string vat, string total, List<List<string>> productlist)
        {
            try
            {
                // define page Size
                Rectangle rec = new Rectangle(PageSize.A4);

                // Setting Background Color of PDF Document
                rec.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);

                string appRootDir = Properties.Settings.Default.InvoiceSavePath;
                if (!Directory.Exists(appRootDir))
                {
                    Directory.CreateDirectory(appRootDir);
                }

                // Step 1: Creating System.IO.FileStream object
                using (FileStream fs = new FileStream(appRootDir + "\\Invoice - Order " + clientOrderCode + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None))

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
                    doc.AddTitle("Invoice - Order " + clientOrderCode);
                    doc.AddSubject("Created On " + DateTime.Today.ToLongDateString() + " " + DateTime.Today.TimeOfDay.ToString());
                    doc.AddKeywords("Mr Salad, Invoice, Order," + clientOrderCode);
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

                    // client details
                    Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    doc.Add(p);

                    Paragraph client = new Paragraph(@"CLIENT");
                    client.Alignment = Element.ALIGN_CENTER;
                    doc.Add(client);

                    doc.Add(p);

                    doc.Add(new Chunk("\n"));

                    client = new Paragraph(clientFN + " " + clientLN);
                    client.Alignment = Element.ALIGN_LEFT;
                    doc.Add(client);

                    client = new Paragraph(@"Cell Number 1: " + clientCN1);
                    client.Alignment = Element.ALIGN_LEFT;
                    doc.Add(client);

                    client = new Paragraph(@"Cell Number 2: " + clientCN2);
                    client.Alignment = Element.ALIGN_LEFT;
                    doc.Add(client);
                    
                    client = new Paragraph(@"Email Address: " + clientEA);
                    client.Alignment = Element.ALIGN_LEFT;
                    doc.Add(client);
                    doc.Add(new Chunk("\n"));

                    // invoice details
                    doc.Add(p);

                    Paragraph invoice = new Paragraph(@"INVOICE " + clientOrderCode);
                    invoice.Alignment = Element.ALIGN_CENTER;
                    doc.Add(invoice);

                    doc.Add(p);

                    doc.Add(new Chunk("\n"));

                    float[] widths = new float[] { 2f, 6f, 3f, 3f };
                    PdfPTable table = new PdfPTable(widths);
                    
                    PdfPCell cell;
                    double price;
                    double count = 0;
                    double priceTotal = 0;

                    cell = new PdfPCell(new Phrase("Quantity"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Product"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Unit Price"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Total Price"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);                    
                    
                    for (int i = 0; i < productlist.Count; i++)
                    {
                        count += Convert.ToUInt32(productlist[i][0]);
                        cell = new PdfPCell(new Phrase(productlist[i][0]));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);

                        cell = new PdfPCell(new Phrase(productlist[i][1]));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);

                        cell = new PdfPCell(new Phrase("R " + productlist[i][2]));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);

                        price = Convert.ToDouble(productlist[i][2]) * Convert.ToDouble(productlist[i][0]);
                        priceTotal += price;
                        cell = new PdfPCell(new Phrase("R " + Convert.ToString(price)));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    cell = new PdfPCell(new Phrase(Convert.ToString(count)));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(System.Drawing.Color.YellowGreen);
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("VAT"));
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

                    // employee details
                    doc.Add(p);

                    Paragraph emp = new Paragraph(@"EMPLOYEES");
                    emp.Alignment = Element.ALIGN_CENTER;
                    doc.Add(emp);

                    doc.Add(p);

                    doc.Add(new Chunk("\n"));

                    emp = new Paragraph(@"Order was created by " + cEmpName + " on " + cEmpDate);
                    emp.Alignment = Element.ALIGN_MIDDLE;
                    doc.Add(emp);

                    emp = new Paragraph(@"Payment was processed by " + pEmpName + " on " + pEmpDate);
                    emp.Alignment = Element.ALIGN_MIDDLE;
                    doc.Add(emp);

                    // Closing the Document
                    doc.Close();
                }

                return appRootDir + "\\Invoice - Order " + clientOrderCode + ".pdf";

                // Catching iTextSharp.text.DocumentException if any
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
