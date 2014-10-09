// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_154.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_154.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_154.
    /// </summary>
    internal class Sim_EX1_154 : SimTemplate
    {
        // wrath

        // wählt aus:/ fügt einem diener $3 schaden zu; oder fügt einem diener $1 schaden zu und zieht eine karte.
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
            int damage = 0;
            if (choice == 1)
            {
                damage = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            }

            if (choice == 2)
            {
                damage = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            }

            p.minionGetDamageOrHeal(target, damage);

            if (choice == 2)
            {
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }
        }

        #endregion
    }
}