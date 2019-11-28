using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;

namespace Raktar.ViewModels
{
    class VisszavetViewModel:Screen
    {
        public VisszavetViewModel(Dolgozo Dolgozo,BindableCollection<Munkaruha> Cikkek)
        {
            this.Cikkek = Cikkek;
            this.Dolgozo = Dolgozo;
            Ruhak = new BindableCollection<Munkaruha>();
        }
        private string _count;

        public string Count
        {
            get { return _count; }
            set {
                _count = value;
                NotifyOfPropertyChange(()=>Count);
            }
        }

        private Dolgozo _dolgozo;

        public Dolgozo Dolgozo
        {
            get { return _dolgozo; }
            set { _dolgozo = value; }
        }
        private Munkaruha munkaruha;

        public Munkaruha Munkaruha
        {
            get { return munkaruha; }
            set { munkaruha = value;
                NotifyOfPropertyChange(()=>Munkaruha);
            }
        }


        private BindableCollection<Munkaruha> _cikkek;

        public BindableCollection<Munkaruha> Cikkek
        {
            get { return _cikkek; }
            set {
                _cikkek = value;
                NotifyOfPropertyChange(() => Cikkek);
            }
        }

        private BindableCollection<Munkaruha> _ruhak;
        public BindableCollection<Munkaruha> Ruhak {
            get {
                return _ruhak;
            }
            set {
                _ruhak = value;
            }
        }
        public void AddCikkToGrid()
        {
            if (Count == null || Count == string.Empty || int.Parse(Count) < 1)
            {
                Logger.Log("Hibás mennyiség!");
                return;
            }
            if (Munkaruha.Mennyiseg - int.Parse(Count) < 0)
            {
                Logger.Log("Több mennyiséget nem adhatsz ki mint amennyi a személynél van !");
                return;
            }
            Cikkek.Where(p => p.Id == Munkaruha.Id).First().Mennyiseg -= int.Parse(Count); 
            var ruha = new Munkaruha() {
                Cikkszam = Munkaruha.Cikkszam,
                Mennyiseg = int.Parse(Count),
                Id = Munkaruha.Id,
                Mertekegyseg = Munkaruha.Mertekegyseg,
                Cikknev = Munkaruha.Cikknev,
                Egysegar = Munkaruha.Egysegar,
                Partner = Munkaruha.Partner};
            Ruhak.Add(ruha);           
            NotifyOfPropertyChange(() => Ruhak);
            Count = "";
            Munkaruha = new Munkaruha();
        }
        public void Save() {
            DolgozoDatabaseHelper helper = new DolgozoDatabaseHelper();
            helper.Visszavetelezes(Dolgozo.Id,Ruhak.ToArray<Munkaruha>());
            TryClose(true);
        }
        public void CloseWindow() {
            TryClose(false);
        }
    }
}
