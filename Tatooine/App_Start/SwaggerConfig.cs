using Swashbuckle.Application;
using System.Web.Http;
using Tatooine;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Tatooine
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Tatooine");
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
