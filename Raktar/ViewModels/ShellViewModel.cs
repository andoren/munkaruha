using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Raktar.Models;
using Raktar.Models.Database;
using Raktar.Views;

namespace Raktar.ViewModels
{
    class ShellViewModel : Conductor<Screen>
    {
        public ShellViewModel()
        {

            ActivateItem(sceneFactory.CreateScene(0));
            CurrentMenu = "Főoldal";
            CheckAndExecuteEndings();
        }
        private  async void CheckAndExecuteEndings() {
            DolgozoDatabaseHelper helper = new DolgozoDatabaseHelper();
            CheckedData data = await helper.CheckCloths();
            MessageBoxResult result = MessageBoxResult.Cancel;
            if (data.DolgozoCount > 0) {
                result = MessageBox.Show($"Összesen: {data.DolgozoCount} dolgozónál találtam lejárt ruhát. A ruhák száma: {data.ClothesCount}{Environment.NewLine}Szeretné, hogy töröljem őket?","Lejárt ruhák",MessageBoxButton.OKCancel,MessageBoxImage.Asterisk);
            }
            if (MessageBoxResult.OK == result) {
                await helper.DeleteEndings();
                MessageBox.Show("A lejárt ruhákat kivezettem!");
            }
        }
        SceneFactory sceneFactory = new SceneFactory();
        public void Kilepes()
        {
            TryClose();
        }
        public void MainExit()
        {
            Kilepes();
        }
        public void Kicsinyito(object View) {
            if (View is Window) {
                (View as Window).WindowState = WindowState.Minimized;
            }
        }
        public void Nagyito(object View) {
            if (View is Window)
            {
                Window window = View as Window;
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else {
                    window.WindowState = WindowState.Maximized;
                }
            }
        }
        public void Warehouse()
        {
            ActivateItem(sceneFactory.CreateScene(2));
            CurrentMenu = "Raktár";
        }

        public void Worker()
        {
            ActivateItem(sceneFactory.CreateScene(3));
            CurrentMenu = "Dolgozók";
        }
        public void Intakes() {
            ActivateItem(sceneFactory.CreateScene(6));
            CurrentMenu = "Bevételezések";
        }
        public void MainPage()
        {
            ActivateItem(sceneFactory.CreateScene(0));
            CurrentMenu = "Főoldal";
        }

        public void Torzs()
        {
            ActivateItem(sceneFactory.CreateScene(1));
            CurrentMenu = "Törzs";
        }
        public void Lists()
        {
            ActivateItem(sceneFactory.CreateScene(4));
            CurrentMenu = "Listák";
        }
        public void ItemToWorker()
        {
            ActivateItem(sceneFactory.CreateScene(7));
            CurrentMenu = "Kiadás";
        }
        private string _currentMenu;

        public string CurrentMenu
        {
            get { return _currentMenu; }
            set {
                _currentMenu = value;
                NotifyOfPropertyChange(() => CurrentMenu);
            }
        }
        private string _loadingText = "Temp text";

        public string LoadingText
        {
            get { return _loadingText; }
            set { _loadingText = value;
                NotifyOfPropertyChange(()=>LoadingText);
            }
        }

        private bool _loadingBarIsVisible = false;

        public bool LoadingBarIsVisible
        {
            get { return _loadingBarIsVisible; }
            set { _loadingBarIsVisible = value;
                NotifyOfPropertyChange(()=>LoadingBarIsVisible);
            }
        }

        public static void SetLoader(bool isLoading = true,string action = ""){

        }

        public string CurrentVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
            }
 


        }


    }
}
