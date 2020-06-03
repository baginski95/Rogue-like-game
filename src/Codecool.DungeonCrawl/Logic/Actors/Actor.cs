namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    /// Actor is a base class for every entity in the dungeon.
    /// </summary>
    public abstract class Actor : IDrawable
    {
        /// <summary>
        /// Gets or sets the cell where this actor is located
        /// </summary>
        public Cell Cell { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Actor"/> class.
        /// </summary>
        /// <param name="cell">The cell of this actor</param>
        public Actor(Cell cell)
        {
            Cell = cell;
            Cell.Actor = this;
        }

        /// <summary>
        /// Gets a value indicating whether initializes a new instance of the <see cref="Actor"/> class.
        /// </summary>
        public abstract bool IsNotPassable { get; }

        /// <summary>
        /// Gets the X position
        /// </summary>
        public int X => Cell.X;

        /// <summary>
        /// Gets the Y position
        /// </summary>
        public int Y => Cell.Y;

        /// <summary>
        /// Gets the name of this tile.
        /// </summary>
        public abstract string Tilename { get; }
    }
}