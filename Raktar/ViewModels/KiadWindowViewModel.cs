using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;

namespace Raktar.ViewModels
{
    class KiadWindowViewModel:Screen,ISetCikk,IValasztEmber
    {
        public KiadWindowViewModel()
        {
            Ruhak = new BindableCollection<Munkaruha>();
            GetPartners();
        }
        #region Partnerek
        private void GetPartners()
        {
            BindableCollection<Partner> temp = new BindableCollection<Partner>();
            PartnerHelper helper = new PartnerHelper();
            foreach (Partner partner in helper.GetPartners())
            {
                temp.Add(partner);
            }
            Partnerek = temp;
        }
        private BindableCollection<Partner> _partnerek;

        public BindableCollection<Partner> Partnerek
        {
            get { return _partnerek; }
            set
            {
                _partnerek = value;
                NotifyOfPropertyChange(() => Partnerek);
            }
        }

        #endregion
        #region Dolgozó
        private Dolgozo _dolgozo;

        public Dolgozo Dolgozo
        {
            get { return _dolgozo; }
            set {
                if (value != null) Valasztott = true;
                else Valasztott = false;
                _dolgozo = value;
                NotifyOfPropertyChange(() => WorkerName);
                NotifyOfPropertyChange(() => WorkerGroup);
            }
        }
        public string WorkerName { get {
                if (Dolgozo != null)
                    return Dolgozo.Name;
                else return "";
            } }
        public string WorkerGroup { get {
                if (Dolgozo != null)
                    return Dolgozo.GroupName;
                else
                    return "";
            } }
        public void KivalasztDolgozo() {
            var window = new WindowManager();
            var kivwindow = new DolgozoKivalasztViewModel(this);
            var result = window.ShowDialog(kivwindow, null, null);
            if (result.HasValue && result.Value)
            {

                
            }
        }
        /// <summary>
        /// Lett e választva dolgozó ha nem null a dolgozó beállításakor az érték akkor igaz ha null akkor false. És a groupbox lezárodik
        /// </summary>
        private bool _valasztott;

        public bool Valasztott
        {
            get
            {
                return _valasztott;
            }
            set
            {
                _valasztott = value;
                NotifyOfPropertyChange(() => Valasztott);
            }
        }
        #endregion
        #region Cikkek
        private BindableCollection<Munkaruha> ruhak;

        public BindableCollection<Munkaruha> Ruhak
        {
            get { return ruhak; }
            set
            {
                ruhak = value;
                NotifyOfPropertyChange(() => Ruhak);

            }
        }

        #region Variables for new munkaruha
        private int _max;

        public int Max
        {
            get { return _max; }
            set
            {
                _max = value;
                NotifyOfPropertyChange(()=>Max);
            }
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        private string _number;

        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                NotifyOfPropertyChange(() => Number);
            }
        }

        private string _cikkname;

        public string CikkName
        {
            get { return _cikkname; }
            set
            {
                _cikkname = value;
                NotifyOfPropertyChange(() => CikkName);
            }
        }
        private string _count;

        public string Count
        {
            get { return _count; }
            set
            {
                _count = value;
                NotifyOfPropertyChange(() => Count);
            }
        }
        private string _unit;

        public string Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                NotifyOfPropertyChange(() => Unit);
            }
        }

        private string _price;

        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }

        private string _partner;

        public string Partner
        {
            get { return _partner; }
            set { _partner = value;
                NotifyOfPropertyChange(() => Partner);
            }
        }

        #endregion

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
        public void AddCikk()
        {
            var cikkwindow = new CikkekViewModel(this);
            var manager = new WindowManager();
            var result = manager.ShowDialog(cikkwindow, null, null);

        }
        public void AddCikkToGrid()
        {
            if (Count == null || Count == string.Empty || int.Parse(Count) < 1)
            {
                MessageBox.Show("Hibás mennyiség!");
                return;
            }
            if (Max - int.Parse(Count) < 0)
            {
                MessageBox.Show("Több mennyiséget nem adhatsz ki mint amennyi a raktárban van !");
                return;
            }
            var ruha = new Munkaruha() { Cikkszam = Number, Mennyiseg = int.Parse(Count), Id = this.Id, Mertekegyseg = Unit, Cikknev = CikkName, Egysegar = int.Parse(Price), Partner = this.Partner };
            Ruhak.Add(ruha);
            Number = string.Empty; Count = string.Empty; Unit = string.Empty; CikkName = string.Empty; Price = string.Empty;
            NotifyOfPropertyChange(() => Ruhak);
            NotifyOfPropertyChange(() => Sum);
            Max = 0;
            Partner = "";

        }
        public void SetCikk(Munkaruha ruha)
        {
            int vanilyenruha = Ruhak.Count == 0?0:Ruhak.Where(s=>s.Id == ruha.Id).ToList().Sum(item => item.Mennyiseg);
            if (vanilyenruha != 0)
            {
                CikkName = ruha.Cikknev;
                Number = ruha.Cikkszam;
                Unit = ruha.Mertekegyseg;
                Id = ruha.Id;
                Max = ruha.Mennyiseg - vanilyenruha;
                Price = ruha.Egysegar.ToString();
                Partner = ruha.Partner;
            }
            else {
                CikkName = ruha.Cikknev;
                Number = ruha.Cikkszam;
                Unit = ruha.Mertekegyseg;
                Id = ruha.Id;
                Max = ruha.Mennyiseg;
                Price = ruha.Egysegar.ToString();
                Partner = ruha.Partner;
            }

        }
        #endregion

        public void Save() {
            MunkaruhaDatabaseHelper helper = new MunkaruhaDatabaseHelper();
            helper.KiadasMunkaruha(Dolgozo.Id,ruhak.ToArray<Munkaruha>());
            TryClose(true);
        }
        public void CloseWindow() {
            TryClose(false);
        }
        
    }
}
