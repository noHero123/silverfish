// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_365.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_365.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_365.
    /// </summary>
    class Sim_EX1_365 : SimTemplate
    {
        // holywrath
        // todo ask the posibility manager!

        // zieht eine karte und verursacht schaden, der ihren kosten entspricht.
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
            p.drawACard(CardDB.cardName.unknown, ownplay);

            int dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}