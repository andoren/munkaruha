using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Models
{
    class Dolgozo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _groupid;

        public int GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }
        private string _groupname;

        public string GroupName
        {
            get { return _groupname; }
            set { _groupname = value; }
        }

        public string NameWithGroupName {
            get {
                return string.Format("{0} - {1}",Name,GroupName);
            }
        }


    }
}
