// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_154b.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_154 b.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_154 b.
    /// </summary>
    internal class Sim_EX1_154b : SimTemplate
    {
        // wrath

        // fügt einem diener $1 schaden zu. zieht eine karte.
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
            int damage = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);

            // this.owncarddraw++;
            p.minionGetDamageOrHeal(target, damage);
            p.drawACard(CardDB.cardName.unknown, ownplay);
        }

        #endregion
    }
}