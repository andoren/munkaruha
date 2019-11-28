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
    class AddAndModifyCikkViewModel:Screen
    {
        public AddAndModifyCikkViewModel(BindableCollection<Csoport> Groups)
        {
            this.Groups = Groups;
            ButtonText = "Hozzáadás";
            OsztalyBoxIsEnabled = true;
        }
        public AddAndModifyCikkViewModel(BindableCollection<Csoport> Groups, Munkaruha Ruha)
        {
            this.Groups = Groups;
            this.Ruha = Ruha;
            ButtonText = "Módosítás";
            OsztalyBoxIsEnabled = false;
            Group = Groups.Where(x => x.Id == Ruha.CikkcsoportId).First();
            NewName = Ruha.Cikknev;
            Mertekegyseg = Ruha.Mertekegyseg;
        }
        private bool _osztalyBoxIsEnabled;

        public bool OsztalyBoxIsEnabled
        {
            get { return _osztalyBoxIsEnabled; }
            set { _osztalyBoxIsEnabled = value; }
        }

        private Munkaruha _ruha;    

        public Munkaruha Ruha
        {
            get { return _ruha; }
            set { _ruha = value; }
        }

        private string _newname;

        public string NewName
        {
            get { return _newname; }
            set { _newname = value; }
        }

        private BindableCollection<Csoport> _groups;

        public BindableCollection<Csoport> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }
        private Csoport _group;

        public Csoport Group
        {
            get { return _group; }
            set { _group = value; }
        }
        private string _mertekegyseg;

        public string Mertekegyseg
        {
            get { return _mertekegyseg; }
            set { _mertekegyseg = value; }
        }
        public void SaveAction() {
            if (Ruha == null) {
                MunkaruhaDatabaseHelper ruhahelper = new MunkaruhaDatabaseHelper();
                if (ruhahelper.AddNewRuha(NewName, Mertekegyseg, Group))
                    TryClose(true);
                else
                    TryClose(false);
            }
            else
            {
                MunkaruhaDatabaseHelper ruhahelper = new MunkaruhaDatabaseHelper();
                if (ruhahelper.ModifyRuha(new Munkaruha() {
                    Id = Ruha.Id,
                    Mertekegyseg = this.Mertekegyseg,
                    CikkcsoportId = Group.Id,
                    Cikknev = NewName
                }))
                    TryClose(true);
                else
                    TryClose(false);
            }
   
        }
        public void CloseWindow() {
            TryClose(false);
        }
        private string _buttonText;

        public string ButtonText
        {
            get { return _buttonText; }
            set { _buttonText = value; }
        }


    }
}
