using System.Collections;
using System.Collections.Generic;
using Codecool.DungeonCrawl.Logic.Actors;

namespace Codecool.DungeonCrawl.Logic
{
    /// <summary>
    /// The game map
    /// </summary>
    public class GameMap
    {
        /// <summary>
        /// List with everything added to map
        /// </summary>
        public List<Actor> AllStuff = new List<Actor>();
        ///// <summary>
        ///// The player
        ///// </summary>
        //public Player Player;

        ///// <summary>
        ///// A sample enemy
        ///// </summary>
        //public Skeleton Skeleton1;

        ///// <summary>
        ///// A sample enemy
        ///// </summary>
        //public Skeleton Skeleton2;

        //// public Character Skeleton = new Skeleton

        ///// <summary>
        ///// A sample enemy arrayList
        ///// </summary>
        //public ArrayList Skeletons = new ArrayList();

        ///// <summary>
        ///// First key
        ///// </summary>
        //public Key Key;

        ///// <summary>
        ///// A basic weapon - Sword
        ///// </summary>
        //public Weapon Sword;
        private readonly Cell[,] _cells;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameMap"/> class.
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="defaultCellType">Default cell type</param>
        public GameMap(int width, int height, CellType defaultCellType)
        {
            Width = width;
            Height = height;
            _cells = new Cell[width, height];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    _cells[x, y] = new Cell(this, x, y, defaultCellType);
                }
            }
        }

        /// <summary>
        /// Gets the cell at the given coordinate
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>The cell</returns>
        public Cell GetCell(int x, int y) => _cells[x, y];

        /// <summary>
        /// Gets the width
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height
        /// </summary>
        public int Height { get; }
    }
}