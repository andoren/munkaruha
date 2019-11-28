using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raktar.Models;
using Raktar.Models.Database;

namespace Raktar.ViewModels
{
    class AddAndModifyDolgozoViewModel:Screen
    {
        public AddAndModifyDolgozoViewModel()
        {
            DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
            Groups = dolgozohelper.GetOsztalyok();
            Title = "Új dolgozó hozzáadása";
            ActionButtonText = "Hozzáadás";
        }
        public AddAndModifyDolgozoViewModel(Dolgozo Dolgozo, bool isModify )
        {
            DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
            Groups = dolgozohelper.GetOsztalyok();
            this.Dolgozo = Dolgozo;
            NewName = Dolgozo.Name;
            SelectedGroupIndex = Groups.IndexOf(Groups.Where(d=> d.Id ==  Dolgozo.GroupId).First());
            if (isModify)
            {
                ActionButtonText = "Módosítás";
                Title = "Dolgozó módosítása";
            }
            else {
                ActionButtonText = "Hozzáadás";
                Title = "Új dolgozó hozzáadása";
            }
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set {
                _title = value;
                NotifyOfPropertyChange(()=>Title);
            }
        }

        private string _actionButtonText;

        public string ActionButtonText
        {
            get { return _actionButtonText; }
            set {
                _actionButtonText = value;
                NotifyOfPropertyChange(() => ActionButtonText);
            }
        }

        private Dolgozo _dolgozo;

        public Dolgozo Dolgozo
        {
            get { return _dolgozo; }
            set { _dolgozo = value; }
        }

        private string _newName;
        public string NewName
        {
            get { return _newName; }
            set { _newName = value; }
        }

        private Osztaly _group;
        public Osztaly Group

        {
            get { return _group; }
            set {
                _group = value;
                SelectedGroupIndex = Groups.IndexOf(value);
                NotifyOfPropertyChange(()=>Group);
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
                NotifyOfPropertyChange( ()=>SelectedGroupIndex );
            }
        }

        private BindableCollection<Osztaly> _groups;

        public BindableCollection<Osztaly> Groups
        {
            get { return _groups; }
            set {
                _groups = value;
                NotifyOfPropertyChange(()=>Groups);
                
            }
        }

        public void SaveAction() {
            if (Dolgozo == null)
            {
                DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
                if (dolgozohelper.AddDolgozo(NewName, Group))
                    TryClose(true);
                else
                    TryClose(false);
            }
            else {
                DolgozoDatabaseHelper dolgozohelper = new DolgozoDatabaseHelper();
                Dolgozo.Name = NewName;
                if (dolgozohelper.ModifyDolgozo(Dolgozo, Group))
                    TryClose(true);
                else
                    TryClose(false);
            }

        }
        public void CloseWindow() {
            TryClose(false);
        }
    }
}
