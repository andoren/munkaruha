using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Models
{
    class Munkaruha
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _cikkszam;

        public string Cikkszam
        {
            get
            {
                return _cikkszam; 
            }
            set
            {
                _cikkszam = value;
            }
        }
        private string _cikknev;

        public string Cikknev
        {
            get
            {
                return _cikknev;
            }
            set
            {
                _cikknev = value;
            }
        }
        private int _cikkcsoportId;

        public int CikkcsoportId
        {
            get
            {
                return _cikkcsoportId;
            }
            set
            {
                _cikkcsoportId = value;
            }
        }
        private string _cikkcsoport;

        public string Cikkcsoport
        {
            get
            {
                return _cikkcsoport;
            }
            set
            {
                _cikkcsoport = value;
            }
        }
        private int _mennyiseg;

        public int Mennyiseg
        {
            get { return _mennyiseg; }
            set { _mennyiseg = value; }
        }
        private string _mertekegyseg;

        public string Mertekegyseg
        {
            get { return _mertekegyseg; }
            set { _mertekegyseg = value; }
        }
        private int _egysegar;

        public int Egysegar
        {
            get
            {
                return _egysegar;
            }
            set
            {
                _egysegar = value;
            }
        }

        public int Osszesen
        {
            get
            {
                return Hasznalt?0:Egysegar * Mennyiseg;
            }
        }
        private bool _hasznalt;

        public bool Hasznalt
        {
            get { return _hasznalt; }
            set { _hasznalt = value; }
        }

        private string _bevdatum;

        public string Bevdatum
        {
            get { return _bevdatum; }
            set { _bevdatum = value; }
        }

        private string _kiaddatum;

        public string KiadDatum
        {
            get { return _kiaddatum; }
            set { _kiaddatum = value; }
        }


        private string _partner;

        public string Partner
        {
            get { return _partner; }
            set { _partner = value; }
        }
        private int _partnerId;

        public int PartnerId
        {
            get { return _partnerId; }
            set { _partnerId = value; }
        }

        public string NameForCikk {
            get
            {
                return string.Format("{0} - {1}", Cikkszam, Cikknev);
            }
        }

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
