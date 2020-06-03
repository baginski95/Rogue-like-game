using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    /// Weapon is a base class for every weapon in the dungeon.
    /// </summary>
    public class Weapon : Equipment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        /// <param name="power">Power</param>
        /// <param name="weaponName">Weapon name</param>
        /// <param name="range">Range</param>
        /// <param name="cell">The starting cell</param>
        public Weapon(int power, string weaponName, Cell cell, int range = 1)
            : base(cell)
        {
            Power = power;
            WeaponName = weaponName;
            Range = range;
        }

        /// <summary>
        /// Gets the power
        /// </summary>
        public int Power { get; }

        /// <summary>
        /// Gets the name of weapon
        /// </summary>
        public string WeaponName { get; }

        /// <summary>
        /// Gets the range
        /// </summary>
        public int Range { get;  }

        /// <inheritdoc/>
        public override string Tilename => WeaponName;

        /// <inheritdoc/>
        public override bool IsNotPassable => false;
    }
}
