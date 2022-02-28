using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace CSConsoleclient.InfoTest;

public class InfoTester {

     static string path="/info";
     static string invalidpath="/invalid";
     
      static JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

     public static async Task GetFromJsonAsync(HttpClient client,ILogger logger) {
        var info=await client.GetFromJsonAsync<CSShared.Dto.InfoData> (path);
        var options = new JsonSerializerOptions { WriteIndented = true };
         logger.LogInformation($"InfoTester:GetFromJsonAsync  from server {path}:: { JsonSerializer.Serialize(info,options)}");   
     }

    public static async Task ReadFromJsonAsync(HttpClient client) {
        var httpResponseMessage=await client.GetAsync(path);

        if ( httpResponseMessage.IsSuccessStatusCode) {
            var infoData = await httpResponseMessage.Content.ReadFromJsonAsync<CSShared.Dto.InfoData>();
            Console.WriteLine($"InfoTester:ReadFromJsonAsync  from server {path}: { JsonSerializer.Serialize(infoData ,options)}");
        }  else {
            Console.WriteLine($"Something wrong: { httpResponseMessage.StatusCode}");
        }
    }

  public static async Task InvalidPathGetFromJsonAsync(HttpClient client) {

      try  {
          var info=await client.GetFromJsonAsync<CSShared.Dto.InfoData> (invalidpath);
          Console.WriteLine($"InfoTester:GetFromJsonAsync  from server {path}:: { JsonSerializer.Serialize(info,options)}");   
      } catch (HttpRequestException ex) {
             Console.WriteLine($"HttpRequestException:  StatusCode={ ex.StatusCode}  { ex.Message} ");
      }  
       catch (Exception ex) {
             Console.WriteLine($"Something wrong:  { ex.GetType() }  { ex.Message} ");
      }  

    }

public static async Task<CSShared.Dto.InfoData> InvalidServerReadFromJsonAsync() {

        var client=new HttpClient();
        client.BaseAddress=new Uri("https://localhost:17076");
             

      try  {
           var httpResponseMessage=await client.GetAsync(path);

           httpResponseMessage.EnsureSuccessStatusCode();
           var infoData = await httpResponseMessage.Content.ReadFromJsonAsync<CSShared.Dto.InfoData>();
           Console.WriteLine($"InfoTester:ReadFromJsonAsync  from server {path}: { JsonSerializer.Serialize(infoData ,options)}");
           return infoData;
      } catch (HttpRequestException ex) {
             Console.WriteLine($"HttpRequestException:  { ex.Message} ");
             throw ;
      }  
       catch (Exception ex) {
             Console.WriteLine($"Something wrong:  { ex.GetType() }  { ex.Message} ");
             throw;
      }  

    }

}
