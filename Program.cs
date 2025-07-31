using System;
using System.IO;
using System.Text.Json;

public class Room
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Dictionary<string, string>? Exits { get; set; }
    public List<Inspect>? Inspects { get; set; }
}

public class Inspect
{
    public string? Item { get; set; }
    public string? Description { get; set; }
}

public class Program
{
    private static Room? currentRoom;
    private static string basePath = Path.Combine(Directory.GetCurrentDirectory(), "rooms");

    public static void Main(string[] args)
    {
        LoadRoom("room1.json");
        GameLoop();
    }

    private static void GameLoop()
    {
        while (true)
        {
            Console.WriteLine(currentRoom?.Description);
            Console.Write("> ");
            string? command = Console.ReadLine();
            if (string.IsNullOrEmpty(command))
            {
                continue;
            }

            string[] parts = command.Split(' ');
            string verb = parts[0].ToLower();
            string? noun = parts.Length > 1 ? parts[1].ToLower() : null;

            if (verb == "quit")
            {
                break;
            }
            else if (verb == "go")
            {
                if (noun != null && currentRoom?.Exits != null && currentRoom.Exits.ContainsKey(noun))
                {
                    LoadRoom(currentRoom.Exits[noun]);
                }
                else
                {
                    Console.WriteLine("You can't go that way.");
                }
            }
            else
            {
                Console.WriteLine("I don't understand that command.");
            }
        }
    }

    private static void LoadRoom(string roomFileName)
    {
        string path = Path.Combine(basePath, roomFileName);
        string json = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        currentRoom = JsonSerializer.Deserialize<Room>(json, options);
    }
}
