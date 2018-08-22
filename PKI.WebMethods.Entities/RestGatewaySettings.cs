using System.Configuration;

namespace PKI.eBusiness.WMService.Entities
{
    public static class RestGatewaySettings
    {
        /// <summary>
        /// Get a settings section of a given type TSettings located at the given path.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="settingsPath"></param>
        /// <returns></returns>
        public static TSettings GetElement<TSettings>(string settingsPath) where TSettings : ConfigurationElement
        {
            var config = ConfigurationManager.GetSection(settingsPath) as TSettings;

            return config;
        }

    }
}
