﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.ViewModels
{
    class PopUpViewModel:Screen
    {
        public void Close() {
            TryClose();
        }
    }
}
