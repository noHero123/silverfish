// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sim_CS2_146.cs" company="">
//   
// </copyright>
// <summary>
//   The sim_ c s 2_146.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HREngine.Bots
{
    /// <summary>
    ///     The sim_ c s 2_146.
    /// </summary>
    internal class Sim_CS2_146 : SimTemplate
    {
        // southseadeckhand

        // hat ansturm/, während ihr eine waffe angelegt habt.
        #region Public Methods and Operators

        /// <summary>
        /// The get battlecry effect.
        /// </summary>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <param name="own">
        /// The own.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="choice">
        /// The choice.
        /// </param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.ownWeaponDurability >= 1)
                {
                    p.minionGetCharge(own);
                }
            }
            else
            {
                if (p.enemyWeaponDurability >= 1)
                {
                    p.minionGetCharge(own);
                }
            }
        }

        #endregion
    }
}