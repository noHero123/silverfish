// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_007b.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_007 b.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ ne w 1_007 b.
    /// </summary>
    internal class Sim_NEW1_007b : SimTemplate
    {
        // starfall choice left
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
            int dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
        }

        #endregion
    }
}