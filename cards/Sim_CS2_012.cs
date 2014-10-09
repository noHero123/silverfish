// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_012.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_012.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    using System.Collections.Generic;

    /// <summary>
    ///     The sim_ c s 2_012.
    /// </summary>
    internal class Sim_CS2_012 : SimTemplate
    {
        // swipe

        // fügt einem feind $4 schaden und allen anderen feinden $1 schaden zu.
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
            int dmg1 = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            List<Minion> temp = ownplay ? p.enemyMinions : p.ownMinions;
            p.minionGetDamageOrHeal(target, dmg1);
            foreach (Minion m in temp)
            {
                if (m.entitiyID != target.entitiyID)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }

            if (ownplay)
            {
                if (p.enemyHero.entitiyID != target.entitiyID)
                {
                    p.minionGetDamageOrHeal(p.enemyHero, dmg);
                }
            }
            else
            {
                if (p.ownHero.entitiyID != target.entitiyID)
                {
                    p.minionGetDamageOrHeal(p.ownHero, dmg);
                }
            }
        }

        #endregion
    }
}