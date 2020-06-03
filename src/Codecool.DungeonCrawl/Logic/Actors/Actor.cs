namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    /// Actor is a base class for every entity in the dungeon.
    /// </summary>
    public abstract class Actor : IDrawable
    {
        /// <summary>
        /// Gets the cell where this actor is located
        /// </summary>
        public Cell Cell { get; private set; }

        /// <summary>
        /// Gets this actors health
        /// </summary>
        public int Health { get; private set; }

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
        public abstract bool IsPassable { get; }

        /// <summary>
        /// Moves this actor by the given amount
        /// </summary>
        /// <param name="dx">X amoount</param>
        /// <param name="dy">Y amount</param>
        public void Move(int dx, int dy)
        {
            Cell nextCell = Cell.GetNeighbor(dx, dy);
            CellType cellType = nextCell.Type;
            System.Console.WriteLine(nextCell.GameMap.Skeleton.GetType());

            // null propagation + null coalescing - jezeli aktor nie jest null to
            // zwracant IsPassable, a jesli nie to zwraca Actora.
            // Jesli null po lewej to zwroci null to zwraca to co po prawej
            if (nextCell.Actor?.IsPassable ?? false)
            { }
            else if (cellType == CellType.Wall)
            { }
            else
            {
                Cell.Actor = null;
                nextCell.Actor = this;
                Cell = nextCell;
            }
        }

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