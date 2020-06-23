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
    class ModifyPartnerViewModel:Screen

    {
        public ModifyPartnerViewModel(Partner partner)
        {
            this.Partner = partner;
        }
        private Partner _partner;

        public Partner Partner
        {
            get { return _partner; }
            set { _partner = value;
                NotifyOfPropertyChange(()=>Partner);
            }
        }
        public void Exit() {
            TryClose(false);
        }
        public void Save() {
            PartnerHelper partnerHelper = new PartnerHelper();
            if (partnerHelper.ModifyPartner(Partner))
                TryClose(true);
            else        
                TryClose(false);         
        }
    }
}
