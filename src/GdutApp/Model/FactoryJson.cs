using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GdutApp.Model
{
    public class FactoryJson
    {

        public string BaseName { get; set; }
        public string ReportBaseUrl { get; set; }

        public List<string> Hosts { get; set; } = new List<string>();

        public string Description { get; set; }
    }
}
