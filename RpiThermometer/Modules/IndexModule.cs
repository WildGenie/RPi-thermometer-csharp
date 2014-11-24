using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace RpiThermometer.Modules
{
    public class IndexModule: NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ =>
            {
                return View["index.html", 4];
            };

            Get["/temperature"] = _ =>
            {
                return 5;
            };
        }
    }
}
