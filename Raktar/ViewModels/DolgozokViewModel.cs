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
    class DolgozokViewModel:Screen
    {
        public DolgozokViewModel()
        {
           DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();

           Dolgozok = dolgozohelper.GetDolgozok();
           SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
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
            if (string.IsNullOrEmpty(Search) || Search == "Keresés...")
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
                var dolgozowindow = new AddAndModifyDolgozoViewModel(SelectedDolgozo, true);
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
        public void AddWorker()
        {
            var window = new WindowManager();
            var dolgozowindow = new AddAndModifyDolgozoViewModel();
            var result = window.ShowDialog(dolgozowindow, null, null);
            if (result == true)
            {
                DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
                Dolgozok = dolgozohelper.GetDolgozok();
                SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
                MessageBox.Show("Dolgozó hozzáadva.");
            }
        }
        public void RemoveWorker()
        {
            if (SelectedDolgozo != null)
            {
                var result = MessageBox.Show(string.Format("Valóban törölni szeretné a következő dolgozót: {0} ?", SelectedDolgozo.Name), "Dolgozó törlése", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var dolgozohelper = new DolgozoDatabaseHelper();
                    if (dolgozohelper.DeleteDolgozo(SelectedDolgozo.Id))
                    {
                        Dolgozok = dolgozohelper.GetDolgozok();
                        SearchableDolgozo = new BindableCollection<Dolgozo>(Dolgozok);
                        MessageBox.Show("Dolgozó törölve.");
                    }
                    else
                    {
                        MessageBox.Show("Hiba a törlés közben!");
                    }

                }

            }

        }
        #endregion
    }
}
