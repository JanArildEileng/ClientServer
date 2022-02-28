// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;
using System.Text.Json;
using CSConsoleclient.InfoTest;

Console.WriteLine("Hello, Client!");

HttpClient client=new HttpClient();
client.BaseAddress=new Uri("https://localhost:7076");

string response=await client.GetStringAsync("/");
Console.WriteLine($" Reponse from server /: {response}");

await InfoTester.GetFromJsonAsync(client);
await InfoTester.ReadFromJsonAsync(client);
await InfoTester.InvalidPathGetFromJsonAsync(client);

try {
    await InfoTester.InvalidServerReadFromJsonAsync();
} catch (Exception ex) {
    Console.WriteLine($"InvalidServerReadFromJsonAsync  ex={ex.Message}");
}

Console.WriteLine("Goodbye!");