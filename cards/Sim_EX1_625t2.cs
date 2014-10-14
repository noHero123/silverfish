// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_EX1_625t2.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ e x 1_625 t 2.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ e x 1_625 t 2.
    /// </summary>
    internal class Sim_EX1_625t2 : SimTemplate
    {
        // mindshatter

        // heldenfähigkeit/\nverursacht 3 schaden.
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
            int dmg = 3;
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