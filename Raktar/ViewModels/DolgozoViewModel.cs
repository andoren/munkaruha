using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Xml;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;


namespace Raktar.ViewModels
{
    class DolgozoViewModel:Screen,IValasztEmber
    {
        public DolgozoViewModel()
        {
            Ruhak = new BindableCollection<Munkaruha>();
            cvTasks = CollectionViewSource.GetDefaultView(Ruhak);
            
            NotifyOfPropertyChange(() => cvTasks);
        }
        #region IValasztInteface
        private Dolgozo _dolgozo;

        public Dolgozo Dolgozo
        {
            get { return _dolgozo; }
            set
            {

                _dolgozo = value;
                NotifyOfPropertyChange(() => WorkerName);
                NotifyOfPropertyChange(() => WorkerGroup);
                if (value != null) GetRuhakByDolgozoId(value.Id);

            }
        }
        public string WorkerName
        {
            get
            {
                if (Dolgozo != null)
                    return Dolgozo.Name;
                else return "";
            }
        }
        public string WorkerGroup
        {
            get
            {
                if (Dolgozo != null)
                    return Dolgozo.GroupName;
                else
                    return "";
            }
        }


        public void KivalasztDolgozo()
        {
            var window = new WindowManager();
            var kivwindow = new DolgozoKivalasztViewModel(this);
            var result = window.ShowDialog(kivwindow, null, null);
            if (result.HasValue && result.Value)
            {


            }
        }
        #endregion
        #region Ruha
        private BindableCollection<Munkaruha> _ruhak;

        public BindableCollection<Munkaruha> Ruhak
        {
            get { return _ruhak; }
            set { _ruhak = value;
                NotifyOfPropertyChange(() => Ruhak);
                NotifyOfPropertyChange(() => Sum);
            }
        }
        public string Sum
        {
            get
            {
                int sum = 0;
                foreach (var item in Ruhak)
                {
                    sum += item.Osszesen;
                }
                return sum.ToString("C0");
            }

        }
        #endregion
        private void GetRuhakByDolgozoId(int dolgozoId) {
            Ruhak = new BindableCollection<Munkaruha>();
            DolgozoDatabaseHelper helper = new DolgozoDatabaseHelper();
            Ruhak = helper.GetRuhakByDolgozoId(Dolgozo.Id);
            cvTasks = CollectionViewSource.GetDefaultView(Ruhak);
            cvTasks = CollectionViewSource.GetDefaultView(Ruhak);
            cvTasks.GroupDescriptions.Add(new PropertyGroupDescription("Cikkcsoport"));
            NotifyOfPropertyChange(() => cvTasks);
        }
        private ICollectionView _cvTasks;

        public ICollectionView cvTasks
        {
            get { return _cvTasks; }
            set { _cvTasks = value;
                NotifyOfPropertyChange(()=>cvTasks);
            }
        }

     
        public void Visszavet() {
            if (Dolgozo != null) {
                var visszavetwindow = new VisszavetViewModel(Dolgozo,Ruhak);
                var manager = new WindowManager();
                var result = manager.ShowDialog(visszavetwindow, null, null);
                if (result == true)
                {
                    GetRuhakByDolgozoId(Dolgozo.Id);
                }
                
            }
            else
                Logger.Log("Nincs dolgozó kiválasztva!");
        }
        public void Kivezetes() {
            if (Dolgozo != null) {
                var kivezeteswindow = new KivezetesViewModel(Dolgozo,Ruhak);
                var manager = new WindowManager();
                var result = manager.ShowDialog(kivezeteswindow, null, null);
                if (result == true)
                {
                    GetRuhakByDolgozoId(Dolgozo.Id);
                }
            }
                
            else
                Logger.Log("Nincs dolgozó kiválasztva!");
        }
        public void Nyomtatas() {

            if (Dolgozo != null )
            {
                var printview = new PrintingWindowViewModel(Dolgozo, Ruhak);
                var manager = new WindowManager();
                manager.ShowDialog(printview, null, null);

            }

            else
                Logger.Log("Nincs dolgozó kiválasztva!");

        }
        public void Megvaltas() {
            if (Dolgozo != null && Dolgozo.GroupName.ToLower() != "fejlesztő") {
                var result = MessageBox.Show("A megváltás előtt a nem megváltandó ruhákat, eszközöket ki kell vezetni vagy visszavételezni.","Megváltás",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK) {
                    var printview = new PrintMegvaltasViewModel(Dolgozo, Ruhak);
                    var manager = new WindowManager();
                    var isDeleted = manager.ShowDialog(printview, null, null);
                    if ((bool)isDeleted) {
                        GetRuhakByDolgozoId(Dolgozo.Id);
                    }
                }
          
            }
            else
            {
                if (Dolgozo == null)
                    Logger.Log("Nincs dolgozó kiválasztva!");
                else {
                    Logger.Log("Fejlesztőben nincs megváltás!");
                }
            }
        }
    }
    
}
