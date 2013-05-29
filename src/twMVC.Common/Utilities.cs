using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace twMVC.Common
{
    public class Utilities
    {
        public static string GetShinyName(string name)
        {
            return string.Format("** {0} **", name);
        }
    }
}
