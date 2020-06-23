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
    class PartnerekViewModel:Screen,IHandle<Partner>
    {
        public PartnerekViewModel()
        {
           PartnerHelper partnerhelper = new PartnerHelper();
           Partnerek = partnerhelper.GetPartners();
           SearchablePartners = new BindableCollection<Partner>(Partnerek); 
        }
        #region partnerek
        private string _searchPartner = "Keresés...";

        public string SearchPartner
        {
            get { return _searchPartner; }
            set
            {
                _searchPartner = value;
                NotifyOfPropertyChange(() => SearchPartner);
            }
        }

        private BindableCollection<Partner> _partnerek;

        public BindableCollection<Partner> Partnerek
        {
            get { return _partnerek; }
            set
            {
                _partnerek = value;
                NotifyOfPropertyChange(() => Partnerek);
            }
        }

        private BindableCollection<Partner> _searchablepartners;

        public BindableCollection<Partner> SearchablePartners
        {
            get { return _searchablepartners; }
            set
            {
                _searchablepartners = value;
                NotifyOfPropertyChange(() => SearchablePartners);

            }
        }
        private Partner _selectedpartner;

        public Partner SelectedPartner
        {
            get { return _selectedpartner; }
            set { _selectedpartner = value; }
        }
        public void DoubleClickPartnerList()
        {
            if (SelectedPartner != null)
            {
                var windowmanager = new WindowManager();
                var window = new ModifyPartnerViewModel(SelectedPartner);
                var result = windowmanager.ShowDialog(window, null, null);
                if (result == true)
                {
                    PartnerHelper partnerhelper = new PartnerHelper();
                    Partnerek = partnerhelper.GetPartners();
                    SearchablePartners = new BindableCollection<Partner>(Partnerek);
                    MessageBox.Show("Partner módosítva.");
                }
            }
        }

        public void SearchForPartners(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;
            if (string.IsNullOrEmpty(SearchPartner) || SearchPartner == "Keresés...")
            {
                SearchablePartners = new BindableCollection<Partner>(Partnerek);

                return;
            }
            if (keyArgs != null)
            {
                SearchablePartners = new BindableCollection<Partner>();
                foreach (Partner item in Partnerek.Where(p => p.Name.ToLower().Contains(SearchPartner.ToLower())).ToArray())
                {
                    SearchablePartners.Add(item);
                }

            }
        }

        public void RemovePartner()
        {
            if (SelectedPartner != null)
            {
                var result = MessageBox.Show(string.Format("Valóban törölni szeretné a következő partnert: {0} ?", SelectedPartner.Name), "Partner törlése", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var partnerhelper = new PartnerHelper();
                    if (partnerhelper.DeletePartner(SelectedPartner.Id))
                    {
                        Partnerek = partnerhelper.GetPartners();
                        SearchablePartners = new BindableCollection<Partner>(Partnerek);
                        MessageBox.Show("Partner törölve.");
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen törlés. Amíg van olyan cikk kiadva akinél ez a partner szerepel nem lehet törölni!");
                    }

                }

            }
        }
        public void AddPartner()
        {
            var windowmanager = new WindowManager();
            var window = new AddAndModifyPartnerViewModel();
            var result = windowmanager.ShowDialog(window, null, null);
            if (result == true)
            {
                PartnerHelper partnerhelper = new PartnerHelper();
                Partnerek = partnerhelper.GetPartners();
                SearchablePartners = new BindableCollection<Partner>(Partnerek);
                MessageBox.Show("Partner hozzáadva");
            }
        }
        #endregion
        public void LostFocus() {
            SearchPartner = "Keresés...";
        }
        public void OnFocus() {
            SearchPartner = "";
        }

        public void Handle(Partner message)
        {
            throw new NotImplementedException();
        }
    }
}
