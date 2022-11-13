using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filtering.Models
{
    public class LogVeri
    {
        // Kapsülleme (Encapsulation)
        private static List<LogBilgi> loglistesi = new List<LogBilgi>();

        public static List<LogBilgi> Loglar
        {
            get { return loglistesi; }
        }
    }
}