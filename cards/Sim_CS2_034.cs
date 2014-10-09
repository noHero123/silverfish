// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_034.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_034.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_034.
    /// </summary>
    internal class Sim_CS2_034 : SimTemplate
    {
        // fireblast

        // heldenfähigkeit/\nverursacht 1 schaden.
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
            int dmg = 1;
            if (ownplay)
            {
                if (p.doublepriest >= 1)
                {
                    dmg *= 2 * p.doublepriest;
                }
            }
            else
            {
                if (p.enemydoublepriest >= 1)
                {
                    dmg *= 2 * p.enemydoublepriest;
                }
            }

            p.minionGetDamageOrHeal(target, dmg);
        }

        #endregion
    }
}