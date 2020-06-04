using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    /// Key
    /// </summary>
    public class Key : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="cell">Location</param>
        /// <param name="keyType">Type of key</param>
        public Key(Cell cell, string keyType)
    : base(cell)
        {
            KeyType = keyType;
        }

        /// <summary>
        /// Gets the type of key
        /// </summary>
        public string KeyType { get; }

        /// <inheritdoc/>
        public override bool IsNotCollected => false;

        /// <inheritdoc/>
        public override bool IsNotPassable => false;

        /// <inheritdoc/>
        public override string Tilename => KeyType;
    }
}
