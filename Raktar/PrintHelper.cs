using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                //Document = xpsDocument.GetFixedDocumentSequence();
                // Create the print dialog object and set options
                PrintDialog pDialog = new PrintDialog();
                pDialog.PageRangeSelection = PageRangeSelection.AllPages;
                pDialog.UserPageRangeEnabled = true;
                // Display the dialog. This returns true if the user presses the Print button.
                Nullable<Boolean> print = pDialog.ShowDialog();
            if (print == true)
            {
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
                xpsDocument.Close();
            }
 

        }

    }
}
