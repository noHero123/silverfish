// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_354.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_354.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_354.
    /// </summary>
    class Sim_EX1_354 : SimTemplate
    {
        // lay on hands

        // Stellt #8 Leben wieder her. Zieht 3 Karten.
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
            int heal = ownplay ? p.getSpellHeal(8) : p.getEnemySpellHeal(8);
            p.minionGetDamageOrHeal(target, -heal);
            for (int i = 0; i < 3; i++)
            {
                // this.owncarddraw++;
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }
            
        }

    }
}
