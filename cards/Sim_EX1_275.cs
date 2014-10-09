// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_275.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_275.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ e x 1_275.
    /// </summary>
    internal class Sim_EX1_275 : SimTemplate
    {
        // coneofcold

        // friert/ einen diener sowie seine benachbarten diener ein und fügt ihnen $1 schaden zu.
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
            int dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
            target.frozen = true;
            List<Minion> temp = target.own ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (target.zonepos == m.zonepos + 1 || target.zonepos + 1 == m.zonepos)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                    m.frozen = true;
                }
            }
        }

        #endregion
    }
}