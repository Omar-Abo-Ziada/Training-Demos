using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;
using System.Runtime.CompilerServices;

namespace Loggin_Console_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region logging types

            //    // Setup dependency injection and logging
            //    var serviceProvider = new ServiceCollection()
            //        .AddLogging(configure =>
            //        configure.SetMinimumLevel(LogLevel.Trace)
            //        .AddConsole()
            //        )
            //        .BuildServiceProvider();

            //    // Get the logger instance
            //    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            //    var product = new
            //    {
            //        Id = 1,
            //        Price = 50,
            //    };

            //    // Log messages at different levels
            //    logger.LogTrace($"Product Id : {product.Id} , Price : {product.Price}");
            //    logger.LogTrace("This is a TRACE level log - very detailed.");
            //    logger.LogTrace("This is a TRACE level log - very detailed.");
            //    logger.LogDebug("This is a DEBUG level log - for debugging.");
            //    logger.LogInformation("This is an INFORMATION log - general app flow.");
            //    logger.LogWarning("This is a WARNING log - something might go wrong.");
            //    logger.LogError("This is an ERROR log - something went wrong.");
            //    logger.LogCritical("This is a CRITICAL log - system crash!");

            //    // Simulate some application logic and log an exception
            //    try
            //    {
            //        int result = 10 / int.Parse("0"); // This will throw
            //    }
            //    catch (Exception ex)
            //    {
            //        logger.LogError(ex, "An exception occurred while dividing numbers.");
            //    }

            //    Console.WriteLine("Application has completed. Check the logs above.");
            #endregion

            #region loggin into text file and recent 7 days logs
            ////// Setup Serilog and logging
            ////Log.Logger = new LoggerConfiguration()
            ////    .MinimumLevel.Debug() // Ensure the minimum log level is Debug (will include Trace and Debug)
            ////    .WriteTo.Console()    // Log to console
            ////    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day) // Log to file
            ////    .CreateLogger();

            //// Setup Serilog with log file size and rolling interval
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Is(LogEventLevel.Debug)  // Set minimum log level
            //    .WriteTo.Console()     // Log to console
            //    .WriteTo.File("log.txt",
            //        rollingInterval: RollingInterval.Day,  // Create new file every day
            //        fileSizeLimitBytes: 10_000_000,         // Set file size limit (10MB)
            //        retainedFileCountLimit: 7,              // Keep only 7 old log files (max)
            //        rollOnFileSizeLimit: true)           // Enable rolling on file size limit
            //    .CreateLogger();

            //// Setup dependency injection
            //var serviceProvider = new ServiceCollection()
            //    .AddLogging(builder =>
            //    {
            //        builder.AddSerilog(); // Use Serilog as the logging provider
            //    })
            //    .BuildServiceProvider();

            //// Get the logger instance
            //var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            //// Log messages at different levels
            //logger.LogTrace("This is a TRACE level log - very detailed.");
            //logger.LogDebug("This is a DEBUG level log - for debugging.");
            //logger.LogInformation("This is an INFORMATION log - general app flow.");
            //logger.LogWarning("This is a WARNING log - something might go wrong.");
            //logger.LogError("This is an ERROR log - something went wrong.");
            //logger.LogCritical("This is a CRITICAL log - system crash!");

            //// Simulate some application logic and log an exception
            //try
            //{
            //    int result = 10 / int.Parse("0"); // This will throw
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, "An exception occurred while dividing numbers.");
            //}

            //Console.WriteLine("Application has completed. Check the logs above.");

            //// Ensure logs are flushed before the application exits
            //Log.CloseAndFlush(); 
            #endregion

            #region Log Enrichemnts Props && Write into json files

            /* Log Enrichment (Adding Custom Data)
                What is Log Enrichment?: Enriching logs with additional contextual information (like request ID, user ID, machine name) is important for troubleshooting and monitoring in production environments.
                Example of Enriching Logs in Serilog:
                You can add extra properties to each log message. For example, including the request ID, session ID, or any other relevant data.*/

            /*Contextual Information: The "ApplicationName" property will be attached to every log entry. 
             * This is helpful because you can include metadata like the application name, environment 
             * (e.g., "Development", "Production"), 
             * or other relevant identifiers that provide more context for each log entry.*/


            // NOTE : Serila log by default doesnt show prop .. so u have to configure the template like this :
            //Log.Logger = new LoggerConfiguration()
            //                            .Enrich.WithProperty("ApplicationName", "MyApp")
            //                            .Enrich.WithProperty("Environment", "Development")
            //                            .Enrich.WithMachineName() // Automatically adds machine name to each log entry
            //                            .Enrich.WithThreadId()    // Adds Thread ID to logs
            //                            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message} Application: {ApplicationName}, Environment: {Environment}, Machine: {MachineName}, ThreadId: {ThreadId}{NewLine}{Exception}")
            //                            .WriteTo.File("Log.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message} Application: {ApplicationName}, Environment: {Environment}, Machine: {MachineName}, ThreadId: {ThreadId}{NewLine}{Exception}")
            //                            .WriteTo.File("log.json", rollingInterval: RollingInterval.Day, outputTemplate: "{\"Timestamp\":\"{Timestamp:yyyy-MM-dd HH:mm:ss}\",\"Level\":\"{Level:u3}\",\"Message\":\"{Message}\",\"Application\":\"{ApplicationName}\",\"Environment\":\"{Environment}\",\"Exception\":\"{Exception}\"}")
            //                            .CreateLogger();

            //var serviceProvider = new ServiceCollection()
            //    .AddLogging(builder =>
            //                    builder.AddSerilog()
            //                    .AddConsole())
            //                    .BuildServiceProvider();

            //var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            //logger.LogInformation("test info 1");
            //logger.LogCritical("test critical 2");
            //logger.LogWarning("test warning 3");
            //logger.LogDebug("test debug 4");
            //logger.LogError("test errpr 4");

            //Log.CloseAndFlush();

            // Setup Serilog with proper JSON formatting for File and Console output
            //Log.Logger = new LoggerConfiguration()
            //    .Enrich.WithProperty("ApplicationName", "MyApp")
            //    .Enrich.WithProperty("Environment", "Development")
            //     .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message} Application: {ApplicationName}, Environment: {Environment}, Machine: {MachineName}, ThreadId: {ThreadId}{NewLine}{Exception}")
            //    //  .WriteTo.File("log.json", rollingInterval: RollingInterval.Day, outputTemplate: "{\"Level\":\"{Level:u3}\",\"Message\":\"{Message}\",\"Application\":\"{ApplicationName}\",\"Environment\":\"{Environment}\",\"Exception\":\"{Exception}\"}")
            //    .WriteTo.Sink(new JsonArrayFileSink("log.json"))
            //     .CreateLogger();

            Log.Logger = new LoggerConfiguration()
            .Enrich.WithProperty("ApplicationName", "MyApp")
            .Enrich.WithProperty("Environment", "Development")
            .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message} Application: {ApplicationName}, Environment: {Environment}{NewLine}{Exception}")
            .WriteTo.File("log.json", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message} Application: {ApplicationName}, Environment: {Environment}{NewLine}{Exception}")
            .CreateLogger();


            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddSerilog())
                .BuildServiceProvider();

            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            // Log messages
            logger.LogInformation("test info 1");
            logger.LogCritical("test critical 2");
            logger.LogWarning("test warning 3");
            logger.LogError("test error 4");

            // Ensure logs are flushed before the application exits
            Log.CloseAndFlush();

            #endregion
        }
    }

    // Custom sink to log messages as a JSON array
    public class JsonArrayFileSink : ILogEventSink
    {
        private readonly string _filePath;

        public JsonArrayFileSink(string filePath)
        {
            _filePath = filePath;
        }

        public void Emit(LogEvent logEvent)
        {
            var logEntry = logEvent.RenderMessage();
            var jsonLog = $"{{\"Level\":\"{logEvent.Level:u3}\",\"Message\":\"{logEntry}\",\"Application\":\"MyApp\",\"Environment\":\"Development\",\"Exception\":\"{logEvent.Exception?.Message ?? ""}\"}}";

            if (File.Exists(_filePath))
            {
                // Append the log entry to the file with a comma if the file exists and isn't empty
                var existingContent = File.ReadAllText(_filePath);
                if (!existingContent.Trim().EndsWith("]"))
                {
                    // If it's the first log entry, or the file is malformed, we need to add an opening bracket.
                    File.AppendAllText(_filePath, $"[{jsonLog}");
                }
                else
                {
                    File.AppendAllText(_filePath, $",{jsonLog}");
                }
            }
            else
            {
                // Create the file and start with an opening bracket
                File.WriteAllText(_filePath, $"[{jsonLog}");
            }
        }
    }
}