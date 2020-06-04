namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    /// Sample enemy
    /// </summary>
    public class Skeleton : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Skeleton"/> class.
        /// </summary>
        /// <param name="cell">The starting cell</param>
        /// DLACZEGO *********************************
        public Skeleton(Cell cell)
            : base(cell)
        {
        }

        /// <inheritdoc/>
        public override string Tilename => "Skeleton";

        /// <inheritdoc/>
        public override bool IsNotPassable => true;

        /// <inheritdoc/>
        public override void CollectItem()
        {
            System.Console.WriteLine(" ");
        }
    }
}