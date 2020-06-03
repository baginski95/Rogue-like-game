using System.Collections;
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
            //co to jest*********************************
            var stage = PerlinApp.Stage;
            stage.EnterFrameEvent += StageOnEnterFrameEvent;

            _mapContainer = new Sprite();
            stage.AddChild(_mapContainer);
            DrawMap();

            // health textField *************** o co kaman
            _healthTextField = new TextField(
                PerlinApp.FontRobotoMono.CreateFont(18),
                _map.Player.Health.ToString(),
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

            foreach (Skeleton skeleton in _map.Skeletons)
            {
                System.Console.WriteLine("foreach");
                var skeletonGfx = new Sprite("tiles.png", false, Tiles.SkeletonTile);

                skeletonGfx.X = skeleton.X * Tiles.TileWidth;
                skeletonGfx.Y = skeleton.Y * Tiles.TileWidth;
                stage.AddChild(skeletonGfx);
            }

            //var skeletonGfx = new Sprite("tiles.png", false, Tiles.SkeletonTile);

            //skeletonGfx.X = _map.Skeleton.X * Tiles.TileWidth;
            //skeletonGfx.Y = _map.Skeleton.Y * Tiles.TileWidth;
            //stage.AddChild(skeletonGfx);

            //var skeletonGfx1 = new Sprite("tiles.png", false, Tiles.SkeletonTile);
            //skeletonGfx1.X = _map.Skeleton1.X * Tiles.TileWidth;
            //skeletonGfx1.Y = _map.Skeleton1.Y * Tiles.TileWidth;
            //stage.AddChild(skeletonGfx1);

            _playerGfx = new Sprite("tiles.png", false, Tiles.PlayerTile);
            stage.AddChild(_playerGfx);

            var swordGfx = new Sprite("tiles.png", false, Tiles.SwordTile);
            swordGfx.X = _map.Sword.X * Tiles.TileWidth;
            swordGfx.Y = _map.Sword.Y * Tiles.TileWidth;
            stage.AddChild(swordGfx);

            var keyGfx = new Sprite("tiles.png", false, Tiles.KeyTile);
            keyGfx.X = _map.Key.X * Tiles.TileWidth;
            keyGfx.Y = _map.Key.Y * Tiles.TileWidth;
            stage.AddChild(keyGfx);
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
            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Up))
            {
                _map.Player.Move(0, -1);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Down))
            {
                _map.Player.Move(0, 1);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Left))
            {
                _map.Player.Move(-1, 0);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Veldrid.Key.Right))
            {
                _map.Player.Move(1, 0);
            }

            // render changes
            _playerGfx.X = _map.Player.X * Tiles.TileWidth;
            _playerGfx.Y = _map.Player.Y * Tiles.TileWidth;
        }
    }
}