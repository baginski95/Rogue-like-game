using System.Collections;
using System.Collections.Generic;
using System.IO;
using Codecool.DungeonCrawl.Logic;
using Codecool.DungeonCrawl.Logic.Actors;
using Perlin;
using Perlin.Display;
using SixLabors.Fonts;
using Veldrid;

namespace Codecool.DungeonCrawl
{
    /// <summary>
    /// The main class and entry point.
    /// </summary>
    public class Program
    {
        private GameMap _map;
        private TextField _healthTextField;
        private Sprite _mapContainer;
        private Sprite _playerGfx;

        /// <summary>
        /// Entry point
        /// </summary>
        public static void Main()
        {
            new Program();
        }

        private Program()
        {
            _map = MapLoader.LoadMap();
            PerlinApp.Start(_map.Width * Tiles.TileWidth,
                _map.Height * Tiles.TileWidth,
                "Dungeon Crawl",
                OnStart);
        }

        private void OnStart()
        {
            int allStuffLeng = (_map.AllStuff.Count) - 1;
            Character player = (Character)_map.AllStuff[allStuffLeng];

            // Dictionary<string, Actor> allTiles = new Dictionary<string, Actor>();
            var stage = PerlinApp.Stage;
            stage.EnterFrameEvent += StageOnEnterFrameEvent;

            _mapContainer = new Sprite();
            stage.AddChild(_mapContainer);
            DrawMap();

            // List<Sprite> allSprites = new List<Sprite>;
            foreach (Actor singleStuff in _map.AllStuff)
            {
                switch (singleStuff.Tilename)
                {
                    case "Skeleton":
                        var graphicGFX = new Sprite("tiles.png", false, Tiles.SkeletonTile);

                        // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
                        graphicGFX.X = singleStuff.X * Tiles.TileWidth;
                        graphicGFX.Y = singleStuff.Y * Tiles.TileWidth;
                        stage.AddChild(graphicGFX);
                        break;
                    case "Player":
                        _playerGfx = new Sprite("tiles.png", false, Tiles.PlayerTile);

                        // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
                        _playerGfx.X = singleStuff.X * Tiles.TileWidth;
                        _playerGfx.Y = singleStuff.Y * Tiles.TileWidth;
                        stage.AddChild(_playerGfx);
                        break;
                    case "Short sword":
                        graphicGFX = new Sprite("tiles.png", false, Tiles.SwordTile);
                        System.Console.WriteLine("wskoczyl sword");

                        // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
                        graphicGFX.X = singleStuff.X * Tiles.TileWidth;
                        graphicGFX.Y = singleStuff.Y * Tiles.TileWidth;
                        stage.AddChild(graphicGFX);
                        break;
                    case "Golden Key":
                        graphicGFX = new Sprite("tiles.png", false, Tiles.KeyTile);
                        System.Console.WriteLine("wskoczyl sword");

                        // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
                        graphicGFX.X = singleStuff.X * Tiles.TileWidth;
                        graphicGFX.Y = singleStuff.Y * Tiles.TileWidth;
                        stage.AddChild(graphicGFX);
                        break;
                    default:
                        System.Console.WriteLine("default case in gfx switch");
                        break;
                }
            }

            // health textField *************** o co kaman
            _healthTextField = new TextField(
                PerlinApp.FontRobotoMono.CreateFont(18),
                player.Health.ToString(),
                false);
            _healthTextField.HorizontalAlign = HorizontalAlignment.Center;
            _healthTextField.Width = 100;
            _healthTextField.Height = 20;
            _healthTextField.X = _map.Width * Tiles.TileWidth / 2 - 50;
            stage.AddChild(_healthTextField);

            //********************************
            //Czy da się w tym kontekscie uzyc FORa
            //for (int i = 0; i < _map.Skeletons.Count; i++)
            //{
            //    var skeletonGfx = new Sprite("tiles.png", false, Tiles.SkeletonTile);

            //    skeletonGfx.X = _map.Skeletons[i].X * Tiles.TileWidth;
            //    skeletonGfx.Y = _map.Skeletons[i].Y * Tiles.TileWidth;
            //    stage.AddChild(skeletonGfx);
            //}

            //foreach (Actor single_entity in _map.AllStuff)
            //{
            //    string tileName = "Tiles."+
            //    System.Console.WriteLine("foreach");
            //    var object = new Sprite("tiles.png", false, Tiles.SkeletonTile);

            //    skeletonGfx.X = skeleton.X * Tiles.TileWidth;
            //    skeletonGfx.Y = skeleton.Y * Tiles.TileWidth;
            //    stage.AddChild(skeletonGfx);
            //}

            //var skeletonGfx = new Sprite("tiles.png", false, Tiles.SkeletonTile);

            //skeletonGfx.X = _map.Skeleton.X * Tiles.TileWidth;
            //skeletonGfx.Y = _map.Skeleton.Y * Tiles.TileWidth;
            //stage.AddChild(skeletonGfx);

            //var skeletonGfx1 = new Sprite("tiles.png", false, Tiles.SkeletonTile);
            //skeletonGfx1.X = _map.Skeleton1.X * Tiles.TileWidth;
            //skeletonGfx1.Y = _map.Skeleton1.Y * Tiles.TileWidth;
            //stage.AddChild(skeletonGfx1);

            //_playerGfx = new Sprite("tiles.png", false, Tiles.PlayerTile);
            //stage.AddChild(_playerGfx);

            //var swordGfx = new Sprite("tiles.png", false, Tiles.SwordTile);
            //swordGfx.X = _map.Sword.X * Tiles.TileWidth;
            //swordGfx.Y = _map.Sword.Y * Tiles.TileWidth;
            //stage.AddChild(swordGfx);

            //var keyGfx = new Sprite("tiles.png", false, Tiles.KeyTile);
            //keyGfx.X = _map.Key.X * Tiles.TileWidth;
            //keyGfx.Y = _map.Key.Y * Tiles.TileWidth;
            //stage.AddChild(keyGfx);
        }

        private void DrawMap()
        {
            _mapContainer.RemoveAllChildren();
            for (int x = 0; x < _map.Width; x++)
            {
                for (int y = 0; y < _map.Height; y++)
                {
                    var cell = _map.GetCell(x, y);
                    var tile = Tiles.GetMapTile(cell);

                    // tiles are 16x16 pixels
                    var sp = new Sprite("tiles.png", false, tile);
                    sp.X = x * Tiles.TileWidth;
                    sp.Y = y * Tiles.TileWidth;
                    _mapContainer.AddChild(sp);
                }
            }
        }

        // this gets called every frame
        private void StageOnEnterFrameEvent(DisplayObject target, float elapsedtimesecs)
        {
            // process inputs
            int allStuffLeng = (_map.AllStuff.Count) - 1;
            Player player = (Player)_map.AllStuff[allStuffLeng];
            Cell cell = player.Cell;
            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Up))
            {
                _map.AllStuff[allStuffLeng].Move(0, -1);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Down))
            {
                _map.AllStuff[allStuffLeng].Move(0, 1);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Left))
            {
                _map.AllStuff[allStuffLeng].Move(-1, 0);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Right))
            {
                _map.AllStuff[allStuffLeng].Move(1, 0);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.C))
            {
                player.CollectItem();
            }

            if (cell.Equipment?.IsNotCollected ?? false)
            {
                System.Console.WriteLine("tutuaj!");
            }

            //render changes
            _playerGfx.X = _map.AllStuff[allStuffLeng].X * Tiles.TileWidth;
            _playerGfx.Y = _map.AllStuff[allStuffLeng].Y * Tiles.TileWidth;
        }
    }
}