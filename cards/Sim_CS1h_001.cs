// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS1h_001.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 1 h_001.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 1 h_001.
    /// </summary>
    internal class Sim_CS1h_001 : SimTemplate
    {
        // lesserheal

        // heldenfähigkeit/\nstellt 2 leben wieder her.
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
            int heal = 2;
            if (ownplay)
            {
                if (p.anzOwnAuchenaiSoulpriest >= 1)
                {
                    heal = -heal;
                }

                if (p.doublepriest >= 1)
                {
                    heal *= 2 * p.doublepriest;
                }
            }
            else
            {
                if (p.anzEnemyAuchenaiSoulpriest >= 1)
                {
                    heal = -heal;
                }

                if (p.enemydoublepriest >= 1)
                {
                    heal *= 2 * p.enemydoublepriest;
                }
            }

            p.minionGetDamageOrHeal(target, -heal);
        }

        #endregion
    }
}