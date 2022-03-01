// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;
using System.Text.Json;
using CSConsoleclient.InfoTest;
using Serilog;
//using Serilog.Extensions.Logging;
using Microsoft.Extensions.Logging;



var serilogLogger= new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();


//Microsoft.Extensions.Logging.ILogger logger= new SerilogLoggerFactory(serilogLogger).CreateLogger("cat1"); 
 var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
              .AddConsole()
              .AddSerilog(serilogLogger);
        });
 //Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger<Program>();
  Microsoft.Extensions.Logging.ILogger logger = loggerFactory.CreateLogger("CS");
 logger.LogInformation("Example log message");

logger.LogInformation("Hello, Client!");

HttpClient client=new HttpClient();
client.BaseAddress=new Uri("https://localhost:7076");

string response=await client.GetStringAsync("/");
logger.LogInformation($" Reponse from server /: {response}");

await InfoTester.GetFromJsonAsync(client,logger);
await InfoTester.ReadFromJsonAsync(client);
await InfoTester.InvalidPathGetFromJsonAsync(client);

try {
    await InfoTester.InvalidServerReadFromJsonAsync();
} catch (Exception ex) {
    logger.LogError($"InvalidServerReadFromJsonAsync  ex={ex.Message}");
}

GoodByeClass goodByeClass=new GoodByeClass(loggerFactory.CreateLogger<GoodByeClass>() );


//logger.LogInformation("Goodbye!");


public class GoodByeClass {

   string message="Good Bye";

   public GoodByeClass(Microsoft.Extensions.Logging.ILogger<GoodByeClass> logger)
   {
       logger.LogInformation(message);
   }   
}