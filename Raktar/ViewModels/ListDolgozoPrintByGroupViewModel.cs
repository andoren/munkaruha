using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.ViewModels
{
    class ListDolgozoPrintByGroupViewModel:Screen
    {
        public ListDolgozoPrintByGroupViewModel()
        {
            DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
            Groups = dolgozohelper.GetOsztalyok();
        }

        private Osztaly _group;
        public Osztaly Group

        {
            get { return _group; }
            set
            {
                _group = value;
                SelectedGroupIndex = Groups.IndexOf(value);
                NotifyOfPropertyChange(() => Group);
            }
        }
        private int _selectedGroupIndex;

        public int SelectedGroupIndex
        {
            get
            {

                return _selectedGroupIndex;
            }
            set
            {
                if (value > Groups.Count || value < -1) _selectedGroupIndex = -1;
                else _selectedGroupIndex = value;
                NotifyOfPropertyChange(() => SelectedGroupIndex);
            }
        }

        private BindableCollection<Osztaly> _groups;

        public BindableCollection<Osztaly> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                NotifyOfPropertyChange(() => Groups);

            }
        }
        public void ExitButton() {
            TryClose(false);
        }
        public void Elonezet() {
            if (SelectedGroupIndex != -1)
            {
                var windowmanager = new WindowManager();
                var window = new PrintOsztalyViewModel(Group.Name);
                var result = windowmanager.ShowDialog(window, null, null);
            }
        }
    }
}
