// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;
using System.Text.Json;


Console.WriteLine("Hello, Client!");


HttpClient client=new HttpClient();

client.BaseAddress=new Uri("https://localhost:7076");


string response=await client.GetStringAsync("/");

Console.WriteLine($" Reponse from server /: {response}");




var info=await client.GetFromJsonAsync<CSShared.Dto.InfoData> ("/Info");

var options = new JsonSerializerOptions { WriteIndented = true };


Console.WriteLine($" Reponse from server (Info): { JsonSerializer.Serialize(info,options)}");




Console.WriteLine("Goodbye!");