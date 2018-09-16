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
                try
                {
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
                        // Setting Document properties e.g.
                        // 1. Title
                        // 2. Subject
                        // 3. Keywords
                        // 4. Creator
                        // 5. Author
                        // 6. Header
                        doc.AddTitle("Invoice - Order " + clientOrderCode);
                        doc.AddSubject("Created On " + DateTime.Today.ToLongDateString() + " " + DateTime.Today.TimeOfDay.ToString());
                        doc.AddKeywords("Mr Salad, Invoice, Order," + clientOrderCode);
                        doc.AddCreator("Mr Salad");
                        doc.AddAuthor("Mr Salad");
                        doc.AddHeader("Nothing", "No Header");

                        // Step 4: Openning the Document
                        doc.Open();
                        Image png = Image.GetInstance(Properties.Resources.logo_465x320__1_, ImageFormat.Png);

                        // mr salad details
                        Paragraph paragraph = new Paragraph(@"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse blandit blandit turpis. Nam in lectus ut dolor consectetuer bibendum. Morbi neque ipsum, laoreet id; dignissim et, viverra id, mauris. Nulla mauris elit, consectetuer sit amet, accumsan eget, congue ac, libero. Vivamus suscipit. Nunc dignissim consectetuer lectus. Fusce elit nisi; commodo non, facilisis quis, hendrerit eu, dolor? Suspendisse eleifend nisi ut magna. Phasellus id lectus! Vivamus laoreet enim et dolor. Integer arcu mauris, ultricies vel, porta quis, venenatis at, libero. Donec nibh est, adipiscing et, ullamcorper vitae, placerat at, diam. Integer ac turpis vel ligula rutrum auctor! Morbi egestas erat sit amet diam. Ut ut ipsum? Aliquam non sem. Nulla risus eros, mollis quis, blandit ut; luctus eget, urna. Vestibulum vestibulum dapibus erat. Proin egestas leo a metus?");

                        paragraph.Alignment = Element.ALIGN_RIGHT;

                        png.ScaleToFit(250f, 250f);

                        png.Alignment = Image.ALIGN_MIDDLE;

                        png.IndentationLeft = 9f;

                        png.SpacingAfter = 9f;

                        doc.Add(png);

                        doc.Add(paragraph);

                        // employee details
                        /*Paragraph cName = new Paragraph("Client Name: " + clientFN + " " + clientLN);
                        doc.Add(cName);
                        Paragraph cName = new Paragraph("Client Name: " + clientFN + " " + clientLN);
                        doc.Add(cName);
                        Paragraph cName = new Paragraph("Client Name: " + clientFN + " " + clientLN);
                        doc.Add(cName);
                        Paragraph cName = new Paragraph("Client Name: " + clientFN + " " + clientLN);
                        doc.Add(cName);*/


                        // Step 6: Closing the Document
                        doc.Close();
                    }
                    return appRootDir + "\\Invoice - Order " + clientOrderCode + ".pdf";
                }
                // Catching iTextSharp.text.DocumentException if any
                catch (DocumentException de)
                {
                    throw de;
                }
                // Catching System.IO.IOException if any
                catch (IOException ioe)
                {
                    throw ioe;
                }
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
