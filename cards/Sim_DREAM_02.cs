// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DREAM_02.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ drea m_02.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ drea m_02.
    /// </summary>
    internal class Sim_DREAM_02 : SimTemplate
    {
        // yseraawakens

        // fügt allen charakteren mit ausnahme von ysera $5 schaden zu.
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
            int dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            foreach (Minion m in p.ownMinions)
            {
                if (m.name != CardDB.cardName.ysera)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }

            foreach (Minion m in p.enemyMinions)
            {
                if (m.name != CardDB.cardName.ysera)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }

            p.minionGetDamageOrHeal(p.ownHero, dmg);
            p.minionGetDamageOrHeal(p.enemyHero, dmg);
        }

        #endregion
    }
}