using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await IPGeolocator();
    }

    static async Task IPGeolocator()
    {
        Console.Write("Enter IP address: ");
        string ip = Console.ReadLine();

        string url = $"http://ip-api.com/json/{ip}";

        using HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(url);

        JsonDocument doc = JsonDocument.Parse(response);
        JsonElement root = doc.RootElement;

        Console.WriteLine("\n=== IP GEOLOCATION ===\n");
        Console.WriteLine($"IP       : {root.GetProperty("query").GetString()}");
        Console.WriteLine($"Country  : {root.GetProperty("country").GetString()}");
        Console.WriteLine($"Region   : {root.GetProperty("regionName").GetString()}");
        Console.WriteLine($"City     : {root.GetProperty("city").GetString()}");
        Console.WriteLine($"ISP      : {root.GetProperty("isp").GetString()}");
        Console.WriteLine($"Lat      : {root.GetProperty("lat").GetDouble()}");
        Console.WriteLine($"Lon      : {root.GetProperty("lon").GetDouble()}");
    }
}