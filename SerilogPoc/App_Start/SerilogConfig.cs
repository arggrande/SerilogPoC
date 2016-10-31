using System.Configuration;
using Serilog;

namespace SerilogPoc
{
    public static class SerilogConfig
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq(ConfigurationManager.AppSettings["SeqUrl"])
                .CreateLogger();
        }
    }
}