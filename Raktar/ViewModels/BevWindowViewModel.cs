using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;

namespace Raktar.ViewModels
{
    class BevWindowViewModel : Screen,ISetCikk
    {
        public BevWindowViewModel():base()
        {
            Ruhak = new BindableCollection<Munkaruha>();
            GetPartners();
        }
        private void GetPartners() {
            BindableCollection<Partner> temp = new BindableCollection<Partner>();
            PartnerHelper helper = new PartnerHelper();
            foreach (Partner partner in helper.GetPartners() )
            {
                temp.Add(partner);
            }
            Partnerek = temp;
        }
        private BindableCollection<Partner> _partnerek;

        public BindableCollection<Partner> Partnerek
        {
            get { return _partnerek; }
            set { _partnerek = value;
                NotifyOfPropertyChange(()=>Partnerek);
            }
        }


        private BindableCollection<Munkaruha> ruhak;

        public BindableCollection<Munkaruha> Ruhak
        {
            get { return ruhak; }
            set { ruhak = value;

                NotifyOfPropertyChange(() => Ruhak);
                
            }
        }
        private bool _szamlaSzamIsEnabled =true;

        public bool SzamlaSzamIsEnabled
        {
            get { return _szamlaSzamIsEnabled; }
            set { _szamlaSzamIsEnabled = value;
                NotifyOfPropertyChange(()=>SzamlaSzamIsEnabled);
            }
        }
        private bool _partnerIsEnabled = true;

        public bool PartnerIsEnabled
        {
            get { return _partnerIsEnabled; }
            set
            {
                _partnerIsEnabled = value;
                NotifyOfPropertyChange(() => PartnerIsEnabled);
            }
        }
        #region Variables for new munkaruha
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        private string _number;

        public string Number
        {
            get { return _number; }
            set {
                _number = value;
                NotifyOfPropertyChange(() => Number);
                NotifyOfPropertyChange(() => CanAddCikkToGrid);
            }
        }

        private string _name;

        public string Nev
        {
            get { return _name; }
            set {
                _name = value;
                NotifyOfPropertyChange(() => Nev);
                NotifyOfPropertyChange(() => CanAddCikkToGrid);
            }
        }
        private string _count;

        public string Count
        {
            get { return _count; }
            set {
                _count = value;
                NotifyOfPropertyChange(() => Count);
                NotifyOfPropertyChange(() => CanAddCikkToGrid);
            }
        }
        private string _unit;

        public string Unit
        {
            get { return _unit; }
            set {
                _unit = value;
                NotifyOfPropertyChange(() => Unit);
                NotifyOfPropertyChange(() => CanAddCikkToGrid);
            }
        }

        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value;
                NotifyOfPropertyChange(() => Price);
                NotifyOfPropertyChange(() => CanAddCikkToGrid);
            }
        }


        private Partner _partner;

        public Partner Partner
        {
            get { return _partner; }
            set { _partner = value;
                NotifyOfPropertyChange(() => CanAddCikkToGrid);
            }
        }
        private string _szamlaszam;

        public string Szamlaszam
        {
            get { return _szamlaszam; }
            set {
                _szamlaszam = value;
                NotifyOfPropertyChange(() => CanAddCikkToGrid);
            }
        }

        #endregion

        public string Sum
        {
            get {
                int sum = 0;
                foreach (var item in Ruhak)
                {
                    sum += item.Osszesen;
                }
                return sum.ToString("C0");
            }

        }

        public void Save()
        {

            MunkaruhaDatabaseHelper helper = new MunkaruhaDatabaseHelper();
            try
            {
                if (helper.AddMunkaruhaToRaktar(Ruhak.ToArray<Munkaruha>()))
                {
                    MessageBox.Show("Sikeres hozzáadás");
                }
                else
                {
                    if (Ruhak.Count == 0)
                    {
                        MessageBox.Show("Nincs cikk hozzáadva a táblázathoz !");
                        return;
                    }
                    else {
                        MessageBox.Show("Hiba");
                    }
                   
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            TryClose(true);
        }


        public void AddCikk()
        {
            var cikkwindow = new CikkekViewModel(this);
            var manager = new WindowManager();
            var result = manager.ShowDialog(cikkwindow, null, null);

        }
        public void Exit()
        {
            
            TryClose(false);
        }

        public void AddCikkToGrid()
        {
            if (!CheckAllData()) {
                return;
            } 
            int Price = int.Parse(this.Price);
            int Count = int.Parse(this.Count); 
            var ruha = new Munkaruha() {Cikkszam = Number, Mennyiseg = Count, Id = this.Id, Mertekegyseg = Unit, Cikknev = Nev, Egysegar = Price, Partner = Partner.Name, PartnerId = Partner.Id, Szamlaszam = this.Szamlaszam };
            Ruhak.Add(ruha);
            Number = string.Empty; this.Count = string.Empty; Unit = string.Empty; Nev = string.Empty; this.Price = string.Empty;
            NotifyOfPropertyChange(() => Ruhak);
            NotifyOfPropertyChange(() => Sum);
            SzamlaSzamIsEnabled = false;
            PartnerIsEnabled = false;
        }

        public bool CanAddCikkToGrid
        {
            get {             
                return CheckAllData();
            }
           
        }

        private bool CheckAllData() {
            return CheckCikkszam() && CheckCount() && CheckPrice()  && CheckPartner() && CheckSzamlaSzam();
        }
        private bool CheckPrice() {
            if (string.IsNullOrEmpty(this.Price) || string.IsNullOrWhiteSpace(this.Price))
            {
               
                return false;
            }
            int Price;
            try
            {
                Price = int.Parse(this.Price);
            }
            catch (FormatException)
            {
              
                return false;
            }
            catch (Exception)
            {
             
                return false;
            }

            if (Price < 1)
            {
              
                return false;
            }

            return true;
        }
        private bool CheckCount() {
            if (string.IsNullOrEmpty(this.Count) || string.IsNullOrWhiteSpace(this.Count))
            {
              
                return false;
            }
            int Count;
            try
            {
                Count = int.Parse(this.Count);
            }
            catch (FormatException)
            {
               
                return false;
            }
            catch (Exception)
            {
            
                return false;
            }

            if (Count < 1)
            {
               
                return false ;
            }
            return true;
        }
        private bool CheckSzamlaSzam() {
            bool result;
            result = !string.IsNullOrEmpty(Szamlaszam) && !string.IsNullOrWhiteSpace(Szamlaszam); ;
         
            return result;
        }
        private bool CheckCikkszam()
        {
            bool result;
            result = !string.IsNullOrEmpty(Number) && !string.IsNullOrWhiteSpace(Number); ;
       
            return result;
          
        }
        private bool CheckPartner() {
            bool result;
            result = Partner != null;
        
            return result;

        }
        public void SetCikk(Munkaruha ruha)
        {
            Nev = ruha.Cikknev;
            Number = ruha.Cikkszam;
            Unit = ruha.Mertekegyseg;
            Id = ruha.Id;
        }
        public void CellEdited() {
            BindableCollection<Munkaruha> temp = new BindableCollection<Munkaruha>(Ruhak);
            Ruhak = new BindableCollection<Munkaruha>(temp);
            NotifyOfPropertyChange(() => Sum);
        }
        public void PriceChanged() {
            if (string.IsNullOrWhiteSpace(Price)) return;
            double price;
            if (Double.TryParse(Price.Split(' ')[0], out price))
            {
                Price = price.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("Hu-hu"));
            }
            else {
                MessageBox.Show("Az egységár csak szám lehet!");
                Price = "";
            }
        }
    }
}
