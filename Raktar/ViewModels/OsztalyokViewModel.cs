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
    class OsztalyokViewModel:Screen
    {
        public OsztalyokViewModel()
        {
            DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
            Csoportok = dolgozohelper.GetOsztalyok();
            SearchableCsoportok = new BindableCollection<Osztaly>(Csoportok);
        }
        #region osztaly
        private string _searchGroup = "Keresés...";

        public string SearchGroup
        {
            get { return _searchGroup; }
            set
            {

                _searchGroup = value;
                NotifyOfPropertyChange(() => SearchGroup);
            }
        }

        private BindableCollection<Osztaly> _csoportok;

        public BindableCollection<Osztaly> Csoportok
        {
            get { return _csoportok; }
            set
            {
                _csoportok = value;
            }
        }
        private BindableCollection<Osztaly> _searchableCsoportok;

        public BindableCollection<Osztaly> SearchableCsoportok
        {
            get { return _searchableCsoportok; }
            set
            {
                _searchableCsoportok = value;
                NotifyOfPropertyChange(() => SearchableCsoportok);
            }
        }
        private Osztaly _selectedCsoport;

        public Osztaly SelectedCsoport
        {
            get { return _selectedCsoport; }
            set
            {
                _selectedCsoport = value;

            }
        }

        public void DoubleClickCsoportList()
        {
            if (SelectedCsoport != null)
            {
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
        private Screen _selectedCsoportIndex;

        public Screen SelectedCsoportIndex
        {
            get { return _selectedCsoportIndex; }
            set { _selectedCsoportIndex = value; }
        }

        public void SearchingForCsoport(ActionExecutionContext context)
        {
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

        public void AddGroup()
        {
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
        public void RemoveGroup()
        {
            if (SelectedCsoport != null)
            {
                var result = MessageBox.Show(string.Format("Valóban törölni szeretné a következő csoportot: {0} ?", SelectedCsoport.Name), "Csoport törlése", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var dolgozoHelper = new DolgozoDatabaseHelper();
                    if (dolgozoHelper.RemoveOsztaly(SelectedCsoport))
                    {
                        Csoportok = dolgozoHelper.GetOsztalyok();
                        SearchableCsoportok = new BindableCollection<Osztaly>(Csoportok);
                        MessageBox.Show("Csoport törölve.");
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen törlés. Amíg van olyan cikk kiadva akinél ez a csoport szerepel nem lehet törölni!");
                    }

                }

            }
        }
        #endregion
        public void LostFocus()
        {
            SearchGroup = "Keresés...";
        }
        public void OnFocus()
        {
            SearchGroup = "";
        }
    }
}
