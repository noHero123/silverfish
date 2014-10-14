// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_233.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_233.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_233.
    /// </summary>
    internal class Sim_CS2_233 : SimTemplate
    {
        // Blade Flurry
        #region Public Methods and Operators

        /// <summary>
        /// The on card play.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="ownplay">
        /// The ownplay.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = ownplay
                             ? p.getSpellDamageDamage(p.ownWeaponAttack)
                             : p.getEnemySpellDamageDamage(p.enemyWeaponAttack);

            p.allCharsOfASideGetDamage(!ownplay, damage);

            // destroy own weapon
            p.lowerWeaponDurability(1000, true);
        }

        #endregion
    }
}