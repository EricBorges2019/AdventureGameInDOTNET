# MyFirstDotNet

This is a simple .NET console application, seemingly the start of a text-based adventure game.

## File Structure

*   `MyFirstDotNet.csproj`: The C# project file. It defines project settings and dependencies.
*   `Program.cs`: The main entry point for the application.
*   `rooms/`: This directory contains JSON files that define the rooms in the game.
    *   `room1.json`: An example room file.

## Getting Started

To run this project, you need to have the .NET 8 SDK installed.

1.  Clone the repository.
2.  Open a terminal in the root directory of the repository.
3.  Run the application using the following command:

    ```bash
    dotnet run
    ```

## Gameplay

The game is a simple text-based adventure where you can move between rooms.

### Commands

*   `go <direction>`: Move to a different room. The available directions depend on the current room.
*   `quit`: Exit the game.

## Room Data

The room data is stored in JSON files in the `rooms/` directory. Each file represents a single room and has the following structure:

```json
{
    "name": "Room Name",
    "description": "A description of the room.",
    "exits": {
        "direction": "room_file.json"
    },
    "inspects": [
        {
            "item": "item_name",
            "description": "The description of the item when inspected."
        }
    ]
}
```
