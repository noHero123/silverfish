// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_302.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_302.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_302.
    /// </summary>
    class Sim_EX1_302 : SimTemplate
	{
	    // mortalcoil

// fügt einem diener $1 schaden zu. zieht eine karte, wenn er dadurch vernichtet wird.

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
            if (dmg >= target.Hp && !target.divineshild && !target.immune)
            {
                // this.owncarddraw++;
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }

            p.minionGetDamageOrHeal(target, dmg);
            
		}

	}
}