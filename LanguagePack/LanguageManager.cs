using System;
using System.Globalization;
using System.Resources;

namespace LanguagePack
{
    public class LanguageManager
    {
        public static string GetCommonUrl(string name)
        {
            var resourceManager = new ResourceManager(typeof(CommonUrls));

            try
            {
                string returnValue = resourceManager.GetString(name, CultureInfo.CurrentCulture);

                if (!string.IsNullOrEmpty(returnValue))
                {
                    return returnValue;
                }
            }
            catch (Exception)
            {
                return "Resource Undefined";
            }

            return "Resource Undefined";
        }

        public static string GetLabel(string name)
        {
            var resourceManager = new ResourceManager(typeof(Labels));
            try
            {
                string returnValue = resourceManager.GetString(name, CultureInfo.CurrentCulture);

                if (!string.IsNullOrEmpty(returnValue))
                {
                    return returnValue;
                }
            }
            catch (Exception)
            {
                return "Resource Undefined";
            }

            return "Resource Undefined";
        }

        public static string GetMessage(string name)
        {
            var resourceManager = new ResourceManager(typeof(Messages));

            try
            {
                string returnValue = resourceManager.GetString(name, CultureInfo.CurrentCulture);

                if (!string.IsNullOrEmpty(returnValue))
                {
                    return returnValue;
                }
            }
            catch (Exception)
            {
                return "Resource Undefined";
            }

            return "Resource Undefined";
        }
    }
}
