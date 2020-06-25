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
            
            PartnerHelper partnerHelper = new PartnerHelper();
            Partnerek = partnerHelper.GetPartners();

            Ruhak = new BindableCollection<Munkaruha>();
            if (Partnerek.Count > 0) {
                SelectedPartner = Partnerek[0];
               
            }
            

        }
        MunkaruhaDatabaseHelper helper = new MunkaruhaDatabaseHelper();
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
        private Partner _selectedPartner ;

        public Partner SelectedPartner 
        {
            get { return _selectedPartner; }
            set { _selectedPartner = value;
                NotifyOfPropertyChange(()=>SelectedPartner);
                NotifyOfPropertyChange(()=> Bevetelezesek);
            }
        }
        private BindableCollection<Partner> _partnerek = new BindableCollection<Partner>();

        public BindableCollection<Partner> Partnerek
        {
            get { return _partnerek; }
            set { 
                _partnerek = value;
                NotifyOfPropertyChange(()=>Partnerek);
            }   
        }

        public string Sum
        {
            get { return FullPrice.ToString("C0"); }


        }



        public BindableCollection<Bevetel> Bevetelezesek
        {
            get {
                if (Partnerek.Count > 0)
                    return helper.GetDistinctBevetByPartner(SelectedPartner);
                else return new BindableCollection<Bevetel>();
            }
     
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


    }
}
