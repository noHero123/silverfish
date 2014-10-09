// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_114.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_114.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace HREngine.Bots
{
    /// <summary>
    /// The sim_ c s 2_114.
    /// </summary>
    class Sim_CS2_114 : SimTemplate
	{
	    // cleave

// fügt zwei zufälligen feindlichen dienern $2 schaden zu.

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
            // TODO delete new list
            int damage = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            List<Minion> temp2 = ownplay ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions) ;
            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));
            int i = 0;
            foreach (Minion enemy in temp2)
            {
                p.minionGetDamageOrHeal(enemy, damage);
                i++;
                if (i == 2) break;
            }


		}

	}
}