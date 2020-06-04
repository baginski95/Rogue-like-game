using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Actors
{ /// <summary>
  /// Class for all MOBs in game
  /// </summary>
    public abstract class Character : Actor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        /// <param name="cell">The starting cell</param>
        public Character(Cell cell)
            : base(cell)
        {
        }

        /// <summary>
        /// Gets this actors health
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Gets this actors health
        /// </summary>
        public List<Equipment> Inventory = new List<Equipment>();

        ///// <summary>
        ///// Moves this actor by the given amount
        ///// </summary>
        ///// <param name="dx">X amoount</param>
        ///// <param name="dy">Y amount</param>
        //public void Move(int dx, int dy)
        //{
        //    Cell nextCell = Cell.GetNeighbor(dx, dy);
        //    CellType cellType = nextCell.Type;

        //    //System.Console.WriteLine(nextCell.GameMap.Skeleton.GetType());

        //    // null propagation + null coalescing - jezeli aktor nie jest null to
        //    // zwracant IsPassable, a jesli nie to zwraca Actora.
        //    // Jesli null po lewej to zwroci null to zwraca to co po prawej
        //    if (nextCell.Actor?.IsNotPassable ?? false)
        //    { Console.WriteLine("strange if"); }
        //    else if (cellType == CellType.Wall)
        //    { Console.WriteLine("else if"); }
        //    else
        //    {
        //        Cell.Actor = null;
        //        nextCell.Actor = this;
        //        Cell = nextCell;
        //    }

        //    if (Cell.Equipment?.IsNotCollected ?? false)
        //    {
        //        Console.WriteLine("collected");
        //    }
        //}

        /// <summary>
        /// lorem ipsum
        /// </summary>
        public abstract void CollectItem();
    }
}
