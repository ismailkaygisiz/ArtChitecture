using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;

namespace Core.CrossCuttingConcerns.Logging.SeriLog.Loggers
{
    public class MsSqlLogger : LoggerServiceBase
    {
        public MsSqlLogger()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            var logConfig = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
                                .Get<MsSqlConfiguration>() ??
                            throw new Exception("");
            var sinkOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true };

            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Message);
            columnOpts.Store.Remove(StandardColumn.Properties);

            Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(logConfig.ConnectionString, sinkOpts, columnOptions: columnOpts)
                .CreateLogger();
        }
    }

    internal class MsSqlConfiguration
    {
        public string ConnectionString { get; set; }
    }
}