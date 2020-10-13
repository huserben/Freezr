using System;
using System.Collections.Generic;

namespace Freezr.Core
{
    public static class Config
    {
        private static Dictionary<string, string> configValues = new Dictionary<string, string>();

        public static string Get(string variable)
        {
            if (!configValues.ContainsKey(variable))
            {
                var value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
                if (string.IsNullOrEmpty(value))
                {
                    value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
                }
                configValues[variable] = value;
            }
            return configValues[variable];
        }
    }
}