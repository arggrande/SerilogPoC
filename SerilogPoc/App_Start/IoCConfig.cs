using System.Configuration;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutofacSerilogIntegration;
using Serilog;
using SerilogWeb.Classic.Enrichers;

namespace SerilogPoc
{
    public static class IoCConfig
    {
        private static IContainer Container { get; set; }

        public static void Configure()
        {
            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.With<HttpRequestIdEnricher>()
                .WriteTo.Seq(ConfigurationManager.AppSettings["SeqUrl"])
                .CreateLogger();

            var builder = new ContainerBuilder();
            builder.RegisterLogger(logger);
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}