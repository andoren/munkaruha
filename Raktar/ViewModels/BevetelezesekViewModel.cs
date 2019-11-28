using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;

namespace Raktar.ViewModels
{
    class BevetelezesekViewModel:Screen
    {

        public BevetelezesekViewModel()
        {
            MunkaruhaDatabaseHelper helper = new MunkaruhaDatabaseHelper();
            Bevetelezesek = helper.GetDistinctBevet();
            Ruhak = new BindableCollection<Munkaruha>();
        }
        public int FullPrice
        {
            get {
                int price = 0;
                foreach (var ruha in Ruhak)
                {
                    price += ruha.Egysegar * ruha.Mennyiseg;
                }
                return price;
            }

        }


        public string Sum
        {
            get { return FullPrice.ToString("C0"); }


        }


        private BindableCollection<Bevetel> _bevetelezesek;

        public BindableCollection<Bevetel> Bevetelezesek
        {
            get { return _bevetelezesek; }
            set { _bevetelezesek = value; }
        }

        private Bevetel _selectedbevetel;

        public Bevetel Selectedbevetel
        {
            get { return _selectedbevetel; }
            set {
                
                if (value != null) GetRuhakByBevetId(value);
                _selectedbevetel = value;
                
            }
        }

        private void GetRuhakByBevetId(Bevetel bevet)
        {
            MunkaruhaDatabaseHelper helper = new MunkaruhaDatabaseHelper();
            Ruhak = helper.GetRuhaByBevetId(bevet.BevetId);
        }

        private BindableCollection<Munkaruha> _ruhak;

        public BindableCollection<Munkaruha> Ruhak
        {
            get { return _ruhak; }
            set {

                _ruhak = value;
                NotifyOfPropertyChange(()=>Ruhak);
                NotifyOfPropertyChange(() => Sum);
            }
        }
        public void CloseWindow() {
            TryClose(true);
        }

    }
}
