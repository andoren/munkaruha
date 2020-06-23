using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;
namespace Raktar.ViewModels
{
    class TorzsViewModel:Conductor<Screen>.Collection.AllActive
    {
        public TorzsViewModel()
        {
            SetScreens();
        }
        private void SetScreens() {
            WorkerContainer = new DolgozokViewModel();
            ClassContainer = new OsztalyokViewModel();
            PartnerContainer = new PartnerekViewModel();
            ItemContainer = new CikkekTorzsViewModel();
        }
        private Screen _workerContainer;

        public Screen WorkerContainer
        {
            get { return _workerContainer; }
            set { _workerContainer = value; }
        }
        private Screen _classContainer;

        public Screen ClassContainer
        {
            get { return _classContainer; }
            set { _classContainer = value; }
        }

        private Screen _partnerContainer;

        public Screen PartnerContainer
        {
            get { return  _partnerContainer; }
            set {  _partnerContainer = value; }
        }
        private Screen _itemContainer;

        public Screen ItemContainer
        {
            get { return _itemContainer; }
            set { _itemContainer = value; }
        } 
    }
}
