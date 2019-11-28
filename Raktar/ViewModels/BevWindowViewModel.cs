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
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        private string _count;

        public string Count
        {
            get { return _count; }
            set {
                _count = value;
                NotifyOfPropertyChange(() => Count);
            }
        }
        private string _unit;

        public string Unit
        {
            get { return _unit; }
            set {
                _unit = value;
                NotifyOfPropertyChange(() => Unit);
            }
        }

        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }


        private Partner _partner;

        public Partner Partner
        {
            get { return _partner; }
            set { _partner = value; }
        }
        private string _szamlaszam;

        public string Szamlaszam
        {
            get { return _szamlaszam; }
            set { _szamlaszam = value; }
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
        public void Close()
        {
            
            TryClose(false);
        }

        public void CikkHasBeenChoosen(Munkaruha munkaruha)
        {

        }
        public void AddCikkToGrid()
        {
            //string temp = this.Price.Remove(this.Price.Length - 3, 3).Replace(" ", string.Empty);
            //temp = Regex.Replace(temp, @"\s", "");
            int Price = int.Parse(this.Price);
            if (Count == null || Count == string.Empty || int.Parse(Count) < 1) {
                MessageBox.Show("Hibás mennyiség!");
                return;
            }
            if (this.Price == null || this.Price == string.Empty || Price < 1) {
                MessageBox.Show("Hibás egységár!");
                return;
            }
            
            if (Partner == null) {
                MessageBox.Show("Nincs partner kiválasztva !");
                return;
            } 
            var ruha = new Munkaruha() {Cikkszam = Number, Mennyiseg = int.Parse(Count), Id = this.Id, Mertekegyseg = Unit, Cikknev = Name, Egysegar = Price, Partner = Partner.Name, PartnerId = Partner.Id, Szamlaszam = this.Szamlaszam };
            Ruhak.Add(ruha);
            Number = string.Empty; Count = string.Empty; Unit = string.Empty; Name = string.Empty; this.Price = string.Empty;
            NotifyOfPropertyChange(() => Ruhak);
            NotifyOfPropertyChange(() => Sum);
        }

        public void SetCikk(Munkaruha ruha)
        {
            Name = ruha.Cikknev;
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
