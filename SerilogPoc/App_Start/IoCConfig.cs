using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core.Activators.Reflection;
using Autofac.Integration.Mvc;
using AutofacSerilogIntegration;
using Serilog;
using SerilogPoc.Data;
using SerilogWeb.Classic.Enrichers;

namespace SerilogPoc
{
    public static class IoCConfig
    {
        private static IContainer Container { get; set; }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            ConfigureSerilog(builder);
           
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterType<PlayerService>().AsImplementedInterfaces();

            Container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

        private static void ConfigureSerilog(ContainerBuilder builder)
        {
            var location = HttpRuntime.AppDomainAppPath;
            var file = File.CreateText(location + "\\serilogexceptions.log");

            Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));

            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.With<HttpRequestIdEnricher>()
                .WriteTo.Seq(ConfigurationManager.AppSettings["SeqUrl"])
                .CreateLogger();

            builder.RegisterLogger(logger);
        }
    }
}