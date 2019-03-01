using Microsoft.AspNetCore.Hosting;
using Pki.eBusiness.ErpApi.Web.Models;

namespace Pki.eBusiness.ErpApi.Entities.Extensions
{
    public static class EnvironmentExtentions
    {
        public static bool IsInt(this IHostingEnvironment env) => env.IsEnvironment(StandardEnvirotnment.Int);

        public static bool IsLocalhost(this IHostingEnvironment env) => env.IsEnvironment(StandardEnvirotnment.Localhost);
    }
}
