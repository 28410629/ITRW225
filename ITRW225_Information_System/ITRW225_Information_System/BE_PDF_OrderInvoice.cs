using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITRW225_Information_System
{
    public class BE_PDF_OrderInvoice
    {
        public string createPDF(string clientFN, string clientLN, string clientID, string clientCN1, string clientCN2, string clientEA,
                                string clientHN, string clientSN, string clientS, string clientC, string clientPC, string cEmpName,
                                string cEmpDate, string pEmpName, string pEmpDate, string productsAmount, string vat, string total, List<List<string>> productlist)
        {
            try
            {
                // variables for invoice
                string clientOrderCode = "dcs";

                // define page Size
                Rectangle rec = new Rectangle(PageSize.A4);

                // Setting Background Color of PDF Document
                rec.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);

                string appRootDir = Properties.Settings.Default.InvoiceSavePath;

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
                    png.ScaleToFit(250f, 250f);
                    png.Alignment = Image.ALIGN_MIDDLE;
                    png.IndentationLeft = 9f;
                    png.SpacingAfter = 9f;
                    doc.Add(png);

                    // mr salad details
                    Paragraph salad = new Paragraph(@"Mr Salad Details:");
                    salad.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(salad);

                    salad = new Paragraph(@"Cell Number2: ");
                    salad.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(salad);

                    salad = new Paragraph(@"Cell Number3: ");
                    salad.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(salad);

                    salad = new Paragraph(@"");
                    salad.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(salad);
                    doc.Add(new Chunk("\n"));

                    // client details
                    Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    doc.Add(p);

                    Paragraph client = new Paragraph(@"Client Details:");
                    client.Alignment = Element.ALIGN_LEFT;
                    doc.Add(client);

                    client = new Paragraph(@"Cell Number2: ");
                    client.Alignment = Element.ALIGN_LEFT;
                    doc.Add(client);

                    client = new Paragraph(@"Cell Number3: ");
                    client.Alignment = Element.ALIGN_LEFT;
                    doc.Add(client);
                    
                    client = new Paragraph(@"");
                    client.Alignment = Element.ALIGN_LEFT;
                    doc.Add(client);
                    doc.Add(new Chunk("\n"));

                    // invoice details
                    PdfPTable table = new PdfPTable(4);

                    table.AddCell("Quantity");
                    table.AddCell("Product");
                    table.AddCell("Unit Price (R)");
                    table.AddCell("Total Price (R)");

                    double price;
                    for (int i = 0; i < productlist.Count; i++)
                    {
                        table.AddCell(productlist[i][0]);
                        table.AddCell(productlist[i][1]);
                        table.AddCell(productlist[i][2]);
                        price = Convert.ToDouble(productlist[i][2]) * Convert.ToDouble(productlist[i][0]);
                        table.AddCell(Convert.ToString(price));
                    }
                        doc.Add(table);

                    // employee details
                    doc.Add(p);


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
