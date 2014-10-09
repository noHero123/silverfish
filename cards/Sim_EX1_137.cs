// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_137.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_137.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_137.
    /// </summary>
    internal class Sim_EX1_137 : SimTemplate
    {
        // headcrack

        // fügt dem feindlichen helden $2 schaden zu. combo:/ lasst die karte in eurem nächsten zug wieder auf eure hand zurückkehren.
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
            if (ownplay)
            {
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
            else
            {
                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }

            if (p.cardsPlayedThisTurn >= 1)
            {
                p.evaluatePenality -= 5;
            }
        }

        #endregion
    }
}