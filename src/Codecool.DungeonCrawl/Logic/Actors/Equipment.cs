using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    /// Item is a base class for every equipment in the dungeon.
    /// </summary>
    public abstract class Equipment : Actor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        /// <param name="cell">The cell of this actor</param>
        public Equipment(Cell cell)
            : base(cell)
        {
        }

        /// <summary>
        /// Gets a value indicating whether - idnicated if item was already collected
        /// </summary>
        public abstract bool IsCollected { get; }
    }
}
