using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Caliburn.Micro;
using Raktar.Models;

namespace Raktar.ViewModels
{
    class PrintingWindowViewModel : Screen
    {
        public PrintingWindowViewModel(Dolgozo dolgozo)
        {
            this.Dolgozo = dolgozo;

        }

        public PrintingWindowViewModel(Dolgozo dolgozo, BindableCollection<Munkaruha> Ruhak) : this(dolgozo)
        {
            this.Ruhak = Ruhak;
        }
        public string Keszult {
            get {
                return string.Format("Szarvas, {0}",DateTime.Today.ToShortDateString());
            }
        }

        public string Sum
        {
            get
            {
                int sum = 0;
                foreach (var item in Ruhak)
                {
                    sum += item.Osszesen;
                }
                return sum.ToString("C0");
            }

        }
        private Dolgozo dolgozo;

        public Dolgozo Dolgozo
        {
            get { return dolgozo; }
            set { dolgozo = value; }
        }

        private FlowDocument _document;
        private BindableCollection<Munkaruha> ruhak;
        public BindableCollection<Munkaruha> Ruhak {
            get {
                return ruhak;
            }
            set {
                ruhak = value;
                NotifyOfPropertyChange(()=> Ruhak);
            }
        }
        public FlowDocument Document
        {
            get { return _document; }
            set {
                _document = value;
                NotifyOfPropertyChange(()=>Document);
            }
        }
        public void Print(FlowDocument Document) {
            PrintDialog pd = new PrintDialog();
            pd.UserPageRangeEnabled = true;
            if (pd.ShowDialog() != true) return;
            pd.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4); ;
            Document.PageWidth = PrintLayout.A4.Size.Width;
            Document.PageHeight = PrintLayout.A4.Size.Height;
            Document.PagePadding = PrintLayout.A4.Margin;
            Document.ColumnWidth = PrintLayout.A4.ColumnWidth;
            IDocumentPaginatorSource idocument = Document as IDocumentPaginatorSource;
            
            pd.PrintDocument(idocument.DocumentPaginator, "Printing Flow Document...");
            TryClose(true);
        }

    }
}
