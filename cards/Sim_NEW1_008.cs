// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_NEW1_008.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ ne w 1_008.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ ne w 1_008.
    /// </summary>
    class Sim_NEW1_008: SimTemplate
    {
        // ancient of lore

        // Zieht 2 Karten; oder stellt 5 Leben wieder her
        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 2)
            {
                int heal = own.own ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);
                p.minionGetDamageOrHeal(target, -heal);
            }
            else
            {
                p.drawACard(CardDB.cardName.unknown, own.own);
                p.drawACard(CardDB.cardName.unknown, own.own);
            }
        }

    }
}
