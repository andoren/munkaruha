using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raktar.ViewModels;
using Caliburn.Micro;

namespace Raktar.Models
{
    class SceneFactory
    {

        public Screen CreateScene(int index)
        {
            if (index < 0) throw new InvalidIndexExceptionForScene();
            Screen scene = null;
            switch (index)
            {
                case 0:
                    {
                        scene = new FooldalViewModel();
                        break;
                    }
                case 1:
                    {
                        scene = new TorzsViewModel();
                        break;
                    }
                case 2:
                    {
                        scene = new RaktarViewModel();
                        break;
                    }
                case 3:
                    {
                        scene = new DolgozoViewModel();
                        break;
                    }
                case 4:
                    {
                        scene = new ListakViewModel();
                        break;
                    }
                case 5:
                    {
                        scene = new ListDolgozoPrintByGroupViewModel();
                        break;
                    }
                case 6:
                    {
                        scene = new BevetelezesekViewModel();
                        break;
                    }
                default:
                    break;
            }
            return scene;
        }
    }
}
