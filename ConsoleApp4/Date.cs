using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1st_Lab_For_Final
{
    class Date
    {
        private int dd;
        private int mm;
        private int yy;

        public Date(int dd = 1, int mm = 1, int yy = 2015)
        {
            this.dd = dd;
            this.mm = mm;
            this.yy = yy;
        }
        public void SetDate(int dd, int mm, int yy)
        {
            this.dd = dd;
            this.mm = mm;
            this.yy = yy;
        }

        public int Dd { get => dd; }
        public int Mm { get => mm; }
        public int Yy { get => yy; }
    }
}