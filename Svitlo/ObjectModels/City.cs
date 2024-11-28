using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svitlo.ObjectModels
{
    public class City
    {
        public string value { get; set; }
        public string label { get; set; }
        public override string ToString()
        {
            return value.ToString();
        }
    }

}
