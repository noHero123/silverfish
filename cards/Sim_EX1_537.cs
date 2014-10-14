// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_537.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_537.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ e x 1_537.
    /// </summary>
    internal class Sim_EX1_537 : SimTemplate
    {
        // explosiveshot

        // fügt einem diener $5 schaden und benachbarten dienern $2 schaden zu.
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
            int dmg1 = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            int dmg2 = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            List<Minion> temp = target.own ? p.ownMinions : p.enemyMinions;
            p.minionGetDamageOrHeal(target, dmg1);
            foreach (Minion m in temp)
            {
                if (m.zonepos + 1 == target.zonepos || m.zonepos - 1 == target.zonepos)
                {
                    p.minionGetDamageOrHeal(m, dmg2);
                }
            }
        }

        #endregion
    }
}