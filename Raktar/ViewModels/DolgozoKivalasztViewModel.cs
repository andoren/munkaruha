using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Raktar.Models;
using Raktar.Models.Database;
using System.Windows.Input;

namespace Raktar.ViewModels
{
    class DolgozoKivalasztViewModel:Screen
    {
        public DolgozoKivalasztViewModel(IValasztEmber window)
        {
            this.window = window;
            DolgozoDatabaseHelper helper = new DolgozoDatabaseHelper();
            Dolgozok = new BindableCollection<Dolgozo>();
            foreach (Dolgozo dolgozo in helper.GetDolgozok())
            {
                Dolgozok.Add(dolgozo);
            }
        }

        private IValasztEmber window;
        private BindableCollection<Dolgozo> _dolgozok;

        public BindableCollection<Dolgozo> Dolgozok
        {
            get { return _dolgozok; }
            set { _dolgozok = value;

            }
        }
        private Dolgozo dolgozo;

        public Dolgozo Dolgozo
        {
            get { return dolgozo; }
            set { dolgozo = value; }
        }
        public void Save() {
            if (Dolgozo != null) {
                window.Dolgozo = Dolgozo;
                TryClose(true);
            }
                
            else {
                MessageBox.Show("Nincs ilyen nevű dolgozó!");
            }

        }

        public void Exit() {
            TryClose(false);
        }
        public void ExecuteFilterView(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;

            if (keyArgs != null && keyArgs.Key == Key.Enter)
            {
                Save();
            }
        }
    }
}
