using System;
using System.IO;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;



namespace Raktar
{
    class PrintHelper
    {
        public static void PrintXPS(FlowDocument document)
        {


            // STEP 2: Convert this WPF Visual to an XPS Document
            if (File.Exists("printPreview.xps")) File.Delete("printPreview.xps");
            var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;

            var xpsDocument = new XpsDocument("printPreview.xps", FileAccess.ReadWrite);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            writer.Write(paginator);
            PrintDialog pDialog = new PrintDialog();
            LocalPrintServer ps = new LocalPrintServer();
            PrintQueue pq = ps.DefaultPrintQueue;
            PrintTicket pt = pq.UserPrintTicket;
            pt.PageOrientation = PageOrientation.Portrait;
            PageMediaSize pageMediaSize = new PageMediaSize(document.PageWidth, document.PageHeight);
            pt.PageMediaSize = pageMediaSize;
            // Display the dialog. This returns true if the user presses the Print button.
            Nullable<Boolean> print = pDialog.ShowDialog();
            if (print == true)
            {
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();

                pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
                xpsDocument.Close();
            }
            else {
                xpsDocument.Close();
            }

        }
        public static void GeneratePDF(FlowDocument document) { 
            
        }
        public static void FlowDocToDoc(FlowDocument document) {

            var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
            
            var xpsDocument = new XpsDocument("printPreview.xps", FileAccess.ReadWrite);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            writer.Write(paginator);
           

        }
    }
}
