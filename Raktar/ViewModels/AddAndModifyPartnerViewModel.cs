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
    class AddAndModifyPartnerViewModel:Screen
    {
        public AddAndModifyPartnerViewModel(BindableCollection<Partner> Partnerek)
        {
            this.Partnerek = Partnerek;
        }
        private BindableCollection<Partner> _partnerek;

        public BindableCollection<Partner> Partnerek
        {
            get { return _partnerek; }
            set { _partnerek = value; }
        }
        #region partner properties
        private string _newname;

        public string NewName
        {
            get { return _newname; }
            set { _newname = value; }
        }


        #endregion



        public void SaveAction() {
            if (NewName == null || NewName == string.Empty) return;
            PartnerHelper helper = new PartnerHelper();
            if (helper.AddPartner(
                new Partner()
                {
                    Name = NewName
                }
            ))
                TryClose(true);
            else
                TryClose(false);
        }
        public void CloseWindow() {

            TryClose(false);
        }
    }
}
