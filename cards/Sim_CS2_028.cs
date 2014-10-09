// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_028.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_028.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_028.
    /// </summary>
    internal class Sim_CS2_028 : SimTemplate
    {
        // blizzard

        // fügt allen feindlichen dienern $2 schaden zu und friert/ sie ein.
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
            int dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg, true);
        }

        #endregion
    }
}