using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Raktar.ViewModels
{
    class PrintMegvaltasViewModel:Screen
    {
        public PrintMegvaltasViewModel(Dolgozo Dolgozo, BindableCollection<Munkaruha> Ruhak)
        {
            this.Dolgozo = Dolgozo;
            this.Ruhak = Ruhak;
        }
        private Dolgozo _dolgozo;

        public Dolgozo Dolgozo
        {
            get { return _dolgozo; }
            set { _dolgozo = value;
                NotifyOfPropertyChange(()=>Dolgozo);
            }
        }
        private BindableCollection<Munkaruha> _ruhak;

        public BindableCollection<Munkaruha> Ruhak
        {
            get { return _ruhak; }
            set { _ruhak = value;
                NotifyOfPropertyChange(()=>Ruhak);
             }
        }
        public string Keszult
        {
            get
            {
                return string.Format("Szarvas, {0}", DateTime.Today.ToShortDateString());
            }
        }

        public string Sum
        {
            get
            {

                return ((int)MegvaltandoOsszeg()).ToString("C0");
            }

        }
        private decimal MegvaltandoOsszeg() {
            decimal osszeg = 0;
            foreach (var ruha in Ruhak)
            {
                if (ruha.Cikkcsoport.ToLower() == "eszközök" || ruha.Cikkcsoport.ToLower() == "védőruha") {
                    osszeg += ruha.Osszesen;
                }
                else if (ruha.Cikkcsoport.ToLower() == "munkaruha") {
                    decimal onemounthprice = (decimal)ruha.Osszesen / 12;
                    int napok = DateTime.Now.Subtract(DateTime.Parse(ruha.KiadDatum)).Days;
                    double kerekit = Math.Round(napok / (365.25d / 12));
                    int diffrent = 12- (int)kerekit;
                    osszeg += onemounthprice * diffrent;
                } else if (ruha.Cikkcsoport.ToLower() == "védőfelszerelés") {
                    decimal onemounthprice = (decimal)ruha.Osszesen / 24;
                    int napok = DateTime.Now.Subtract(DateTime.Parse(ruha.KiadDatum)).Days;
                    double kerekit = Math.Round(napok / (365.25d / 12));
                    int diffrent = 24 - (int)kerekit;
                    osszeg += onemounthprice * diffrent;
                }
            }
            return osszeg;
        }
        private FlowDocument _document;
        public FlowDocument Document
        {
            get { return _document; }
            set
            {
                _document = value;
                NotifyOfPropertyChange(() => Document);
            }
        }
        public void Print(FlowDocument Document)
        {
            Document.PageWidth = PrintLayout.A4.Size.Width;
            Document.PageHeight = PrintLayout.A4.Size.Height;
            Document.PagePadding = PrintLayout.A4.Margin;
            Document.ColumnWidth = PrintLayout.A4.ColumnWidth;
            PrintHelper.PrintXPS(Document);
            var result = MessageBox.Show("Szeretné kivezetni a dolgozóról a cikkekekt? (Akkor ajánlott ha már kifizette)","Törlés",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) {
                MunkaruhaDatabaseHelper helper = new MunkaruhaDatabaseHelper();
                if(helper.MegvaltRuhakByDolgozoID(Dolgozo.Id))
                MessageBox.Show("Sikeres kivezetés!");
                TryClose(true);
            }
            TryClose(false);
            
        }

    }
}
