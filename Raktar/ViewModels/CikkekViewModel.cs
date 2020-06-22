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
    class CikkekViewModel:Screen
    {
        public CikkekViewModel(ISetCikk bevwindow)
        {
            this.window = bevwindow;
            SetCikkek();
        }
        ISetCikk window;
        private void SetCikkek() {

            Cikkek = new BindableCollection<Munkaruha>();
            var dbhelper = new MunkaruhaDatabaseHelper();
            if (window is KiadWindowViewModel)
            {
                foreach (var cikk in dbhelper.GetRuhakFromRaktar())
                {
                    Cikkek.Add(cikk);
                }
            }
            else
            {
                foreach (var cikk in dbhelper.GetAllCikkek())
                {
                    Cikkek.Add(cikk);
                }
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
        private Munkaruha munkaruha;

        public Munkaruha Munkaruha
        {
            get { return munkaruha; }
            set {
                munkaruha = value;
                NotifyOfPropertyChange(() => Munkaruha);
            }
        }

        public void Save() {
            if (Munkaruha is null) {
                Logger.Log("Nincs ilyen cikk!");
                return;
            }
            window.SetCikk(Munkaruha);
            TryClose(true);
        }
        public void Exit() {
            TryClose(false);
        }
    }
}
