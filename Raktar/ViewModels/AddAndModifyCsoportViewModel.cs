using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;

namespace Raktar.ViewModels
{
    class AddAndModifyCsoportViewModel:Screen
    {
        private string _newname;

        public string NewName
        {
            get { return _newname; }
            set { _newname = value; }
        }

        public void SaveAction() {

            if (NewName == null || NewName == string.Empty)
            {
                MessageBox.Show("Hibás adat");
                return;
            }
            MunkaruhaDatabaseHelper helper = new MunkaruhaDatabaseHelper();
            if (helper.AddCikkCsoport(new Csoport() { Name = NewName }))
            {
                TryClose(true);
            }
            else {
                MessageBox.Show("Hiba a mentés közben");
                TryClose(false);
            }
            
        }
        public void CloseWindow() {
            TryClose(false);

        }
    }
}
