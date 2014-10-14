// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_PRO_001b.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ pr o_001 b.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ pr o_001 b.
    /// </summary>
    internal class Sim_PRO_001b : SimTemplate
    {
        // Rogues Do It...
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
            int dmg = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
        }

        #endregion
    }
}