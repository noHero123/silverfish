// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_278.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_278.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_278.
    /// </summary>
    internal class Sim_EX1_278 : SimTemplate
    {
        // shiv

        // verursacht $1 schaden. zieht eine karte.
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
            int dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

        #endregion
    }
}