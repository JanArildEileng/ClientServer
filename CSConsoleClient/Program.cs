// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;

Console.WriteLine("Hello, Client!");


HttpClient client=new HttpClient();

client.BaseAddress=new Uri("https://localhost:7076");


string response=await client.GetStringAsync("/");

Console.WriteLine($" Reponse from server /: {response}");



var info=await client.GetFromJsonAsync<CSShared.Dto.InfoData> ("/Info");

Console.WriteLine($" Reponse from server (Info): {info}");




Console.WriteLine("Goodbye!");