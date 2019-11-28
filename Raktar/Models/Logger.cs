using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Raktar.Models
{
   public class Logger
    {
        public static void Log(string msg) {
            MessageBox.Show(msg);
        }
    }
}
