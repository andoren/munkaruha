using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;
using Raktar.Views;
namespace Raktar.ViewModels
{
    class RaktarViewModel : Screen
    {
        public BindableCollection<Munkaruha> RaktarCikkek
        {
            get
            {
                BindableCollection<Munkaruha> munkaruhak = new BindableCollection<Munkaruha>();
                var getmunkaruhak = new MunkaruhaDatabaseHelper();

                foreach (var ruha in getmunkaruhak.GetRuhakFromRaktar())
                {
                    munkaruhak.Add(ruha);
                }
                return munkaruhak;
            }
        }
        public void Bevetelez()
        {
            var window = new WindowManager();
            var bevwindow = new BevWindowViewModel();
            var result = window.ShowDialog(bevwindow, null, null);
            if (result.HasValue && result.Value)
            {

                NotifyOfPropertyChange(() => RaktarCikkek);
            }
        }
        public void Kiad()
        {
            var window = new WindowManager();
            var kiadwindow = new KiadWindowViewModel();
            var result = window.ShowDialog(kiadwindow, null, null);
            if (result.HasValue && result.Value)
            {

                NotifyOfPropertyChange(() => RaktarCikkek);
            }

        }
        public void Bevetelezesek() {
            var window = new WindowManager();
            var kiadwindow = new BevetelezesekViewModel();
            var result = window.ShowDialog(kiadwindow, null, null);
        }
    }
}
