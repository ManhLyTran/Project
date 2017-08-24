using System;
using System.Collections.Generic;
using System.Configuration;

namespace HVKTQS.Common
{
    public class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}