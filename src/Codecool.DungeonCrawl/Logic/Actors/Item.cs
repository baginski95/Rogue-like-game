using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    /// General Item class
    /// </summary>
    public abstract class Item : Equipment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="cell">Starting cell</param>
        public Item(Cell cell)
            : base(cell)
            { }
    }
}
