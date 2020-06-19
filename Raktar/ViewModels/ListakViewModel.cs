using Caliburn.Micro;
using Raktar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.ViewModels
{
    class ListakViewModel:Screen
    {
        SceneFactory sceneFactory = new SceneFactory();
        public void DolgozoOsztalyLista() {
                var doglozokbygroup = new ListDolgozoPrintByGroupViewModel();
                var manager = new WindowManager();
                var result = manager.ShowDialog(doglozokbygroup, null, null);
        }
    }
}
