// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_596.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_596.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ e x 1_596.
    /// </summary>
    class Sim_EX1_596 : SimTemplate
	{
	    // demonfire

// fügt einem diener $2 schaden zu. wenn das ziel ein verbündeter dämon ist, erhält er stattdessen +2/+2.
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
            if (target.handcard.card.race == 15 && ownplay == target.own)
            {
                p.minionGetBuffed(target, 2, 2);
            }
            else
            {
                int dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
                p.minionGetDamageOrHeal(target, dmg);
            }
        }


	}
}