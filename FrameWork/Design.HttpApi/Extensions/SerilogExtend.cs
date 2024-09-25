using System.Data;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace DesignAspNetCore.Extensions
{
    public static class SerilogExtend
    {
        public static void AddSerilog(this ConfigureHostBuilder configureHostBuilder)
        {
            // 配置Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // 排除Microsoft的日志
                //.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)//efCore 日志
                .Enrich.FromLogContext() // 注册日志上下文
                .WriteTo.MSSqlServer("Server=.;Database=NewAbp;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;", sinkOptions: GetSqlServerSinkOptions(), columnOptions: GetColumnOptions())
                .WriteTo.Async(c => c.File(path: "Logs/logs.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: null))
                .WriteTo.Async(c => c.Console()).CreateLogger();
            configureHostBuilder.UseSerilog(Log.Logger); // 注册serilog
            //设置日志sqlserver配置
            MSSqlServerSinkOptions GetSqlServerSinkOptions()
            {
                var sqlsinkotpions = new MSSqlServerSinkOptions
                {
                    TableName = "Serilog",//表名称
                    SchemaName = "dbo",//数据库模式
                    AutoCreateSqlTable = true//是否自动创建表
                };
                return sqlsinkotpions;
            }
            // 设置日志sqlserver 列配置
            ColumnOptions GetColumnOptions()
            {
                var customColumnOptions = new ColumnOptions();
                customColumnOptions.Store.Remove(StandardColumn.MessageTemplate);//删除多余的这两列
                customColumnOptions.Store.Remove(StandardColumn.Properties);
                var columList = new List<SqlColumn>
                {
                    new SqlColumn("Url", SqlDbType.NVarChar, true, 200),// 记录请求地址
                    new SqlColumn("HttpMethod", SqlDbType.NVarChar, true, 200),// 记录请求方式
                    new SqlColumn("RequestJson", SqlDbType.NVarChar, true, 2000),//添加一列，用于记录请求参数string
                    new SqlColumn("HttpStatusCode", SqlDbType.Int, true),//请求状态码
                    new SqlColumn("ResponseJson", SqlDbType.NVarChar, true),//添加一列，用于记录响应数据
                    new SqlColumn("ExceptionMessage", SqlDbType.NVarChar, true),//添加一列，用于记录响应数据
                    new SqlColumn("TotalMilliseconds", SqlDbType.NVarChar, true, 500)//总请求时间
                };
                customColumnOptions.AdditionalColumns = columList;
                return customColumnOptions;
            }
        }
    }
}
