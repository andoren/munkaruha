using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Raktar.ViewModels
{
    class CikkekTorzsViewModel:Screen
    {
        public CikkekTorzsViewModel()
        {
             MunkaruhaDatabaseHelper cikkhelper = new MunkaruhaDatabaseHelper();
             Cikkek = cikkhelper.GetAllCikkek();
             SearchableRuha = new BindableCollection<Munkaruha>(Cikkek);
        }
        #region cikkek 
        private string _searchRuha = "Keresés...";

        public string SearchCikk
        {
            get { return _searchRuha; }
            set
            {
                _searchRuha = value;
                NotifyOfPropertyChange(() => SearchCikk);
            }
        }
        private Munkaruha _selectedmunkaruha;

        public Munkaruha SelectedMunkaruha
        {
            get { return _selectedmunkaruha; }
            set
            {
                _selectedmunkaruha = value;

            }
        }
        public void DoubleClickMunkaruhaList()
        {
            if (SelectedMunkaruha != null)
            {
                var windowmanager = new WindowManager();
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
            set
            {
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
        public void AddCikk()
        {
            var windowmanager = new WindowManager();
            MunkaruhaDatabaseHelper cshelper = new MunkaruhaDatabaseHelper();
            BindableCollection<Csoport> PartnerCsoportok = cshelper.GetCikkCsoportok();
            var window = new AddAndModifyCikkViewModel(PartnerCsoportok);
            var result = windowmanager.ShowDialog(window, null, null);
            if (result == true)
            {
                MunkaruhaDatabaseHelper cikkhelper = new MunkaruhaDatabaseHelper();
                Cikkek = cikkhelper.GetAllCikkek();
                SearchableRuha = new BindableCollection<Munkaruha>(Cikkek);
                MessageBox.Show("Cikk hozzáadva");
            }
        }
        public void RemoveCikk()
        {
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
        public void LostFocus()
        {
            SearchCikk = "Keresés...";
        }
        public void OnFocus()
        {
            SearchCikk = "";
        }
    }
}
