using Hilltop.Core.Web.Controllers.Helpers;
using Hilltop.Core.Web.Controllers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hilltop.Core.Web
{
    public static class RegistrationHelper
    {
        public static void UseHilltop(this IApplicationBuilder app)
        {
        }

        public static void AddHilltop(this IServiceCollection services)
        {
            services.AddSingleton<IModificationsRegistry, ModificationsRegistry>();
        }
    }
}