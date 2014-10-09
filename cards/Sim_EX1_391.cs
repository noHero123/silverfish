// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_391.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_391.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_391.
    /// </summary>
    internal class Sim_EX1_391 : SimTemplate
    {
        // slam

        // fügt einem diener $2 schaden zu. zieht eine karte, wenn er überlebt.
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
            if (target.Hp > dmg || target.immune || target.divineshild)
            {
                // this.owncarddraw++;
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }

            p.minionGetDamageOrHeal(target, dmg);
        }

        #endregion
    }
}