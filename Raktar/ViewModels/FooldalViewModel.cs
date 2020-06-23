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
    public class FooldalViewModel:Screen
    {

        public void Cikk() {
            var windowmanager = new WindowManager();
            MunkaruhaDatabaseHelper helper = new MunkaruhaDatabaseHelper();
            var window = new AddAndModifyCikkViewModel(helper.GetCikkCsoportok());
            var result = windowmanager.ShowDialog(window, null, null);
            if (result == true)
            {
                MessageBox.Show("Cikk hozzáadva");
            }
        }
        public void Dolgozo() {
            var window = new WindowManager();
            var dolgozowindow = new AddAndModifyDolgozoViewModel();
            var result = window.ShowDialog(dolgozowindow, null, null);
            if (result == true)
            {

                MessageBox.Show("Dolgozó hozzáadva.");
            }
        }
        public void Osztaly() {
            var windowmanager = new WindowManager();
            var window = new AddAndModifyOsztalyViewModel();
            var result = windowmanager.ShowDialog(window, null, null);
            if (result == true)
            {

                MessageBox.Show("Osztaly hozzáadva");
            }
        }
        public void Partner() {
            var windowmanager = new WindowManager();
            var window = new AddAndModifyPartnerViewModel();
            var result = windowmanager.ShowDialog(window, null, null);
            if (result == true)
            {
 
                MessageBox.Show("Partner hozzáadva");
            }
        }
        public void Csoport() {
            var windowmanager = new WindowManager();
            var window = new AddAndModifyCsoportViewModel();
            var result = windowmanager.ShowDialog(window, null, null);
            if (result == true)
            {

                MessageBox.Show("Csoport hozzáadva");
            }
        }
    }
}
