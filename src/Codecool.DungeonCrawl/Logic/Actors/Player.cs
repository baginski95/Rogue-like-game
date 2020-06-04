using System.Collections.Generic;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    /// The game player
    /// </summary>
    public class Player : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="cell">The starting cell</param>
        public Player(Cell cell)
            : base(cell)
        {
        }

        /// <inheritdoc/>
        public override string Tilename => "Player";

        /// <inheritdoc/>
        public override bool IsNotPassable => false;

        /// <inheritdoc/>
        public override void CollectItem()
        {
            System.Console.WriteLine("collected!! ");
            Cell currentCell = Cell.GetCell();
            currentCell.Equipment = null;
        }
    }
}