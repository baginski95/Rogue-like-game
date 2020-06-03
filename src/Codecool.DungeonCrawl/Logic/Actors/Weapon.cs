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
        /// <param name="ammo">The starting ammo</param>
        public Weapon(int power, string weaponName, Cell cell, int range = 1, int ammo = -1)
            : base(cell)
        {
            Power = power;
            WeaponName = weaponName;
            Range = range;
            Ammo = ammo;
                    }

        /// <summary>
        /// Gets the power
        /// </summary>
        public int Power { get; }

        /// <summary>
        /// Gets the ammo of weapon (-1 if melee)
        /// </summary>
        public int Ammo { get; }

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
        public override bool IsPassable => true;
    }
}
