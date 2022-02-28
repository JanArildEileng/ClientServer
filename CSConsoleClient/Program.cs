// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;

Console.WriteLine("Hello, Client!");


HttpClient client=new HttpClient();

client.BaseAddress=new Uri("https://localhost:7076");


string response=await client.GetStringAsync("/");

Console.WriteLine($" Reponse from server: {response}");



Console.WriteLine("Goodbye!");
