using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd1
{
    class trainer
    {
        public int id { get; set; }
        public string fio { get; set; }

        public override string ToString()
        {
            return fio;
        }
    }
}
