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
        const string deviceId = "28-000004e23e98";

        public IndexModule()
        {
            Get["/"] = _ =>
            {
                return View["index.html", GetTemperature()];
            };

            Get["/temperature"] = _ =>
            {
                return GetTemperature();
            };
        }

        private string GetTemperature()
        {
            var si = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    WorkingDirectory = "/",
                    UseShellExecute = false,
                    FileName = "cat",
                    Arguments = " /sys/bus/w1/devices/" + deviceId + "/w1_slave",
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };
            si.Start();
            string output = si.StandardOutput.ReadToEnd();
            si.Close();
            return output;
        }
    }
}
