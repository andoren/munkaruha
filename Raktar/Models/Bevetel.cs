using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Models
{
    class Bevetel
    {
        private int _bevetid;

        public int BevetId
        {
            get { return _bevetid; }
            set { _bevetid = value; }
        }

        private string _szamlaszam;

        public string Szamlaszam
        {
            get { return _szamlaszam; }
            set { _szamlaszam = value; }
        }


    }
}
