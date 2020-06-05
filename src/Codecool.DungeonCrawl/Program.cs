using System;
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
        private TextField _additionalText;
        private Sprite _mapContainer;
        private Sprite _actorsContainer;
        private Sprite _playerGfx;
        private Stage _stage;

        /// <summary>
        /// Entry point
        /// </summary>
        public static void Main()
        {
            new Program();
        }

        /// <summary>
        /// Entry point
        /// </summary>

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
            Character player = (Character)_map.AllStuff[0];

            // Dictionary<string, Actor> allTiles = new Dictionary<string, Actor>();
            _stage = PerlinApp.Stage;
            _stage.EnterFrameEvent += StageOnEnterFrameEvent;

            //_stage.AddedToStage += IfCheckerOnEnterFrameEvent;
            _mapContainer = new Sprite();
            _stage.AddChild(_mapContainer);
            DrawMap();

            _actorsContainer = new Sprite();
            _stage.AddChild(_actorsContainer);
            DrawActors();

            // health textField *************** o co kaman
            _healthTextField = new TextField(
                PerlinApp.FontRobotoMono.CreateFont(18),
                player.Health.ToString(),
                false);
            _healthTextField.HorizontalAlign = HorizontalAlignment.Left;
            _healthTextField.Width = 100;
            _healthTextField.Height = 30;
            _healthTextField.X = _map.Width * Tiles.TileWidth * (float)0.1;
            _stage.AddChild(_healthTextField);

            _additionalText = new TextField(
                PerlinApp.FontRobotoMono.CreateFont(12),
                " ",
                false);
            _additionalText.HorizontalAlign = HorizontalAlignment.Center;
            _additionalText.Width = 300;
            _additionalText.Height = 30;
            _additionalText.X = _map.Width * Tiles.TileWidth / 4;
            _stage.AddChild(_additionalText);

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

        private void DrawActors()
        {
            _actorsContainer.RemoveAllChildren();

            // List<Sprite> allSprites = new List<Sprite>;
            for (int i = 1; i < _map.AllStuff.Count; i++)
            {
                Actor singleStuff = _map.AllStuff[i];
                if (singleStuff.Cell.Equipment != null)
                {
                    System.Console.WriteLine(singleStuff.Cell.Equipment);
                    switch (singleStuff.Tilename)
                    {
                        case "Short sword":
                            Sprite swordGFX = new Sprite("tiles.png", false, Tiles.SwordTile);
                            System.Console.WriteLine("wskoczyl sword");
                            System.Console.WriteLine(singleStuff.Cell.GetCell());

                            // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
                            swordGFX.X = singleStuff.X * Tiles.TileWidth;
                            swordGFX.Y = singleStuff.Y * Tiles.TileWidth;
                            _actorsContainer.AddChild(swordGFX);
                            break;
                        case "Golden Key":
                            Sprite graphicGFX = new Sprite("tiles.png", false, Tiles.KeyTile);
                            System.Console.WriteLine("wskoczyl klucz");

                            // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
                            graphicGFX.X = singleStuff.X * Tiles.TileWidth;
                            graphicGFX.Y = singleStuff.Y * Tiles.TileWidth;
                            _actorsContainer.AddChild(graphicGFX);
                            break;
                        default:
                            System.Console.WriteLine("default case in gfx switch");
                            break;
                    }
                }

                if (singleStuff.Cell.Actor != null)
                {
                    switch (singleStuff.Tilename)
                    {
                        case "Skeleton":
                            var graphicGFX = new Sprite("tiles.png", false, Tiles.SkeletonTile);

                            // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
                            graphicGFX.X = singleStuff.X * Tiles.TileWidth;
                            graphicGFX.Y = singleStuff.Y * Tiles.TileWidth;
                            _actorsContainer.AddChild(graphicGFX);
                            break;
                        default:
                            //System.Console.WriteLine("default case in gfx switch");
                            break;
                    }
                }
            }

            _playerGfx = new Sprite("tiles.png", false, Tiles.PlayerTile);
            _playerGfx.X = _map.AllStuff[0].X * Tiles.TileWidth;
            _playerGfx.Y = _map.AllStuff[0].Y * Tiles.TileWidth;
            _actorsContainer.AddChild(_playerGfx);

            //foreach (Actor singleStuff in _map.AllStuff)
            //{
            //    if (singleStuff.Cell.Equipment != null)
            //    {
            //        System.Console.WriteLine(singleStuff.Cell.Equipment);
            //        switch (singleStuff.Tilename)
            //        {
            //            case "Short sword":
            //                Sprite swordGFX = new Sprite("tiles.png", false, Tiles.SwordTile);
            //                System.Console.WriteLine("wskoczyl sword");
            //                System.Console.WriteLine(singleStuff.Cell.GetCell());

            //                // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
            //                swordGFX.X = singleStuff.X * Tiles.TileWidth;
            //                swordGFX.Y = singleStuff.Y * Tiles.TileWidth;
            //                _actorsContainer.AddChild(swordGFX);
            //                break;
            //            case "Golden Key":
            //                Sprite graphicGFX = new Sprite("tiles.png", false, Tiles.KeyTile);
            //                System.Console.WriteLine("wskoczyl klucz");

            //                // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
            //                graphicGFX.X = singleStuff.X * Tiles.TileWidth;
            //                graphicGFX.Y = singleStuff.Y * Tiles.TileWidth;
            //                _actorsContainer.AddChild(graphicGFX);
            //                break;
            //            default:
            //                System.Console.WriteLine("default case in gfx switch");
            //                break;
            //        }
            //    }

            //    if (singleStuff.Cell.Actor != null)
            //    {
            //        switch (singleStuff.Tilename)
            //        {
            //            case "Skeleton":
            //                var graphicGFX = new Sprite("tiles.png", false, Tiles.SkeletonTile);

            //                // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
            //                graphicGFX.X = singleStuff.X * Tiles.TileWidth;
            //                graphicGFX.Y = singleStuff.Y * Tiles.TileWidth;
            //                _actorsContainer.AddChild(graphicGFX);
            //                break;
            //            case "Player":
            //                _playerGfx = new Sprite("tiles.png", false, Tiles.PlayerTile);

            //                // allSprites.Add(new Sprite("tiles.png", false, Tiles.SkeletonTile));
            //                _playerGfx.X = singleStuff.X * Tiles.TileWidth;
            //                _playerGfx.Y = singleStuff.Y * Tiles.TileWidth;
            //                _actorsContainer.AddChild(_playerGfx);
            //                break;
            //            default:
            //                //System.Console.WriteLine("default case in gfx switch");
            //                break;
            //        }
            //    }
            //}
        }

        //private void IfCheckerOnEnterFrameEvent(DisplayObject target)
        //{
        //    System.Console.WriteLine("fffffffffffffffffffff");

        //    _healthTextField.Text = "ffsadasdasdadsasdfffff";
        //}

        // this gets called every frame
        //public delegate void EnterFrame(DisplayObject target, float elapsedTimeSecs);
        private void StageOnEnterFrameEvent(DisplayObject target, float elapsedtimesecs)
        {
            Character player = (Character)_map.AllStuff[0];

            // process inputs
            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Up))
            {
                _map.AllStuff[0].Move(0, -1);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Down))
            {
                _map.AllStuff[0].Move(0, 1);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Left))
            {
                _map.AllStuff[0].Move(-1, 0);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Right))
            {
                _map.AllStuff[0].Move(1, 0);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Space))
            {
                _healthTextField.Text = "fffffff";
            }

            if (player.Cell.Equipment?.IsNotCollected ?? false)
            {
                _additionalText.Text = $"Collect it mutherfucker! {Environment.NewLine} (by clicking C of coz)";
                if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.C))
                {
                    System.Console.WriteLine("you collected item");
                    player.CollectItem();
                    DrawActors();
                }
            }
            else { _additionalText.Text = " "; }

            //render changes
            _playerGfx.X = _map.AllStuff[0].X * Tiles.TileWidth;
            _playerGfx.Y = _map.AllStuff[0].Y * Tiles.TileWidth;
        }
    }
}