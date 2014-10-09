// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_DS1h_292.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ d s 1 h_292.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ d s 1 h_292.
    /// </summary>
    internal class Sim_DS1h_292 : SimTemplate
    {
        // steadyshot

        // heldenfähigkeit/\nfügt dem feindlichen helden 2 schaden zu.
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
            int dmg = 2;
            if (ownplay)
            {
                if (p.doublepriest >= 1)
                {
                    dmg *= 2 * p.doublepriest;
                }

                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
            else
            {
                if (p.enemydoublepriest >= 1)
                {
                    dmg *= 2 * p.enemydoublepriest;
                }

                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }
        }

        #endregion
    }
}