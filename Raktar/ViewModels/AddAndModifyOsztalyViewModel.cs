using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raktar.Models;
using Raktar.Models.Database;
using System.Windows;

namespace Raktar.ViewModels
{
    class AddAndModifyOsztalyViewModel:Screen
    {

        public AddAndModifyOsztalyViewModel()
        {
            ButtonText = "Hozzáadás";
        }
        public AddAndModifyOsztalyViewModel(Osztaly Osztaly)
        {
            ButtonText = "Módosítás";
            this.Osztaly = Osztaly;
            this.NewName = Osztaly.Name;

        }
        private string newName;

        public string NewName
        {
            get { return newName; }
            set { newName = value; }
        }

        private Osztaly osztaly;

        public Osztaly Osztaly
        {
            get { return osztaly; }
            set { osztaly = value; }
        }

        public void SaveAction() {
            if (String.IsNullOrWhiteSpace(NewName))
            {
                MessageBox.Show("Az osztály neve nem lehet üres!");
                return;
            }
            else {
                DolgozoDatabaseHelper helper = new DolgozoDatabaseHelper();
                if (Osztaly == null)
                {
                    if (helper.AddOsztaly(new Osztaly() { Name = NewName }))
                    {
                        TryClose(true);
                    }
                    else
                    {
                        TryClose(false);
                    }
                }
                else
                {
                    if (helper.ModifyOsztaly(new Osztaly() {Id = Osztaly.Id,Name = NewName }))
                    {
                        TryClose(true);
                    }
                    else
                    {
                        TryClose(false);
                    }
                }

            }
            
        }
        public void CloseWindow() {
            TryClose(false);
        }
        private string _buttonText;

        public string ButtonText
        {
            get { return _buttonText; }
            set { _buttonText = value; }
        }

    }
}
