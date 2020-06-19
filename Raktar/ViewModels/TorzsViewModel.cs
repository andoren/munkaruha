using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;
namespace Raktar.ViewModels
{
    class TorzsViewModel:Screen
    {
        public TorzsViewModel()
        {
            GetDataFromDatabase();
        }
        #region dolgozok
        private string _search = "Keresés...";

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                NotifyOfPropertyChange(() => Search);
            }
        }


        private Dolgozo _selecteddolgozo;

        public Dolgozo SelectedDolgozo
        {
            get { return _selecteddolgozo; }
            set
            {
                _selecteddolgozo = value;

            }
        }
        private BindableCollection<Dolgozo> _searchableDolgozo;

        public BindableCollection<Dolgozo> SearchableDolgozo
        {
            get { return _searchableDolgozo; }
            set
            {
                _searchableDolgozo = value;
                NotifyOfPropertyChange(() => SearchableDolgozo);
            }
        }

        private BindableCollection<Dolgozo> _dolgozok;
        public BindableCollection<Dolgozo> Dolgozok
        {
            get
            {
                return _dolgozok;
            }
            set
            {
                _dolgozok = value;
                NotifyOfPropertyChange(() => Dolgozok);
            }
        }
        public void Searching(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;
            if (string.IsNullOrEmpty(Search) || Search == "Keresés..." )
            {
                SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
                return;
            }
            if (keyArgs != null)
            {
                SearchableDolgozo = new BindableCollection<Dolgozo>();
                foreach (Dolgozo item in Dolgozok.Where(p => p.NameWithGroupName.ToLower().Contains(Search.ToLower())).ToArray())
                {
                    SearchableDolgozo.Add(item);
                }

            }
        }
        public void DoubleClickDolgozoList()
        {
            if (SelectedDolgozo != null)
            {
                var window = new WindowManager();
                var dolgozowindow = new AddAndModifyDolgozoViewModel(SelectedDolgozo,true);
                var result = window.ShowDialog(dolgozowindow, null, null);
                if (result == true)
                {
                    DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
                    Dolgozok = dolgozohelper.GetDolgozok();
                    SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
                    MessageBox.Show("Dolgozó módosítva.");
                }
            }
        }
        public void AddWorker() {
            var window = new WindowManager();
            var dolgozowindow = new AddAndModifyDolgozoViewModel();
            var result = window.ShowDialog(dolgozowindow, null, null);
            if (result == true) {
                DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
                Dolgozok = dolgozohelper.GetDolgozok();
                SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
                MessageBox.Show("Dolgozó hozzáadva.");
            }
        }
        public void RemoveWorker() {
            if (SelectedDolgozo != null) {
                var result = MessageBox.Show(string.Format("Valóban törölni szeretné a következő dolgozót: {0} ?", SelectedDolgozo.Name), "Dolgozó törlése",MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) {
                    var dolgozohelper = new DolgozoDatabaseHelper();
                    if (dolgozohelper.DeleteDolgozo(SelectedDolgozo.Id))
                    {
                        Dolgozok = dolgozohelper.GetDolgozok();
                        SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
                        MessageBox.Show("Dolgozó törölve.");
                    }
                    else {
                        MessageBox.Show("Hiba a törlés közben!");
                    }

                }

            }

        }
        #endregion

        #region partnerek
        private string _searchPartner= "Keresés...";

        public string SearchPartner
        {
            get { return _searchPartner; }
            set {
                _searchPartner = value;
                NotifyOfPropertyChange(() => SearchPartner);
            }
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

        private BindableCollection<Partner> _searchablepartners;

        public BindableCollection<Partner> SearchablePartners
        {
            get { return _searchablepartners; }
            set { _searchablepartners = value;
                NotifyOfPropertyChange(() => SearchablePartners);

            }
        }
        private Partner _selectedpartner;

        public Partner SelectedPartner
        {
            get { return _selectedpartner; }
            set { _selectedpartner = value; }
        }
        public void DoubleClickPartnerList()
        {
            if (SelectedPartner != null)
                MessageBox.Show(SelectedPartner.Name);
        }

        public void SearchForPartners(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;
            if (string.IsNullOrEmpty(SearchPartner) || SearchPartner == "Keresés...")
            {
                SearchablePartners = new BindableCollection<Partner>(Partnerek);
              
                return;
            }
            if (keyArgs != null)
            {
                SearchablePartners = new BindableCollection<Partner>();
                foreach (Partner item in Partnerek.Where(p => p.Name.ToLower().Contains(SearchPartner.ToLower())).ToArray())
                {
                    SearchablePartners.Add(item);
                }

            }
        }

        public void RemovePartner() {
            if (SelectedPartner != null)
            {
                var result = MessageBox.Show(string.Format("Valóban törölni szeretné a következő partnert: {0} ?", SelectedPartner.Name), "Partner törlése", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var partnerhelper = new PartnerHelper();
                    if (partnerhelper.DeletePartner(SelectedPartner.Id))
                    {
                        Partnerek = partnerhelper.GetPartners();
                        SearchablePartners = new BindableCollection<Partner>(Partnerek);
                        MessageBox.Show("Partner törölve.");
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen törlés. Amíg van olyan cikk kiadva akinél ez a partner szerepel nem lehet törölni!");
                    }

                }

            }
        }
        public void AddPartner() {
            var windowmanager = new WindowManager();
            var window = new AddAndModifyPartnerViewModel(Partnerek);
            var result = windowmanager.ShowDialog(window, null, null);
            if (result == true)
            {
                PartnerHelper partnerhelper = new PartnerHelper();
                Partnerek = partnerhelper.GetPartners();
                SearchablePartners = new BindableCollection<Partner>(Partnerek);
                MessageBox.Show("Partner hozzáadva");
            }
        }
        #endregion

        #region cikkek 
        private string _searchRuha = "Keresés...";

        public string SearchCikk
        {
            get { return _searchRuha; }
            set {
                _searchRuha = value;
                NotifyOfPropertyChange(()=> SearchCikk);
            }
        }
        private Munkaruha _selectedmunkaruha;

        public Munkaruha SelectedMunkaruha
        {
            get { return _selectedmunkaruha; }
            set {
                _selectedmunkaruha = value;

            }
        }
        public void DoubleClickMunkaruhaList() {
            if (SelectedMunkaruha != null) {
                var windowmanager =  new WindowManager();
                var cshelper = new MunkaruhaDatabaseHelper();
                BindableCollection<Csoport> PartnerCsoportok = cshelper.GetCikkCsoportok();
                var window = new AddAndModifyCikkViewModel(PartnerCsoportok, SelectedMunkaruha);
                var result = windowmanager.ShowDialog(window, null, null);
                if (result == true)
                {
                    Cikkek = cshelper.GetAllCikkek();
                    SearchableRuha = new BindableCollection<Munkaruha>(Cikkek);
                    MessageBox.Show("Cikk módosítva");
                }

            }
        }
        private BindableCollection<Munkaruha> _cikkek;

        public BindableCollection<Munkaruha> Cikkek
        {
            get { return _cikkek; }
            set
            {
                _cikkek = value;
                NotifyOfPropertyChange(() => Cikkek);
            }
        }

        private BindableCollection<Munkaruha> _searchableruha;

        public BindableCollection<Munkaruha> SearchableRuha
        {
            get { return _searchableruha; }
            set {
                _searchableruha = value;
                NotifyOfPropertyChange(() => SearchableRuha);

            }
        }
        public void SearchingForRuha(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;
            if (string.IsNullOrEmpty(SearchCikk) || SearchCikk == "Keresés...")
            {
                SearchableRuha = new BindableCollection<Munkaruha>(Cikkek);
               
                return;
            }
            if (keyArgs != null)
            {
                SearchableRuha = new BindableCollection<Munkaruha>();
                foreach (Munkaruha item in Cikkek.Where(p => p.NameForCikk.ToLower().Contains(SearchCikk.ToLower())).ToArray())
                {
                    SearchableRuha.Add(item);
                }
                NotifyOfPropertyChange(() => SearchableRuha);
            }
        }
        public void AddCikk() {
            var windowmanager = new WindowManager();
            MunkaruhaDatabaseHelper cshelper = new MunkaruhaDatabaseHelper();
            BindableCollection<Csoport> PartnerCsoportok = cshelper.GetCikkCsoportok();
            var window = new AddAndModifyCikkViewModel(PartnerCsoportok);
            var result = windowmanager.ShowDialog(window,null,null);
            if (result == true) {
                MunkaruhaDatabaseHelper cikkhelper = new MunkaruhaDatabaseHelper();
                Cikkek = cikkhelper.GetAllCikkek();
                SearchableRuha = new BindableCollection<Munkaruha>(Cikkek);
                MessageBox.Show("Cikk hozzáadva");
            }
        }
        public void RemoveCikk() {
            if (SelectedMunkaruha != null)
            {
                var result = MessageBox.Show(string.Format("Valóban törölni szeretné a következő cikket: {0} ?", SelectedMunkaruha.NameForCikk), "Cikk törlése", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var munkaruhahelper = new MunkaruhaDatabaseHelper();
                    if (munkaruhahelper.DeleteRuha(SelectedMunkaruha.Id))
                    {
                        Cikkek = munkaruhahelper.GetAllCikkek();
                        SearchableRuha = new BindableCollection<Munkaruha>(Cikkek);
                        MessageBox.Show("Cikk törölve.");
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen törlés. Amíg van ilyen cikk a dolgozóknál nem lehet törölni!");
                    }

                }

            }
        }
        #endregion

        #region osztaly
        private string _searchGroup = "Keresés...";

        public string SearchGroup
        {
            get { return _searchGroup; }
            set {
               
                _searchGroup = value;
                NotifyOfPropertyChange(()=> SearchGroup);
            }
        }

        private BindableCollection<Osztaly> _csoportok;

        public BindableCollection<Osztaly> Csoportok 
        {
            get { return _csoportok; }
            set {
                _csoportok = value;
            }
        }
        private BindableCollection<Osztaly> _searchableCsoportok;

        public BindableCollection<Osztaly> SearchableCsoportok
        {
            get { return _searchableCsoportok; }
            set {
                _searchableCsoportok = value;
                NotifyOfPropertyChange(() => SearchableCsoportok);
            }
        }
        private Osztaly _selectedCsoport;

        public Osztaly SelectedCsoport
        {
            get { return _selectedCsoport; }
            set {
                _selectedCsoport = value;

            }
        }

        public void DoubleClickCsoportList() {
            if (SelectedCsoport != null) {
                var windowmanager = new WindowManager();
                var window = new AddAndModifyOsztalyViewModel(SelectedCsoport);
                var result = windowmanager.ShowDialog(window, null, null);
                if (result == true)
                {
                    DolgozoDatabaseHelper csoporthelper = new DolgozoDatabaseHelper();
                    Csoportok = csoporthelper.GetOsztalyok();
                    SearchableCsoportok = new BindableCollection<Osztaly>(Csoportok);
                    MessageBox.Show("Osztály módosítva");
                }
            }
        }
        private int _selectedCsoportIndex;

        public int SelectedCsoportIndex
        {
            get { return _selectedCsoportIndex; }
            set { _selectedCsoportIndex = value; }
        }

        public void SearchingForCsoport(ActionExecutionContext context) {
            var keyArgs = context.EventArgs as KeyEventArgs;
            if (string.IsNullOrEmpty(SearchGroup) || SearchGroup == "Keresés...")
            {
                SearchableCsoportok = new BindableCollection<Osztaly>(Csoportok);
                
                return;
            }
            if (keyArgs != null)
            {
                SearchableCsoportok = new BindableCollection<Osztaly>();
                foreach (Osztaly item in Csoportok.Where(p => p.Name.ToLower().Contains(SearchGroup.ToLower())).ToArray())
                {
                    SearchableCsoportok.Add(item);
                }
                
            }
        }

        public void AddGroup() {
            var windowmanager = new WindowManager();
            var window = new AddAndModifyOsztalyViewModel();
            var result = windowmanager.ShowDialog(window, null, null);
            if (result == true)
            {
                DolgozoDatabaseHelper csoporthelper = new DolgozoDatabaseHelper();
                Csoportok = csoporthelper.GetOsztalyok();
                SearchableCsoportok = new BindableCollection<Osztaly>(Csoportok);
                MessageBox.Show("Osztály hozzáadva");
            }
        }
        //public void RemoveGroup()
        //{
        //    if (SelectedCsoport != null)
        //    {
        //        var result = MessageBox.Show(string.Format("Valóban törölni szeretné a következő csoportot: {0} ?", SelectedCsoport.Name), "Csoport törlése", MessageBoxButton.YesNo);
        //        if (result == MessageBoxResult.Yes)
        //        {
        //            var cikkhelper = new MunkaruhaDatabaseHelper();
        //            if (cikkhelper.DeleteCikkCsoport(SelectedCsoport))
        //            {
        //                Csoportok = cikkhelper.GetCikkCsoportok();
        //                SearchableCsoportok = new BindableCollection<Csoport>(Csoportok);
        //                MessageBox.Show("Csoport törölve.");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Sikertelen törlés. Amíg van olyan cikk kiadva akinél ez a csoport szerepel nem lehet törölni!");
        //            }

        //        }

        //    }
        //}
        #endregion


        private void GetDataFromDatabase() {
            DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
            Dolgozok = dolgozohelper.GetDolgozok();
            SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
            PartnerHelper partnerhelper = new PartnerHelper();
            Partnerek = partnerhelper.GetPartners();
            SearchablePartners = new BindableCollection<Partner>(Partnerek);
            MunkaruhaDatabaseHelper cikkhelper = new MunkaruhaDatabaseHelper();
            Cikkek = cikkhelper.GetAllCikkek();
            SearchableRuha = new BindableCollection<Munkaruha>(Cikkek);
            Csoportok = dolgozohelper.GetOsztalyok();
            SearchableCsoportok = new BindableCollection<Osztaly>(Csoportok);

        }


        public void LostFocus() {
            SearchCikk = "Keresés...";
            Search = "Keresés...";
            SearchPartner = "Keresés...";
            SearchGroup = "Keresés...";
            SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
            SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
            SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
            SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);

        }
    }
}
