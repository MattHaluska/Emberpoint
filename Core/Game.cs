﻿using SadConsole;
using Microsoft.Xna.Framework;
using Emberpoint.Core.Objects;

namespace Emberpoint.Core
{
    public static class Game
    {
        public static Console Map { get; private set; }
        private static EmberGrid Grid { get; set; }

        private static void Main()
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create(120, 40);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Start the game.
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private static void Init()
        {
            Map = new Console(70, 30);
            SetMapArea(70, 30);

            var mainConsole = new Console(120, 40);
            mainConsole.Children.Add(Map);
            mainConsole.Print(60 - "Emberpoint".Length / 2, 2, "Emberpoint");

            Map.Position = new Point(25, 5);

            // Instantiate player in the middle of the map
            var player = new Player(new Point(35, 15));
            player.RenderObject(Map);

            Global.CurrentScreen = mainConsole;
        }

        private static void SetMapArea(int gridSizeX, int gridSizeY)
        {
            var cells = new EmberCell[gridSizeX * gridSizeY];
            for (int x=0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    cells[y * gridSizeX + x] = new EmberCell(new Point(x, y), '.', Color.Green);
                }
            }
            Grid = new EmberGrid(gridSizeX, gridSizeY, cells);
            Grid.RenderObject(Map);
        }
    }
}