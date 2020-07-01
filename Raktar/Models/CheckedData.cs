using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Models
{
    class CheckedData
    {
        public CheckedData(int DolgozoCount, int ClothesCount)
        {
            this.DolgozoCount = DolgozoCount;
            this.ClothesCount = ClothesCount;
        }
        private int dolgozoCount;

        public int DolgozoCount
        {
            get { return dolgozoCount; }
            set { dolgozoCount = value; }
        }
        private int clothesCount;

        public int ClothesCount
        {
            get { return clothesCount; }
            set { clothesCount = value; }
        }


    }
}
